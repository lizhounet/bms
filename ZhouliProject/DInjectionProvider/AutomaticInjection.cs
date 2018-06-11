#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/6/8 21:41:11 
 * 当前版本：1.0.0.1 
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ ZhouLi 2018 All rights reserved 
 *┌──────────────────────────────────┐
 *│　此技术信息周黎的机密信息，未经本人书面同意禁止向第三方披露．　│
 *│　版权所有：周黎 　　　　　　　　　　　　　　│
 *└──────────────────────────────────┘
*****************************************************************/
#endregion
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Zhouli.BLL.Implements;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Implements;
using Zhouli.DAL.Interface;
namespace DInjectionProvider
{

    /// <summary>
    /// 自动注入依赖关系扩展类
    /// </summary>
    public static class AutomaticInjection
    {
        /// <summary>  
        /// 自动注入依赖关系
        /// </summary>  
        /// <param name="assemblyNames">需要扫描的项目名称集合</param>
        public static void ResolveAllTypes(this IServiceCollection services, params string[] assemblyNames)
        {
            //assemblyNames 需要扫描的项目名称集合
            //注意: 如果使用此方法，必须提供需要扫描的项目名称
            if (assemblyNames.Length > 0)
            {
                foreach (var assemblyName in assemblyNames)
                {
                    Assembly assembly = Assembly.Load(assemblyName);
                    List<Type> ts = assembly.GetTypes().ToList();
                    foreach (var item in ts.Where(s => !s.IsInterface))
                    {
                        var interfaceType = item.GetInterfaces();
                        foreach (var typeArray in interfaceType)
                        {
                            if (!typeArray.IsGenericType)
                                services.AddScoped(typeArray, item);
                        }
                    }
                }
                services.AddSingleton(typeof(IBaseDAL<>), typeof(BaseDAL<>));
                services.AddSingleton(typeof(IBaseBLL<>), typeof(BaseBLL<>));
                //注意这里:上面两行代码是.net core 正常配置代码（为什么这里使用了反射自动配置还要加入此代码,我在这里解释一下,因为上面两个是泛型类和泛型接口,我也不知道为什么这里用反射配置泛型的时候会报错,暂时没找到解决办法,所以这里采用一个傻的办法 就是手写一遍这两个的依赖注入关系）
            }
        }
    }
}
