using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.Common.ResultModel;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;

namespace Zhouli.DAL.Interface
{
   public interface IBlogArticleDAL : IBaseDAL<BlogArticle>
    {
        /// <summary>
        /// 获取文章最大排序值
        /// </summary>
        /// <returns></returns>
        int GetMaxArticleSortValue();
        #region 获取分页文章列表
        /// <summary>
        /// 获取分页文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="searchstr"></param>
        /// <returns></returns>
        PageModel GetBlogArticleList(string page, string limit, string searchstr, int lableId);
        #endregion
        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        dynamic GetArticleDetails(int articleId);
        /// <summary>
        /// 热门推荐文章
        /// </summary>
        /// <param name="bWeek">是否本周热门(为true时获取本周热门文章)</param>
        /// <returns></returns>
        dynamic GetPopularArticle(bool bWeek);

    }
}
