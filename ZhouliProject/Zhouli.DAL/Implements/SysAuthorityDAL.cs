using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using Zhouli.Enum;

namespace Zhouli.DAL.Implements
{
    public class SysAuthorityDAL : BaseDAL<SysAuthority>, ISysAuthorityDAL
    {

        public SysAuthorityDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
        /// <summary>
        /// 获取角色的权限集合
        /// </summary>
        /// <param name="isAdmin">是否超级管理员</param>
        /// <param name="roles">角色集合</param>
        /// <param name="authorityType">权限类型</param>
        /// <returns></returns>
        public List<SysAuthority> GetSysAuthorities(Boolean isAdmin, List<SysRole> roles, AuthorityType authorityType)
        {
            StringBuilder builder = new StringBuilder(20);
            builder.AppendLine($@"SELECT SAT.authority_id 'AuthorityId',SAT.authority_type 'AuthorityType',SM.menu_id 'MenuId',SM.menu_name 'MenuName', 
                      SM.menu_icon 'MenuIcon',SM.menu_url 'MenuUrl',SM.menu_sort 'MenuSort',SM.parent_menu_id 'ParentMenuId'
                                FROM(
                                    SELECT SAT.*
                                    FROM sys_authority SAT WHERE delete_sign={(int)DeleteSign.Sing_Deleted} ) SAT");
            if (!isAdmin)
            {
                var roleList = roles.Select(t => t.RoleId).ToList();
                if (roleList.Count() == 0)
                    roleList.Add(Guid.Empty.ToString());
                builder.AppendLine($@"INNER JOIN (
                                SELECT srar.authority_id
                                FROM sys_role srol, sys_ra_related srar
                                WHERE srol.role_id = srar.role_id
                                    AND srol.role_id IN ('{string.Join("','", roleList)}')
                            ) t
                            ON t.authority_id = SAT.authority_id");
            }
            switch (authorityType)
            {
                case AuthorityType.Type_Menu:
                    builder.AppendLine($@"
                                INNER JOIN sys_am_related SAR ON SAR.authority_id = SAT.authority_id
                                LEFT JOIN sys_menu SM ON SAR.menu_id = SM.menu_id
                            WHERE authority_type = {(int)authorityType}");
                    break;
            }
            var list = _dbConnection.Query<SysAuthority, SysMenu, SysAuthority>(builder.ToString(), (a, b) =>
           {
               a.sysMenu = b;
               return a;
           }, splitOn: "MenuId").ToList();
            return list;

        }
    }
}
