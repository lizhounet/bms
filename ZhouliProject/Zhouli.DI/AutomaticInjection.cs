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
using System.Linq;
using System.Reflection;
namespace Zhouli.DI
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
        public static void AddResolveAllTypes(this IServiceCollection services, params string[] assemblyNames)
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
            }
        }

    }
}
