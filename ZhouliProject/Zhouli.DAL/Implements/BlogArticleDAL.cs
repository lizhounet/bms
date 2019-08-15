using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Zhouli.DbEntity.Views;
using System.Linq.Expressions;
using Zhouli.Enum;

namespace Zhouli.DAL.Implements
{
    public class BlogArticleDAL : BaseDAL<BlogArticle>, IBlogArticleDAL
    {
        public BlogArticleDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public PageModel GetBlogArticleList(string page, string limit, string searchstr)
        {
            Expression<Func<BlogArticle, bool>> expression = t => t.ArticleTitle.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted);
            var query = GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
               t => t.ArticleTitle.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
               && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
            var list = from blogArticle in query
                       join user in _db.SysUser
                       on blogArticle.CreateUserId equals user.UserId
                       into temp
                       from tt in temp.DefaultIfEmpty()
                       select new
                       {
                           blogArticle.ArticleTitle,
                           blogArticle.ArticleThrink,
                           blogArticle.ArticleBodySummary,
                           blogArticle.ArticleId,
                           blogArticle.CreateTime,
                           blogArticle.ArticleSortValue,
                           ArticleTop = blogArticle.ArticleSortValue == GetMaxArticleSortValue(),
                           CreateUser = tt.UserNikeName,
                           LableId = _db.BlogRelated.Where(t => t.RelatedArticleId.Equals(blogArticle.ArticleId)).Select(t => t.RelatedLableId)
                       };
            return new PageModel
            {
                RowCount = GetCount(expression),
                Data = list.ToList()
            };
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
