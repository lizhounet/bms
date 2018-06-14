using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUserGroupDAL : BaseDAL<SysUserGroup>, ISysUserGroupDAL
    {
        private DapperContext dapper;
        public SysUserGroupDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }
    }
}
