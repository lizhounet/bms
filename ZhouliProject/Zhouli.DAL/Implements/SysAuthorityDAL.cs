using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Zhouli.DAL.Implements
{
    public class SysAuthorityDAL : BaseDAL<SysAuthority>, ISysAuthorityDAL
    {

        public SysAuthorityDAL(ZhouLiContext db, IConfiguration configuration) : base(db, configuration)
        {
        }
        /// <summary>
        /// 获取角色的权限集合
        /// </summary>
        /// <param name="isAdmin">是否超级管理员</param>
        /// <param name="roles">角色集合</param>
        /// <param name="authorityType">权限类型</param>
        /// <returns></returns>
        public List<SysAuthority> GetSysAuthorities(Boolean isAdmin, List<SysRole> roles, ZhouLiEnum.Enum_AuthorityType authorityType)
        {
            StringBuilder builder = new StringBuilder(20);
            builder.AppendLine($@"SELECT SAT.*, SM.*
                                FROM(
                                    SELECT SAT.*
                                    FROM Sys_Authority SAT WHERE DeleteSign={(int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted} ) SAT");
            if (!isAdmin)
            {
                var roleList = roles.Select(t => t.RoleId).ToList();
                if (roleList.Count() == 0)
                    roleList.Add(Guid.Empty.ToString());
                builder.AppendLine($@"INNER JOIN (
                                SELECT srar.AuthorityId
                                FROM Sys_Role srol, Sys_RaRelated srar
                                WHERE srol.RoleId = srar.RoleId
                                    AND srol.RoleId IN ('{string.Join("','", roleList)}')
                            ) t
                            ON t.AuthorityId = SAT.AuthorityId");
            }
            switch (authorityType)
            {
                case ZhouLiEnum.Enum_AuthorityType.Type_Menu:
                    builder.AppendLine($@"
                                INNER JOIN Sys_AmRelated SAR ON SAR.AuthorityId = SAT.AuthorityId
                                LEFT JOIN Sys_Menu SM ON SAR.MenuId = SM.MenuId
                            WHERE AuthorityType = {(int)authorityType}");
                    break;
            }
            using (var conn = Connection)
            {
                var list = conn.Query<SysAuthority, SysMenu, SysAuthority>(builder.ToString(), (a, b) =>
               {
                   a.sysMenu = b;
                   return a;
               }, splitOn: "MenuId").ToList();
                return list;
            }

        }
    }
}
