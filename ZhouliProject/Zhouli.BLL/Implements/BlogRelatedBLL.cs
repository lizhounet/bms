using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
   public class BlogRelatedBLL : BaseBLL<BlogRelated>, IBlogRelatedBLL
    {
        private readonly IBlogRelatedDAL _blogRelated;
        /// <summary>
        /// 用于实例化父级，blogRelated
        /// <param name="blogRelated"></param>
        public BlogRelatedBLL(IBlogRelatedDAL blogRelated) : base(blogRelated)
        {
            this._blogRelated = blogRelated;
        }
    }
}
