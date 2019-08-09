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
        private readonly ISysUserDAL _sysUserDAL;
        /// <summary>
        /// 用于实例化父级，blogArticle
        /// <param name="blogArticle"></param>
        public BlogArticleBLL(IBlogArticleDAL blogArticle, IBlogRelatedDAL blogRelated, ISysUserDAL sysUserDAL) : base(blogArticle)
        {
            this._blogArticle = blogArticle;
            this._blogRelated = blogRelated;
            this._sysUserDAL = sysUserDAL;
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
            return new MessageModel
            {
                Data = _blogArticle.GetBlogArticleList(page, limit, searchstr)
            };
        }
        /// <summary>
        /// 添加/修改文章
        /// </summary>
        /// <param name="blogArticleDto"></param>
        /// <returns></returns>
        public MessageModel AddOrUpdateArticlelist(BlogArticleDto blogArticleDto, string OnLineUserId)
        {
            var megModel = new MessageModel();
            var blogArticle = Mapper.Map<BlogArticle>(blogArticleDto);
            //是否置顶
            if (blogArticleDto.ArticleTop)
            {
                blogArticle.ArticleSortValue = _blogArticle.GetMaxArticleSortValue() + 1;
            }
            blogArticle.CreateTime = DateTime.Now;
            blogArticle.CreateUserId = OnLineUserId;
            //添加文章
            _blogArticle.Add(blogArticle);
            if (_blogArticle.SaveChanges())
            {
                //添加文章标签关联表
                foreach (var lableId in blogArticleDto.LableId)
                {
                    _blogRelated.Add(new BlogRelated
                    {
                        RelatedArticleId = blogArticle.ArticleId,
                        RelatedLableId = lableId
                    });
                }
                if (_blogRelated.SaveChanges())
                {
                    megModel.Message = "文章添加成功";
                }
                else
                {
                    megModel.Message = "文章添加成功,文章标签添加失败!";
                    megModel.Result = false;
                }
            }
            else
            {
                megModel.Message = "文章添加失败";
                megModel.Result = false;
            }

            return megModel;
        }
    }
}
