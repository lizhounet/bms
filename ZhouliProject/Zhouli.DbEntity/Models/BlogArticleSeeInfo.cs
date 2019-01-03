using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class BlogArticleSeeInfo
    {
        public int ArticleSeeInfoArticleId { get; set; }
        public int ArticleSeeInfoArticleBrowsingNum { get; set; }
        public int ArticleSeeInfoArticleLikeNum { get; set; }
        public int ArticleSeeInfoArticleCommentNum { get; set; }
    }
}
