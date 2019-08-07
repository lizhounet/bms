using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class BlogArticleBLL : BaseBLL<BlogArticle>, IBlogArticleBLL
    {
        private readonly IBlogArticleDAL blogArticle;
        /// <summary>
        /// 用于实例化父级，blogArticle
        /// <param name="blogArticle"></param>
        public BlogArticleBLL(IBlogArticleDAL blogArticle) : base(blogArticle)
        {
            this.blogArticle = blogArticle;
        }
    }
}
