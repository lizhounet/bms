using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class SysButton
    {
        public string ButtonId { get; set; }
        public string MenuId { get; set; }
        public string ButtonName { get; set; }
        public int ButtonShowType { get; set; }
    }
}
