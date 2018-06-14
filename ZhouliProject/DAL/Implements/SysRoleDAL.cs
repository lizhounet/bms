using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysRoleDAL : BaseDAL<SysRole>, ISysRoleDAL
    {
        private DapperContext dapper;
        public SysRoleDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }
    }
}
