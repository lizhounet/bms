using System;
using System.Collections.Generic;

namespace Zhouli.Mysql.DbEntity.Models
{
    public partial class BlogArticleseeinfo
    {
        public int ArticleSeeInfoArticleId { get; set; }
        public int ArticleSeeInfoArticleBrowsingNum { get; set; }
        public int ArticleSeeInfoArticleLikeNum { get; set; }
        public int ArticleSeeInfoArticleCommentNum { get; set; }
    }
}
