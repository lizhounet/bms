using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Zhouli.Common
{
    /// <summary>
    /// 20180603 周黎编写
    /// .net core Session扩展类
    /// </summary>
    public static class SessionExtended
    {
        /// <summary>
        /// 设置session
        /// </summary>
        /// <typeparam name="T">保存的类型</typeparam>
        /// <param name="session"></param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetSession<T>(this ISession session, string key, T value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <typeparam name="T">获取的类型</typeparam>
        /// <param name="session"></param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static T GetSession<T>(this ISession session, string key)
        {
            byte[] b = null;
            session.TryGetValue(key, out b);
            var value = Encoding.UTF8.GetString(b);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }

}
