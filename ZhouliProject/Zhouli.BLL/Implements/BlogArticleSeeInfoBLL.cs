using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class BlogArticleSeeInfoBLL : BaseBLL<BlogArticleSeeInfo>, IBlogArticleSeeInfoBLL
    {
        private readonly IBlogArticleSeeInfoDAL blogArticleSeeInfo;
        /// <summary>
        /// 用于实例化父级，blogArticleSeeInfo
        /// <param name="blogArticleSeeInfo"></param>
        public BlogArticleSeeInfoBLL(IBlogArticleSeeInfoDAL blogArticleSeeInfo) : base(blogArticleSeeInfo)
        {
            this.blogArticleSeeInfo = blogArticleSeeInfo;
        }
    }
}
