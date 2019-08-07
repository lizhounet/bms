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
        /// <summary>
        /// 是否审核
        /// </summary>
        public int FriendshipLinkSfsh { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int FriendshipLinkSortValue { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }
}
