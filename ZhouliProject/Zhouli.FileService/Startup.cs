using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public static ILoggerRepository repository { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions().Configure<CustomConfiguration>(Configuration.GetSection("CustomConfiguration"));
            //配置跨域
            services.AddCors(options => options.AddPolicy("fileServiceCors", builder =>
              builder.AllowAnyOrigin()));
            services.AddMvc(
                //注册全局异常过滤器
                o =>
                {
                    o.Filters.Add<HttpGlobalExceptionFilter>();
                }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //日志记录中间件
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            app.UseStaticFiles();
            app.UseCors("fileServiceCors");
            app.UseMvc();
        }
    }
}
