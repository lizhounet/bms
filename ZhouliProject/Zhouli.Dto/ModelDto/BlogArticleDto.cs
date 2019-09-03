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
        public string ArticleBody { get; set; }
        public int ArticleSortValue { get; set; }
        public bool ArticleTop { set; get; } = false;
        public DateTime CreateTime { get; set; }
        public string CreateUser { set; get; }
        public string Note { get; set; }
        public int[] LableId { set; get; }
        public string[] LableName { set; get; }
        public int ArticleBrowsingNum { set; get; }
        public int ArticleCommentNum { set; get; }
        public int ArticleLikeNum { set; get; }
    }
}
