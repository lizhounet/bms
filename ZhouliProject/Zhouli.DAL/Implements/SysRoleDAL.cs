using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Zhouli.DAL.Implements
{
    public class SysRoleDAL : BaseDAL<SysRole>, ISysRoleDAL
    {
        public SysRoleDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
        /// <summary>
        /// 为角色添加功能菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public bool AddRoleMenu(string roleId, List<SysMenu> menus)
        {
            StringBuilder builderSql = new StringBuilder(20);
            //var list = conn.Query<string>($@"SELECT AuthorityId
            //                      FROM Sys_RaRelated
            //                      WHERE RoleId ='{RoleId}')
            //                     AND AuthorityType={(int)AuthorityType.Type_Menu}");
            ////删除角色权限关联表数据
            //builderSql.AppendLine($@"DELETE FROM Sys_RaRelated
            //                        WHERE RaRelatedId IN (
            //                          SELECT T.RaRelatedId
            //                          FROM Sys_RaRelated T, Sys_Authority T1
            //                          WHERE T.AuthorityId = T1.AuthorityId
            //                           AND T.RoleId = '{RoleId}'
            //                           AND T1.AuthorityType = {(int)AuthorityType.Type_Menu}
            //                         )");
            //删除权限表对应数据
            //builderSql.AppendLine($@"DELETE FROM Sys_Authority
            //                    WHERE AuthorityId IN ('{string.Join("','", list)}')");

            //删除权限表数据
            //builderSql.AppendLine($"DELETE FROM Sys_Authority WHERE AuthorityId IN (SELECT AuthorityId FROM Sys_AmRelated WHERE MenuId IN('{string.Join("','", menus.Select(t => t.MenuId))}'))");
            //删除角色权限表数据
            builderSql.AppendLine($@"DELETE FROM Sys_RaRelated
                                        WHERE RoleId = '{roleId}' ;");
            var list = _dbConnection.Query<SysAmRelated>($"SELECT * FROM Sys_AmRelated WHERE MenuId IN('{string.Join("','", menus.Select(t => t.MenuId))}')");
            builderSql.AppendLine("INSERT INTO Sys_RaRelated(RaRelatedId,RoleId,AuthorityId)");
            foreach (var item in list)
            {
                builderSql.AppendLine($"SELECT '{Guid.NewGuid().ToString()}','{roleId}','{item.AuthorityId}' UNION ALL");
            }
            var sql = builderSql.ToString().Remove(builderSql.ToString().LastIndexOf("UNION ALL"));
            return _dbConnection.Execute(sql) > 0;
        }

    }
}
