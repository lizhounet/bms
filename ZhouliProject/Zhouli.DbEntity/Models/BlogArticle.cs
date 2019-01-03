using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogArticle
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleBody { get; set; }
        public string ArticleBodyMarkdown { get; set; }
        public int ArticleSortValue { get; set; }
        public DateTime ArticleCreateTime { get; set; }
        public int ArticleUserId { get; set; }
        public string ArticleUserNikeName { get; set; }
        public string ArticleNote { get; set; }
    }
}
