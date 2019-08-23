using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
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
        public HandleResult<PageModel> GetBlogArticlelist(string page, string limit, string searchstr, int lableId)
        {
            return new HandleResult<PageModel>
            {
                Data = _blogArticle.GetBlogArticleList(page, limit, searchstr, lableId)
            };
        }
        /// <summary>
        /// 添加/修改文章
        /// </summary>
        /// <param name="blogArticleDto"></param>
        /// <param name="onLineUserId"></param>
        /// <returns></returns>
        public HandleResult<bool> AddOrUpdateArticlelist(BlogArticleDto blogArticleDto, string onLineUserId)
        {
            var handleResult = new HandleResult<bool>();
            var blogArticle = Mapper.Map<BlogArticle>(blogArticleDto);
            //是否置顶
            if (blogArticleDto.ArticleTop)
            {
                int intMaxArticleSort = _blogArticle.GetMaxArticleSortValue();
                if (intMaxArticleSort != blogArticle.ArticleSortValue)
                    blogArticle.ArticleSortValue = intMaxArticleSort + 1;
            }
            else
                blogArticle.ArticleSortValue = 0;
            if (blogArticle.ArticleId == 0)//新增
            {
                blogArticle.CreateTime = DateTime.Now;
                blogArticle.CreateUserId = onLineUserId;
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
                        handleResult.Msg = "文章添加成功";
                    }
                    else
                    {
                        handleResult.Msg = "文章添加成功,文章标签添加失败!";
                        handleResult.Result = false;
                    }
                }
                else
                {
                    handleResult.Msg = "文章添加失败";
                    handleResult.Result = false;
                }
            }
            else
            {
                var blogArticleUpdate = _blogArticle.GetModels(t => t.ArticleId == blogArticle.ArticleId).First();
                blogArticleUpdate.ArticleTitle = blogArticle.ArticleTitle;
                blogArticleUpdate.ArticleThrink = blogArticle.ArticleThrink;
                blogArticleUpdate.ArticleBody = blogArticle.ArticleBody;
                blogArticleUpdate.ArticleBodySummary = blogArticle.ArticleBodySummary;
                blogArticleUpdate.ArticleSortValue = blogArticle.ArticleSortValue;
                blogArticleUpdate.EditTime = DateTime.Now;
                _blogArticle.Update(blogArticleUpdate);
                _blogRelated.Delete(t => t.RelatedArticleId == blogArticle.ArticleId);
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
                    handleResult.Msg = "文章修改成功";
                }
                else
                {
                    handleResult.Msg = "文章修改成功";
                    handleResult.Result = false;
                }
            }
            return handleResult;
        }
        /// <summary>
        /// 获取文章最大排序值
        /// </summary>
        /// <returns></returns>
        public HandleResult<int> GetMaxArticleSortValue()
        {
            return new HandleResult<int>
            {
                Data = _blogArticle.GetMaxArticleSortValue()
            };
        }
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public HandleResult<dynamic> GetArticleDetails(int articleId)
        {
            return new HandleResult<dynamic>
            {
                Data = _blogArticle.GetArticleDetails(articleId)
            };
        }
        /// <summary>
        /// 热门推荐文章
        /// </summary>
        /// <param name="bWeek">是否本周热门(为true时获取本周热门文章)</param>
        /// <returns></returns>
        public HandleResult<dynamic> GetPopularArticle(bool bWeek)
        {
            return new HandleResult<dynamic>
            {
                Data = _blogArticle.GetPopularArticle(bWeek)
            };
        }
    }
}
