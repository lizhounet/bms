using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DInjectionProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zhouli.Entity.Models;

namespace ZhouliSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 数据库连接字符串
            var conStr = Configuration.GetConnectionString("DataConnection");
            //注入ef对象
            services.AddDbContext<GRWEBSITEContext>(options => options.UseSqlServer(conStr));
            //BLL层设置依赖注入关系
            BLL.DIBLLRegister.BLLRegister(services);
            //DAL层设置依赖注入关系
            DAL.DIDALRegister.DALRegister(services);
            //添加session中间件
            services.AddSession();
            //设置依赖注入提供者类关系
            services.AddSingleton(typeof(IDInjectionProvider), typeof(DInjectionProvider.DInjectionProvider));
            //mvc框架
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
