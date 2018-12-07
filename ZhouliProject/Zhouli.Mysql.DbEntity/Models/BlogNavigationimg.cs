using System;
using System.Collections.Generic;

namespace Zhouli.Mysql.DbEntity.Models
{
    public partial class BlogNavigationimg
    {
        public int NavigationImgId { get; set; }
        public string NavigationImgUrl { get; set; }
        public int NavigationImgSortValue { get; set; }
        public string NavigationImgDescribe { get; set; }
    }
}
