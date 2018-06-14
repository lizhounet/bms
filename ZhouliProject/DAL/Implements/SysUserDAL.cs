using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Zhouli.DAL.Implements
{
    public class SysUserDAL : BaseDAL<SysUser>, ISysUserDAL
    {
        private DapperContext dapper;
        public SysUserDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }
        #region 设置用户的用户组,角色信息
        /// <summary>
        /// 设置用户的用户组,角色信息
        /// </summary>
        /// <returns></returns>
        public SysUser GetLoginSysUser(SysUser user)
        {
            return null;
        }
        #endregion
    }
}
