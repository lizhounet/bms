using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Dto.ModelDto
{
    public class BlogLableDto
    {
        /// <summary>
        /// 博客标签id
        /// </summary>
        public int LableId { get; set; }
        /// <summary>
        /// 博客标签名称
        /// </summary>
        public string LableName { get; set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int LableSortValue { get; set; }
        /// <summary>
        /// 博客标签点击量
        /// </summary>
        public long LableClickNum { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? EditTime { get; set; }
        /// <summary>
        /// 1 未删除 2 已删除
        /// </summary>
        public int DeleteSign { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
