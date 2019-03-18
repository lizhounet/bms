using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Dto.ModelDto
{
    public class BlogFriendshipLinkDto
    {
        /// <summary>
        /// 友情链接id
        /// </summary>
        public int FriendshipLinkId { get; set; }
        /// <summary>
        /// 友情链接名称
        /// </summary>
        public string FriendshipLinkName { get; set; }
        /// <summary>
        /// 友情链接url
        /// </summary>
        public string FriendshipLinkUrl { get; set; }
        /// <summary>
        /// 友情链接邮箱
        /// </summary>
        public string FriendshipLinkEmail { get; set; }
        public int FriendshipLinkSortValue { get; set; }
        public int FriendshipLinkSfsh { get; set; }
        /// <summary>
        /// 创建人id
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
        /// 是否删除字段
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
