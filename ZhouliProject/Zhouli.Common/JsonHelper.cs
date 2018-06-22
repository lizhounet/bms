using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Common
{
    /// <summary>
    /// Json帮助类(Json与对象之前相互转换)
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// Json字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// 对象转换为json字符串
        /// </summary>
        /// <typeparam name="object"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ObjectToJson(object t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }
    }
}
