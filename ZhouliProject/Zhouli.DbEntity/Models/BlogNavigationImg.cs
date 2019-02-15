using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogNavigationImg
    {
        public int NavigationImgId { get; set; }
        public string NavigationImgUrl { get; set; }
        public int NavigationImgSortValue { get; set; }
        public string NavigationImgDescribe { get; set; }
        public int NavigationImgIsEnable { get; set; }
        public string CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
