using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysRoleDAL : BaseDAL<SysRole>, ISysRoleDAL
    {
        public SysRoleDAL(DapperContext dapper, ZhouLiContext db) : base(dapper, db)
        {
        }
    }
}
