using Zhouli.DAL.Implements;
using Zhouli.DAL.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DIDALRegister
    {
        public static void DALRegister(IServiceCollection services)
        {
            // 用于实例化BaseDAL对象，获取上下文对象
            services.AddSingleton(typeof(IBaseDAL<>), typeof(BaseDAL<>));
            // 配置依赖注入映射关系 
            services.AddScoped(typeof(ISysUsersDAL), typeof(SysUsersDAL));
            services.AddScoped(typeof(ISysUserGroupDAL), typeof(SysUserGroupDAL));
        }
    }
}
