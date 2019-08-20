using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Common.ResultModel
{
    /// <summary>
    /// 处理结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HandleResult<T>
    {
        /// <summary>
        /// 结果(默认:true)
        /// </summary>
        public bool Result { set; get; } = true;
        /// <summary>
        /// 提示信息(默认:"成功")
        /// </summary>
        public string Msg { set; get; } = "成功";
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { set; get; }
    }
}
