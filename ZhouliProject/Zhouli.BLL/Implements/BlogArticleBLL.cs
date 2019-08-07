using AutoMapper;
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
        private readonly IBlogRelatedDAL _blogRelated;
        /// <summary>
        /// 用于实例化父级，blogArticle
        /// <param name="blogArticle"></param>
        public BlogArticleBLL(IBlogArticleDAL blogArticle, IBlogRelatedDAL blogRelated) : base(blogArticle)
        {
            this._blogArticle = blogArticle;
            this._blogRelated = blogRelated;
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
            var blogArticle = Mapper.Map<BlogArticle>(blogArticleDto);
            //是否置顶
            if (blogArticleDto.ArticleTop)
            {
                blogArticle.ArticleSortValue = _blogArticle.GetMaxArticleSortValue() + 1;
            }
            blogArticle.CreateTime = DateTime.Now;
            //添加文章
            _blogArticle.Add(blogArticle);
            _blogArticle.SaveChanges();
            //添加文章标签关联表
            foreach (var lableId in blogArticleDto.LableId)
            {
                _blogRelated.Add(new BlogRelated
                {
                    RelatedArticleId = blogArticle.ArticleId,
                    RelatedLableId = lableId
                });
            }
            _blogRelated.SaveChanges();
            return new MessageModel
            {

            };
        }
    }
}
