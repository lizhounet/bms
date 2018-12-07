using Zhouli.DAL.Interface;
using Zhouli.MsSql.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUgrRelatedDAL : BaseDAL<SysUgrRelated>, ISysUgrRelatedDAL
    {
        public SysUgrRelatedDAL(DapperContext dapper, ZhouLiContext db) : base(dapper, db) { }
    }
}
