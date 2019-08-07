using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class BlogNavigationImgBLL : BaseBLL<BlogNavigationImg>, IBlogNavigationImgBLL
    {
        private readonly IBlogNavigationImgDAL blogNavigationImg;
        /// <summary>
        /// 用于实例化父级，blogNavigationImg
        /// <param name="blogNavigationImg"></param>
        public BlogNavigationImgBLL(IBlogNavigationImgDAL blogNavigationImg) : base(blogNavigationImg)
        {
            this.blogNavigationImg = blogNavigationImg;
        }
    }
}
