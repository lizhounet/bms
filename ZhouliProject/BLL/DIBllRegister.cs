using BLL.Implements;
using BLL.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DIBLLRegister
    {
        public static void BLLRegister(IServiceCollection services)
        {
            // 配置依赖注入映射关系 
            services.AddScoped(typeof(ISysUsersBLL), typeof(SysUsersBLL));
            services.AddScoped(typeof(ISysUserGroupBLL), typeof(SysUserGroupBLL));
        }
    }
}
