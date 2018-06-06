﻿using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysMenu
    {
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuIcon { get; set; }
        public string MenuUrl { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string Note { get; set; }
    }
}
