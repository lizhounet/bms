using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
   public class BlogArticleSeeInfoDAL : BaseDAL<BlogArticleSeeInfo>, IBlogArticleSeeInfoDAL
    {
        public BlogArticleSeeInfoDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration)
        {
        }
    }
}
