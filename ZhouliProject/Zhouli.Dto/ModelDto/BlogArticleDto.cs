using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogArticleDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleThrink { get; set; }
        public string ArticleBodySummary { get; set; }
        public int ArticleSortValue { get; set; }
        public DateTime CreateTime { get; set; }
        public string Note { get; set; }
        public int[] LableId { set; get; }
    }
}
