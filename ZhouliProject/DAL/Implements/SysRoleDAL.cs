using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;

namespace Zhouli.DAL.Implements
{
    public class SysRoleDAL : BaseDAL<SysRole>, ISysRoleDAL
    {
        public SysRoleDAL(DapperContext dapper, ZhouLiContext db) : base(dapper, db)
        {
        }
        /// <summary>
        /// 为角色添加功能菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="menus"></param>
        /// <returns></returns>
        public bool AddRoleMenu(Guid RoleId, List<SysMenu> menus)
        {
            StringBuilder builderSql = new StringBuilder(20);
            using (var conn = dapper.GetConnection)
            {
                //var list = conn.Query<string>($@"SELECT AuthorityId
                //                      FROM Sys_RaRelated
                //                      WHERE RoleId ='{RoleId}')
                //                     AND AuthorityType={(int)ZhouLiEnum.Enum_AuthorityType.Type_Menu}");
                ////删除角色权限关联表数据
                //builderSql.AppendLine($@"DELETE FROM Sys_RaRelated
                //                        WHERE RaRelatedId IN (
                //                          SELECT T.RaRelatedId
                //                          FROM Sys_RaRelated T, Sys_Authority T1
                //                          WHERE T.AuthorityId = T1.AuthorityId
                //                           AND T.RoleId = '{RoleId}'
                //                           AND T1.AuthorityType = {(int)ZhouLiEnum.Enum_AuthorityType.Type_Menu}
                //                         )");
                //删除权限表对应数据
                //builderSql.AppendLine($@"DELETE FROM Sys_Authority
                //                    WHERE AuthorityId IN ('{string.Join("','", list)}')");

                //删除权限表数据
                //builderSql.AppendLine($"DELETE FROM Sys_Authority WHERE AuthorityId IN (SELECT AuthorityId FROM Sys_AmRelated WHERE MenuId IN('{string.Join("','", menus.Select(t => t.MenuId))}'))");
                //删除角色权限表数据
                builderSql.AppendLine($@"DELETE FROM Sys_RaRelated
                                        WHERE RaRelatedId IN (
                                          SELECT T.RaRelatedId
                                          FROM Sys_RaRelated T, Sys_Authority T1
                                          WHERE T.AuthorityId = T1.AuthorityId
                                           AND T.RoleId = '{RoleId}'
                                           AND T1.AuthorityType = {(int)ZhouLiEnum.Enum_AuthorityType.Type_Menu}
                                         )");
                var list = conn.Query<SysAmRelated>($"SELECT * FROM Sys_AmRelated WHERE MenuId IN('{string.Join("','", menus.Select(t => t.MenuId))}')");
                builderSql.AppendLine("INSERT INTO Sys_RaRelated(RoleId,AuthorityId)");
                foreach (var item in list)
                {
                    builderSql.AppendLine($"SELECT '{RoleId}','{item.AuthorityId}' UNION ALL");
                }
                var sql = builderSql.ToString().Remove(builderSql.ToString().LastIndexOf("UNION ALL"));
                return conn.Execute(sql) > 0;
            }
        }
        
    }
}
