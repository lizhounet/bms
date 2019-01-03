using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class SysMenu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuIcon { get; set; }
        public string MenuUrl { get; set; }
        public int MenuSort { get; set; }
        public string ParentMenuId { get; set; }
        public string CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
