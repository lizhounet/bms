using DInjectionProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Zhouli.BLL.Implements;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Implements;
using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using ZhouliSystem.Filters;

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
            services.AddDbContext<ZhouLiContext>(options => options.UseSqlServer(conStr));
            //添加session中间件
            services.AddSession();
            //注入全局依赖注入提供者类
            services.AddSingleton(typeof(WholeInjection));
            services.ResolveAllTypes(new string[] { "Zhouli.DAL", "Zhouli.BLL" });
            //.net core 2.1时默认不注入HttpContextAccessor依赖注入关系,所以再此手动注册
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //mvc框架 注册全局异常过滤器
            services.AddMvc(o => o.Filters.Add<HttpGlobalExceptionFilter>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())//开发环境
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
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
            //初始化数据库
            Zhouli.Entity.InitSystem.InitDB(app.ApplicationServices);
        }
    }
}
