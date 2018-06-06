using System;
using System.Collections.Generic;
using System.Text;

namespace DInjectionProvider
{
    /// <summary>
    /// 依赖注入提供者类
    /// </summary>
    public interface IDInjectionProvider
    {
        /// <summary>
        /// 可以获取.net core 配置了依赖注入关系的所有实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetExamples<T>();
    }
}
