using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class BlogArticleBrowsingBLL : BaseBLL<BlogArticleBrowsing>, IBlogArticleBrowsingBLL
    {
        private readonly IBlogArticleBrowsingDAL _blogArticleBrowsing;
        /// <summary>
        /// 用于实例化父级，blogArticleBrowsing
        /// <param name="blogArticleBrowsing"></param>
        public BlogArticleBrowsingBLL(IBlogArticleBrowsingDAL blogArticleBrowsing) : base(blogArticleBrowsing)
        {
            this._blogArticleBrowsing = blogArticleBrowsing;
        }
    }
}
