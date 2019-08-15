using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.DAL.Implements
{
    public class BlogLableDAL : BaseDAL<BlogLable>, IBlogLableDAL
    {
        public BlogLableDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
