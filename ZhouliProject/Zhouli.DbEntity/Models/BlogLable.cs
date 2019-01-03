using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogLable
    {
        public int LableId { get; set; }
        public string LableName { get; set; }
        public int LableSortValue { get; set; }
        public long LableClickNum { get; set; }
        public DateTime LableCreateTime { get; set; }
        public string LableNote { get; set; }
    }
}
