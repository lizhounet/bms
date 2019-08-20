using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    public interface IBlogArticleBLL : IBaseBLL<BlogArticle>
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        MessageModel GetBlogArticlelist(string page, string limit, string searchstr);
        /// <summary>
        /// 添加/修改文章
        /// </summary>
        /// <param name="blogArticleDto"></param>
        /// <param name="OnLineUserId"></param>
        /// <returns></returns>
        MessageModel AddOrUpdateArticlelist(BlogArticleDto blogArticleDto, string OnLineUserId);
        /// <summary>
        /// 获取文章最大排序值
        /// </summary>
        /// <returns></returns>
        MessageModel GetMaxArticleSortValue();
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        HandleResult<dynamic> GetArticleDetails(int articleId);

    }
}
