using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Zhouli.BlogWebApi.Filters;
using Zhouli.DbEntity.ModelDto;
using Zhouli.DI;
using Zhouli.Enum;

namespace BlogWebApi
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
            // 数据库连接字符串
            var srtdataBaseType = Configuration.GetConnectionString("DataBaseType");
            var strConnection = Configuration.GetConnectionString("ConnectionString");
            //注入数据访问对象
            switch (Enum.Parse(typeof(DataBaseType), srtdataBaseType))
            {
                case DataBaseType.SqlServer:
                    services.AddDbContext<Zhouli.DbEntity.Models.ZhouLiContext>(options => options.UseSqlServer(strConnection, b => b.UseRowNumberForPaging()),
               ServiceLifetime.Scoped);
                    services.AddScoped<IDbConnection, SqlConnection>(t => new SqlConnection(strConnection));
                    break;
                case DataBaseType.MySql:
                    services.AddDbContext<Zhouli.DbEntity.Models.ZhouLiContext>(options => options.UseMySql(strConnection),
              ServiceLifetime.Scoped);
                    services.AddScoped<IDbConnection, MySqlConnection>(t => new MySqlConnection(strConnection));
                    break;
            }
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });
            //配置跨域
            services.AddCors(options => options.AddPolicy("blogWebApiServiceCors", builder =>
              builder.AllowAnyOrigin().
              AllowAnyMethod().
              AllowAnyHeader())
              );
            //权限验证
            services.AddAuthentication((options) =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters();
                options.RequireHttpsMetadata = false;
                options.Audience = "Zhouli.BlogWebApi";//api范围
                options.Authority = Configuration["IdentityServerAdress"];//IdentityServer地址
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
                c.SwaggerDoc("Zhouli.BlogWebApi_v1", new Info
                {
                    Title = "博客的api文档",
                    Version = "v1",
                    Description = "博客的api文档",
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
                var xmlPath = Path.Combine(basePath, "Zhouli.BlogWebApi.xml");
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
            //初始化Dto与实体映射关系
            ZhouliDtoMapper.Initialize();
            //.net core 2.1时默认不注入HttpContextAccessor依赖注入关系,所以再此手动注册
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           // services.AddScoped(typeof(WholeInjection));
            services.AddResolveAllTypes(new string[] { "Zhouli.DAL", "Zhouli.BLL" });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //日志记录中间件
            Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
            app.UseCors("blogWebApiServiceCors");//跨域
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Zhouli.BlogWebApi_v1/swagger.json", "Blog WebApi V1");
                c.RoutePrefix = "swagger";
                c.OAuthClientId("zhouli");//客服端名称
                c.OAuthClientSecret("991022");
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
