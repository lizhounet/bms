using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
   public class BlogRelatedDAL : BaseDAL<BlogRelated>, IBlogRelatedDAL
    {
        public BlogRelatedDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
