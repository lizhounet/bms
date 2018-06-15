using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace Zhouli.DAL.Implements
{
    public class SysAuthorityDAL : BaseDAL<SysAuthority>, ISysAuthorityDAL
    {
        private DapperContext dapper;
        private ZhouLiContext db;
        public SysAuthorityDAL(DapperContext dapper, ZhouLiContext db) : base(db)
        {
            this.dapper = dapper;
            this.db = db;
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
            builder.AppendLine(@"SELECT SAT.*, SM.*
                                FROM(
                                    SELECT SAT.*
                                    FROM Sys_Authority SAT");
            if (!isAdmin)
            {
                builder.AppendLine($@"INNER JOIN (
                                SELECT srar.AuthorityId
                                FROM Sys_Role srol, Sys_RaRelated srar
                                WHERE srol.RoleId = srar.RoleId
                                    AND srol.RoleId IN ('{string.Join("','", roles.Select(t => t.RoleId))})
                            ) t
                            ON t.AuthorityId = SAT.AuthorityId");
            }
            switch (authorityType)
            {
                case AuthorityType.Menu:
                    builder.AppendLine($@") SAT
                                INNER JOIN Sys_AmRelated SAR ON SAR.AuthorityId = SAT.AuthorityId
                                LEFT JOIN Sys_Menu SM ON SAR.MenuId = SM.MenuId
                            WHERE AuthorityType = {(int)authorityType}");
                    break;
            }
            using (var conn = dapper.GetConnection)
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
