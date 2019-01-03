using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogFriendshipLink
    {
        public int FriendshipLinkId { get; set; }
        public string FriendshipLinkName { get; set; }
        public int FriendshipLinkUrl { get; set; }
        public int FriendshipLinkEmail { get; set; }
        public int FriendshipLinkSortValue { get; set; }
        public int FriendshipLinkSfsh { get; set; }
    }
}
