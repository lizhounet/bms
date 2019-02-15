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
        public string CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
