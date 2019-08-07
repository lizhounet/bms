using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.DAL.Interface
{
   public interface IBlogArticleDAL : IBaseDAL<BlogArticle>
    {
        /// <summary>
        /// 获取文章最大排序值
        /// </summary>
        /// <returns></returns>
        int GetMaxArticleSortValue();
    }
}
