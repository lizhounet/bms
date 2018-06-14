using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysAuthorityDAL : BaseDAL<SysAuthority>, ISysAuthorityDAL
    {
        private DapperContext dapper;
        public SysAuthorityDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }
        /// <summary>
        /// 获取角色的权限集合
        /// </summary>
        /// <param name="isAdmin">是否超级管理员</param>
        /// <param name="roles">角色集合</param>
        /// <param name="authorityType"></param>
        /// <returns></returns>
        public List<SysAuthority> GetSysAuthorities(Boolean isAdmin, List<SysRole> roles, AuthorityType authorityType= 0)
        {
           
            return null;
        }
    }
}
