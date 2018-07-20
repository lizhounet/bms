using DInjectionProvider;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.IO;
using ZhouliSystem.Data;
using ZhouliSystem.Filters;
using ZhouliSystem.Models;

namespace ZhouliSystem
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
            // 数据库连接字符串
            var conStr = Configuration.GetConnectionString("dataConnection");
            var conDataType = Configuration.GetConnectionString("dataBaseType");
            #region 框架的配置关系
            //注入ef对象
            services.AddDbContext<Zhouli.DbEntity.Models.ZhouLiContext>(options => options.UseSqlServer(conStr, b => b.UseRowNumberForPaging()),
                ServiceLifetime.Singleton);
            //添加session中间件
            services.AddSession();
            //.net core 2.1时默认不注入HttpContextAccessor依赖注入关系,所以再此手动注册
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //注入gzip压缩中间件
            services.AddResponseCompression();
            //注入Response 缓存中间件
            services.AddResponseCaching();
            //重置区域匹配路径规则
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}Manager/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}Manager/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });
            //mvc框架 
            services.AddMvc(o =>
            {
                //注册全局异常过滤器
                o.Filters.Add<HttpGlobalExceptionFilter>();
                //配置缓存信息
                o.CacheProfiles.Add("default", new Microsoft.AspNetCore.Mvc.CacheProfile
                {
                    Duration = 60 * 10,  // 10 秒
                });
                o.CacheProfiles.Add("Hourly", new Microsoft.AspNetCore.Mvc.CacheProfile
                {
                    Duration = 60 * 60,  // 1 hour
                                         //Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any,
                                         //NoStore = true,
                                         //VaryByHeader = "User-Agent",
                                         //VaryByQueryKeys = new string[] { "aaa" }
                });
            });

            #endregion
            #region 自定义的配置关系
            //注入全局依赖注入提供者类
            services.AddSingleton(typeof(WholeInjection));
            services.AddSingleton(typeof(UserAccount));
            services.AddSingleton(new Zhouli.DAL.DapperContext(conStr, conDataType));
            services.ResolveAllTypes(new string[] { "Zhouli.DAL", "Zhouli.BLL" });
            //初始化Dto与实体映射关系
            Zhouli.BLL.ZhouliMapper.Initialize();
            //注入配置文件类
            services.AddOptions().Configure<CustomConfiguration>(Configuration.GetSection("CustomConfiguration"));
            #endregion


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
            //日志记录中间件
            repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //gzip压缩中间件
            app.UseResponseCompression();
            //Response 缓存中间件
            app.UseResponseCaching();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //初始化数据库
            InitSystem.InitDB(app.ApplicationServices);
        }
    }
}
