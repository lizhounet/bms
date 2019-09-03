using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogArticleLike
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Ip { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
