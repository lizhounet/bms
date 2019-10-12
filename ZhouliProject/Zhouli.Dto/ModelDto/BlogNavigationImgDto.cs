using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogNavigationImgDto
    {
        public int NavigationImgId { get; set; }
        public string NavigationImgUrl { get; set; }
        public string NavigationImgDescribe { get; set; }
        public int NavigationImgIsEnable { get; set; }
        public DateTime CreateTime { get; set; }
        public string Note { get; set; }
    }
}
