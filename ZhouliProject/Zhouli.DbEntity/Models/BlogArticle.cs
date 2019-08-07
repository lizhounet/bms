using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogArticle
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleThrink { get; set; }
        public string ArticleBody { get; set; }
        public string ArticleBodyMarkdown { get; set; }
        public string ArticleBodySummary { get; set; }
        public int ArticleSortValue { get; set; }
        public string CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
