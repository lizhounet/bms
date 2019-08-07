using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;

namespace Zhouli.BLL.Implements
{
    public class BlogArticleBLL : BaseBLL<BlogArticle>, IBlogArticleBLL
    {
        private readonly IBlogArticleDAL _blogArticle;
        /// <summary>
        /// 用于实例化父级，blogArticle
        /// <param name="blogArticle"></param>
        public BlogArticleBLL(IBlogArticleDAL blogArticle) : base(blogArticle)
        {
            this._blogArticle = blogArticle;
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page">当前页数</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public MessageModel GetBlogArticlelist(string page, string limit, string searchstr)
        {
            var query = _blogArticle.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
               t => t.ArticleTitle.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
               && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            return new MessageModel
            {
                Data = new PageModel
                {
                    RowCount = query.Count(),
                    Data = query.ToList()
                }
            };
        }
        /// <summary>
        /// 添加/修改文章
        /// </summary>
        /// <param name="blogArticleDto"></param>
        /// <returns></returns>
        public MessageModel AddOrUpdateArticlelist(BlogArticleDto blogArticleDto)
        {

            return new MessageModel
            {

            };
        }
    }
}
