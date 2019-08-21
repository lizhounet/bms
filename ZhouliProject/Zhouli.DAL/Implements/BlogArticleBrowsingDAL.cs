using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System.Data;

namespace Zhouli.DAL.Implements
{
   public class BlogArticleBrowsingDAL : BaseDAL<BlogArticleBrowsing>, IBlogArticleBrowsingDAL
    {
        public BlogArticleBrowsingDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
