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
using Microsoft.AspNetCore.Http;
using System;

namespace DInjectionProvider
{
    /// <summary>
    /// 依赖注入提供者类
    /// </summary>
    public class WholeInjection
    {
        public WholeInjection(IHttpContextAccessor _httpContextAccessor)
        {
            GetHttpContext = _httpContextAccessor;
        }
        /// <summary>
        /// 可以获取.net core 配置了依赖注入关系的所有实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetT<T>()
        {
            return (T)GetHttpContext.HttpContext.RequestServices.GetService(typeof(T));
        }
        public IHttpContextAccessor GetHttpContext { get; }

    }
}
