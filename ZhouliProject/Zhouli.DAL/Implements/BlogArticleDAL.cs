using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Zhouli.DAL.Implements
{
    public class BlogArticleDAL : BaseDAL<BlogArticle>, IBlogArticleDAL
    {
        public BlogArticleDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration)
        {
        }
        /// <summary>
        /// 获取文章最大排序值
        /// </summary>
        /// <returns></returns>
        public int GetMaxArticleSortValue()
        {
            return _db.BlogArticle.Select(t => t.ArticleSortValue).DefaultIfEmpty().Max();
        }
    }
}
