using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Common
{
    /// <summary>
    /// http普通请求响应客户端消息model
    /// </summary>
    [Serializable]
    public class ResponseMessage
    {
        private Object jsonData;
        /// <summary>
        /// 响应状态
        /// </summary>
        public StatesCode StateCode { set; get; }
        /// <summary>
        /// 响应提示消息
        /// </summary>
        public string Messages { set; get; }
        /// <summary>
        /// 响应json数据
        /// </summary>
        public Object JsonData
        {
            set { jsonData = value; }
            get
            {
                if (jsonData == null)
                    return "[]";
                else
                    return jsonData;

            }
        }
    }
    /// <summary>
    /// 响应状态码
    /// </summary>
    public enum StatesCode
    {
        /// <summary>
        /// 成功状态码
        /// </summary>
        success = 200,
        /// <summary>
        /// 失败状态码
        /// </summary>
        failure = 500,
    }
}
