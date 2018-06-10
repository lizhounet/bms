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
