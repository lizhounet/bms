using Zhouli.DAL.Interface;
using Zhouli.MsSql.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUserGroupDAL : BaseDAL<SysUserGroup>, ISysUserGroupDAL
    {
        public SysUserGroupDAL(DapperContext dapper, ZhouLiContext db) : base(dapper, db) { }
    }
}
