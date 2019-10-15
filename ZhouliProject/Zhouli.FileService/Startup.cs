using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Zhouli.Common.Middleware;
using Zhouli.FileService.Filters;
using Zhouli.FileService.Models;

namespace Zhouli.FileService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static ILoggerRepository Repository { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();//注入文件访问
            services.AddMvc(
               //注册全局异常过滤器
               o =>
               {
                   o.Filters.Add<HttpGlobalExceptionFilter>();
               }
               ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(o =>
               {
                   o.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                   o.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
               });
            services.AddOptions().Configure<CustomConfiguration>(Configuration.GetSection("CustomConfiguration"));
            //配置跨域
            services.AddCors(options => options.AddPolicy("fileServiceCors", builder =>
              builder.AllowAnyOrigin().
              AllowAnyMethod().
              AllowAnyHeader())
              );
            services.AddAuthentication((options) =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters();
                options.RequireHttpsMetadata = false;
                options.Audience = "Zhouli.FileService";//api范围
                options.Authority = Configuration["CustomConfiguration:IdentityServerAdress"];//IdentityServer地址
            });
            //.AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = Configuration.GetSection("IdentityServerAdress").Value; // IdentityServer服务器地址
            //        options.ApiName = "Zhouli.FileService"; // 用于针对进行身份验证的API资源的名称
            //        options.Audience=""
            //        options.RequireHttpsMetadata = false; // 指定是否为HTTPS
            //    }); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("fileservice_v1", new Info
                {
                    Title = "文件服务的api文档",
                    Version = "v1",
                    Description = "文件服务的api文档",
                    //服务条款
                    TermsOfService = "None",
                    //作者信息
                    Contact = new Contact
                    {
                        Name = "周黎",
                        Email = "zl_2962@foxmail.com",
                        Url = "http://blog.zhouli.info/"
                    }
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Zhouli.FileService.xml");
                c.IncludeXmlComments(xmlPath);
                c.OperationFilter<AddAuthTokenHeaderParameter>();
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Bearer 授权 \"Authorization:     Bearer+空格+token\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.OperationFilter<AuthorizeCheckOperationFilter>(); // 添加IdentityServer4认证过滤
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRealIp();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //日志记录中间件
            Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
            #region 配置文件访问中间件
            string path = $@"{env.ContentRootPath}\Upload\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(path)
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                #region 设置默认MIME Type
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/x-msdownload",
                ContentTypeProvider = new FileExtensionContentTypeProvider(),
                FileProvider = new PhysicalFileProvider(path),
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");//文件缓存10分钟吧
                }
                #endregion
            });//使用默认文件夹wwwroot
            #endregion
            app.UseCors("fileServiceCors");//跨域
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/fileservice_v1/swagger.json", "FileService WebApi V1");
                c.RoutePrefix = "";
                c.OAuthClientId("zhouli");//客服端名称
                c.OAuthClientSecret("991022");
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
