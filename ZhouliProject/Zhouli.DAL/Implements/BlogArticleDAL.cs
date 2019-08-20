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
using Zhouli.Common.ResultModel;

namespace Zhouli.DAL.Implements
{
    public class BlogArticleDAL : BaseDAL<BlogArticle>, IBlogArticleDAL
    {
        public BlogArticleDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public dynamic GetArticleDetails(int articleId)
        {
            return GetModels(t => t.ArticleId == articleId).Select(t => new
            {
                t.ArticleId,
                t.ArticleTitle,
                t.CreateTime,
                t.ArticleBody,
                CreateUser = _db.SysUser.Where(s => s.UserId.Equals(t.CreateUserId)).Select(s => s.UserNikeName).First(),
                LableName = _db.BlogLable.Where(s => _db.BlogRelated
                          .Where(ss => ss.RelatedArticleId.Equals(articleId))
                          .Select(tt => tt.RelatedLableId).Contains(s.LableId))
                            .Select(q => q.LableName).ToArray(),
                ArticleBrowsingNum = _db.BlogArticleSeeInfo.Where(tt => tt.ArticleSeeInfoArticleId == articleId).Sum(tt => tt.ArticleSeeInfoArticleBrowsingNum),
                ArticleCommentNum = _db.BlogArticleSeeInfo.Where(tt => tt.ArticleSeeInfoArticleId == articleId).Sum(tt => tt.ArticleSeeInfoArticleCommentNum),
                ArticleLikeNum = _db.BlogArticleSeeInfo.Where(tt => tt.ArticleSeeInfoArticleId == articleId).Sum(tt => tt.ArticleSeeInfoArticleLikeNum)
            }).First();
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
                           LableId = _db.BlogRelated.Where(t => t.RelatedArticleId.Equals(blogArticle.ArticleId)).Select(t => t.RelatedLableId),
                           LableName = _db.BlogLable.Where(s => _db.BlogRelated
                           .Where(t => t.RelatedArticleId.Equals(blogArticle.ArticleId))
                           .Select(t => t.RelatedLableId).Contains(s.LableId))
                           .Select(q => q.LableName),
                           ArticleBrowsingNum = _db.BlogArticleSeeInfo.Where(t => t.ArticleSeeInfoArticleId == blogArticle.ArticleId).Sum(t => t.ArticleSeeInfoArticleBrowsingNum),
                           ArticleCommentNum = _db.BlogArticleSeeInfo.Where(t => t.ArticleSeeInfoArticleId == blogArticle.ArticleId).Sum(t => t.ArticleSeeInfoArticleCommentNum),
                           ArticleLikeNum = _db.BlogArticleSeeInfo.Where(t => t.ArticleSeeInfoArticleId == blogArticle.ArticleId).Sum(t => t.ArticleSeeInfoArticleLikeNum)
                       };
            return new PageModel
            {
                RowCount = GetCount(expression),
                Data = list.ToList(),
                PageIndex = Convert.ToInt32(page),
                PageSize = Convert.ToInt32(limit)
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
