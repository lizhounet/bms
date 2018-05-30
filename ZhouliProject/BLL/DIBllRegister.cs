using BLL.Implements;
using BLL.Interface;
using DAL.Implements;
using DAL.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DIBllRegister
    {
        public void DIRegister(IServiceCollection services)
        {
            // 用于实例化BaseDAL对象，获取上下文对象
            services.AddTransient(typeof(IBaseDAL<>), typeof(BaseDAL<>));

            // 配置依赖注入映射关系 
            services.AddTransient(typeof(IUsersBLL), typeof(UsersBLL));
        }
    }
}
