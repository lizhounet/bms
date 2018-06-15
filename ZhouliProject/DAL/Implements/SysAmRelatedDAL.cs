using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysAmRelatedDAL : BaseDAL<SysAmRelated>, ISysAmRelatedDAL
    {
        private DapperContext dapper;
        private ZhouLiContext db;
        public SysAmRelatedDAL(DapperContext dapper, ZhouLiContext db) : base(db)
        {
            this.dapper = dapper;
            this.db = db;
        }

    }
}
