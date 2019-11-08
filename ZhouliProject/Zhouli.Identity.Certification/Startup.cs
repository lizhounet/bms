using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Zhouli.Common;
using Zhouli.Common.Middleware;

namespace Zhouli.Identity.Certification
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            // 使用内存存储的密钥，客户端和API资源来配置ids4。
            services.AddIdentityServer()
                .AddSigningCredential(new X509Certificate2(Path.Combine(basePath,
                "zhoulikey.pfx"), Base64Helper.DecodeBase64("OTkwMTIyNjYxOWxs")))
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());
            //配置跨域
            services.AddCors(options => options.AddPolicy("Zhouli.Identity.Certification", builder =>
              builder.AllowAnyOrigin().
              AllowAnyMethod().
              AllowAnyHeader())
              );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRealIp();
            app.UseLogReqResponseMiddleware();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Zhouli.Identity.Certification");//跨域
            app.UseIdentityServer();
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("认证服务器启动成功!");
            });
        }
    }
}
