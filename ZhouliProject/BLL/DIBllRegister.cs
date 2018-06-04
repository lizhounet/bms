using Zhouli.BLL.Implements;
using Zhouli.BLL.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL;

namespace BLL
{
    public class DIBLLRegister
    {
        public static void BLLRegister(IServiceCollection services)
        {
            // 配置依赖注入映射关系 
            services.AddSingleton(typeof(IBllContext), typeof(BLLContext));
            services.AddScoped(typeof(ISysUsersBLL), typeof(SysUsersBLL));
            services.AddScoped(typeof(ISysUserGroupBLL), typeof(SysUserGroupBLL));
            
        }
    }
}
