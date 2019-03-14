using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.DAL.Implements
{
    public class BlogLableDAL : BaseDAL<BlogLable>, IBlogLableDAL
    {
        public BlogLableDAL(DapperContext dapper, ZhouLiContext db) : base(dapper, db)
        {
        }
    }
}
