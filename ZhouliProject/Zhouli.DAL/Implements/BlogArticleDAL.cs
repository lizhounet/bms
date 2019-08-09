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

namespace Zhouli.DAL.Implements
{
    public class BlogArticleDAL : BaseDAL<BlogArticle>, IBlogArticleDAL
    {
        public BlogArticleDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration)
        {
        }
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        public PageModel GetBlogArticleList(string page, string limit, string searchstr)
        {
            Expression<Func<BlogArticle, bool>> expression = t => t.ArticleTitle.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted);
            var query = GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
               t => t.ArticleTitle.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
               && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            var list = from blogArticle in query
                       join user in _db.SysUser
                       on blogArticle.CreateUserId equals user.UserId
                       into temp
                       from tt in temp.DefaultIfEmpty()
                       select new
                       {
                           blogArticle.ArticleTitle,
                           blogArticle.ArticleThrink,
                           blogArticle.ArticleId,
                           blogArticle.CreateTime,
                           CreateUser = tt.UserNikeName
                       };
            return new PageModel
            {
                RowCount = GetCount(expression),
                Data = list.ToList()
            };
        }

        /// <summary>
        /// ��ȡ�����������ֵ
        /// </summary>
        /// <returns></returns>
        public int GetMaxArticleSortValue()
        {
            return _db.BlogArticle.Select(t => t.ArticleSortValue).DefaultIfEmpty().Max();
        }
    }
}
