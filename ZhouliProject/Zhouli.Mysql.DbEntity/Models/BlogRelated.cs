using System;
using System.Collections.Generic;

namespace Zhouli.Mysql.DbEntity.Models
{
    public partial class BlogRelated
    {
        public int BlogRelatedId { get; set; }
        public int RelatedArticleId { get; set; }
        public int RelatedLableId { get; set; }
    }
}
