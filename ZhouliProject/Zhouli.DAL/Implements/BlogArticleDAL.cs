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
using Dapper;

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
                LableInfo = _db.BlogLable.Where(s => _db.BlogRelated
                          .Where(ss => ss.RelatedArticleId.Equals(articleId))
                          .Select(tt => tt.RelatedLableId).Contains(s.LableId))
                            .Select(q => new { q.LableName, q.LableId }).ToArray(),
                ArticleBrowsingNum = _db.BlogArticleBrowsing.Count(b => b.ArticleId == articleId),
                ArticleCommentNum = 0,
                ArticleLikeNum = _db.BlogArticleLike.Count(b => b.ArticleId == articleId),
                LastArticle = _db.BlogArticle.Where(b => b.ArticleId < articleId).OrderByDescending(b => b.ArticleId).Select(s => new { s.ArticleId, s.ArticleTitle }).FirstOrDefault(),
                NextArticle = _db.BlogArticle.Where(b => b.ArticleId > articleId).OrderBy(b => b.ArticleId).Select(s => new { s.ArticleId, s.ArticleTitle }).FirstOrDefault()
            }).First();
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public PageModel GetBlogArticleList(string page, string limit, string searchstr, int lableId)
        {
            Expression<Func<BlogArticle, bool>> expression =
                t => t.ArticleTitle.Contains(searchstr) ||
            string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted) &&
                ((_db.BlogRelated.Where(r => r.RelatedLableId == lableId).Select(s => s.RelatedArticleId).Contains(t.ArticleId))
                || lableId == 0);
            var query = GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression);
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
                           LableInfo = _db.BlogLable.Where(s => _db.BlogRelated
                           .Where(t => t.RelatedArticleId.Equals(blogArticle.ArticleId))
                           .Select(t => t.RelatedLableId).Contains(s.LableId))
                           .Select(q => new { q.LableName, q.LableId }),
                           ArticleBrowsingNum = _db.BlogArticleBrowsing.Count(b => b.ArticleId == blogArticle.ArticleId),
                           ArticleCommentNum = 0,
                           ArticleLikeNum = _db.BlogArticleLike.Count(b => b.ArticleId == blogArticle.ArticleId)
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
        /// <summary>
        /// 热门推荐文章
        /// </summary>
        /// <param name="bWeek">是否本周热门(为true时获取本周热门文章)</param>
        /// <returns></returns>
        public dynamic GetPopularArticle(bool bWeek)
        {
            string strWhere = "";
            if (bWeek)
            {
                strWhere = $"AND BA.create_time BETWEEN '{DateTime.Now.GetTimeStartByType("Week")}' AND '{DateTime.Now.GetTimeEndByType("Week")}'";
            }
            return _dbConnection.Query($@"SELECT BB.ArticleId, BB.ArticleBrowsingNum, BA.article_title 'ArticleTitle',BA.article_thrink 'ArticleThrink'
                                FROM (
	                                SELECT ArticleId, ArticleBrowsingNum
	                                FROM (
		                                SELECT ROW_NUMBER() OVER (ORDER BY COUNT(1) DESC)  'row', BA.article_id 'ArticleId', COUNT(1) 'ArticleBrowsingNum'
		                                FROM blog_article_browsing BA
                                        WHERE 1=1  {strWhere}
		                                GROUP BY BA.article_id
	                                ) T
	                                WHERE T.row < 6
                                ) BB
	                                LEFT JOIN blog_article BA ON BB.ArticleId = BA.article_id");
        }
    }
}
