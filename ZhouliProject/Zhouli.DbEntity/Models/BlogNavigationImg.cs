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
    }
}
