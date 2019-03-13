using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogFriendshipLink
    {
        public int FriendshipLinkId { get; set; }
        public string FriendshipLinkName { get; set; }
        public string FriendshipLinkUrl { get; set; }
        public string FriendshipLinkEmail { get; set; }
        public int FriendshipLinkSortValue { get; set; }
        public int FriendshipLinkSfsh { get; set; }
        public string CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
