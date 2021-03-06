using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
   public class BlogNavigationImgDAL : BaseDAL<BlogNavigationImg>, IBlogNavigationImgDAL
    {
        public BlogNavigationImgDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
