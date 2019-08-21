using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class BlogArticleLikeBLL : BaseBLL<BlogArticleLike>, IBlogArticleLikeBLL
    {
        private readonly IBlogArticleLikeDAL _blogArticleLike;
        /// <summary>
        /// 用于实例化父级，blogArticleLike
        /// <param name="blogArticleLike"></param>
        public BlogArticleLikeBLL(IBlogArticleLikeDAL blogArticleLike) : base(blogArticleLike)
        {
            this._blogArticleLike = blogArticleLike;
        }
    }
}
