using Microsoft.AspNetCore.Http;
using System;

namespace DInjectionProvider
{
    /// <summary>
    /// 依赖注入提供者类
    /// </summary>
    public class DInjectionProvider : IDInjectionProvider
    {
        private IHttpContextAccessor httpContextAccessor;
        public DInjectionProvider(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        /// <summary>
        /// 可以获取.net core 配置了依赖注入关系的所有实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetExamples<T>()
        {
            return (T)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}
