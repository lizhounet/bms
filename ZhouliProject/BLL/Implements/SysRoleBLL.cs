using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;

namespace Zhouli.BLL.Implements
{
    public class SysRoleBLL : BaseBLL<SysRole>, ISysRoleBLL
    {
        private readonly ISysRoleDAL sysRoleDAL;
        private readonly ISysUserDAL sysUserDAL;
        private readonly ISysUrRelatedDAL sysUrRelatedDAL;
        private readonly ISysUserGroupDAL sysUserGroupDAL;
        private readonly ISysUgrRelatedDAL sysUgrRelatedDAL;
        /// <summary>
        /// 用于实例化父级，sysRoleDAL
        /// </summary>
        /// <param name="sysRoleDAL"></param>
        public SysRoleBLL(ISysRoleDAL sysRoleDAL,
            ISysUserDAL sysUserDAL,
            ISysUrRelatedDAL sysUrRelatedDAL,
            ISysUserGroupDAL sysUserGroupDAL,
            ISysUgrRelatedDAL sysUgrRelatedDAL) : base(sysRoleDAL)
        {
            this.sysRoleDAL = sysRoleDAL;
            this.sysUserDAL = sysUserDAL;
            this.sysUrRelatedDAL = sysUrRelatedDAL;
            this.sysUserGroupDAL = sysUserGroupDAL;
            this.sysUgrRelatedDAL = sysUgrRelatedDAL;
        }
        #region 删除角色(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public MessageModel DelRole(IEnumerable<Guid> RoleId)
        {
            var model = new MessageModel();
            var sysRoles = sysRoleDAL.GetModels(t => RoleId.Any(a => a.Equals(t.RoleId)));
            foreach (var item in sysRoles)
            {
                item.DeleteSign = (int)ZhouLiEnum.Enum_DeleteSign.Sign_Undeleted;
                item.DeleteTime = DateTime.Now;
                sysRoleDAL.Update(item);
            }
            bool bResult = sysRoleDAL.SaveChanges();
            model.Result = bResult;
            model.Message = bResult ? "删除成功" : "删除失败";
            return model;
        }
        #endregion
        #region 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        public MessageModel GetRoleList(string page, string limit, string searchstr)
        {
            var query = sysRoleDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
                t => t.RoleName.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted));
            return new MessageModel
            {
                Data = new PageModel
                {
                    RowCount = query.Count(),
                    Data = Mapper.Map<List<SysRole>>(query.ToList())
                }
            };
        }
        #endregion
        #region 为角色添加功能菜单
        /// <summary>
        /// 为角色添加功能菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        public MessageModel AddRoleMenu(Guid RoleId, List<SysMenuDto> menuDtos)
        {
            return new MessageModel
            {
                Result = sysRoleDAL.AddRoleMenu(RoleId, Mapper.Map<List<SysMenu>>(menuDtos))
            };
        }
        #endregion
        #region 获取角色所分配的用户
        /// <summary>
        /// 获取角色所分配的用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public MessageModel GetRoleUserList(Guid RoleId, string page, string limit, string searchstr)
        {
            var messageModel = new MessageModel();
            var PageModel = new PageModel();
            var urRelateds = sysUrRelatedDAL.GetModels(t => t.RoleId.Equals(RoleId)).ToList();
            Expression<Func<SysUser, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserName.Contains(searchstr) ||
                t.UserNikeName.Contains(searchstr) ||
                t.UserPhone.Contains(searchstr) ||
                t.UserQq.Contains(searchstr) ||
                t.UserWx.Contains(searchstr) ||
                t.UserEmail.Contains(searchstr)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted)
                && urRelateds.Any(x => x.UserId == t.UserId);
            PageModel.RowCount = sysUserDAL.GetCount(expression);
            //int iBeginRow = Convert.ToInt32(limit) * (Convert.ToInt32(page) - 1) + 1, iEndRow = Convert.ToInt32(page) * Convert.ToInt32(limit);
            //var list = sysUserDAL.SqlQuery<SysUserDto>($@"
            //                               SELECT *
            //                    FROM (
            //                        SELECT ROW_NUMBER() OVER (ORDER BY T1.CREATETIME DESC) AS RN, T1.*
            //                        FROM Sys_User T1
            //                        WHERE (T1.UserNikeName LIKE '%{searchstr}%'
            //                                OR T1.UserPhone LIKE '%{searchstr}%'
            //                                OR T1.UserQq LIKE '%{searchstr}%'
            //                                OR T1.UserWx LIKE '%{searchstr}%'
            //                                OR T1.UserEmail LIKE '%{searchstr}%')
            //                            AND T1.DeleteSign = 1
            //                            AND T1.UserId IN('{String.Join("','", urRelateds.Count == 0 ? new Guid[] { Guid.Empty } : urRelateds.Select(t => t.UserId))}')
            //                    ) T
            //                    WHERE RN BETWEEN {iBeginRow} AND {iEndRow}");
            var list = sysUserDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression).ToList();
            PageModel.Data = Mapper.Map<List<SysUserDto>>(list);
            messageModel.Data = PageModel;
            return messageModel;
        }
        #endregion
        #region 为角色分配用户
        /// <summary>
        /// 为角色分配用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        /// <returns></returns>
        public MessageModel AssignmentRoleUser(Guid RoleId, List<Guid> UserIds)
        {
            //StringBuilder builderDelSql = new StringBuilder(20);
            //builderDelSql.AppendLine($"DELETE FROM Sys_UrRelated WHERE RoleId = '{RoleId}'");
            //builderDelSql.AppendLine("INSERT INTO Sys_UrRelated(UserId,RoleId) ");
            //foreach (var item in UserIds)
            //{
            //    builderDelSql.AppendLine($"SELECT '{item}', '{RoleId}' UNION ALL");
            //}
            //var sql = builderDelSql.ToString().Remove(builderDelSql.ToString().LastIndexOf("UNION ALL"));
            //bool bReuslt = sysRoleDAL.ExecuteSql(sql) > 0;
            //删除用户角色关联表的角色ID
            var listSysUrRelateds = sysUrRelatedDAL.GetModels(t => t.RoleId.Equals(RoleId));
            if (listSysUrRelateds.Count() > 0)
                sysUrRelatedDAL.Delete(listSysUrRelateds);
            foreach (var item in UserIds)
            {
                sysUrRelatedDAL.Add(new SysUrRelated { UserId = item, RoleId = RoleId });
            }
            bool bReuslt = sysUrRelatedDAL.SaveChanges();
            return new MessageModel
            {
                Message = bReuslt ? "分配成功" : "分配失败",
                Result = bReuslt
            };
        }
        #endregion
        #region 取消用户角色
        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserIds"></param>
        /// <returns></returns>
        public MessageModel CancelUserAssignment(Guid RoleId, List<Guid> UserIds)
        {
            //bool bReuslt = sysRoleDAL.ExecuteSql($"DELETE FROM Sys_UrRelated WHERE RoleId='{RoleId}' " +
            //    $"AND UserId IN('{String.Join("','", UserIds)}')") > 0;
            var melSysUrRelateds = sysUrRelatedDAL.GetModels(t => t.RoleId.Equals(RoleId) && UserIds.Any(a => a.Equals(t.UserId)));
            sysUrRelatedDAL.Delete(melSysUrRelateds);
            bool bReuslt = sysUrRelatedDAL.SaveChanges();
            return new MessageModel
            {
                Message = bReuslt ? "取消授权成功" : "取消授权失败",
                Result = bReuslt
            };
        }
        #endregion
        #region 获取角色所分配的用户组
        /// <summary>
        /// 获取角色所分配的用户组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public MessageModel GetRoleUserGroupList(Guid RoleId, string page, string limit, string searchstr)
        {
            var messageModel = new MessageModel();
            var PageModel = new PageModel();
            // var urRelateds = sysUrRelatedDAL.SqlQuery<SysUgrRelated>($"SELECT * FROM Sys_UgrRelated  WHERE RoleId='{RoleId}'").ToList();
            var urRelateds = sysUgrRelatedDAL.GetModels(t => t.RoleId.Equals(RoleId));
            Expression<Func<SysUserGroup, bool>> expression = t => (string.IsNullOrEmpty(searchstr) ||
                t.UserGroupName.Contains(searchstr)) && t.DeleteSign.Equals((int)ZhouLiEnum.Enum_DeleteSign.Sing_Deleted)
                && urRelateds.Any(x => x.UserGroupId == t.UserGroupId);
            PageModel.RowCount = sysUserGroupDAL.GetCount(expression);
            //int iBeginRow = Convert.ToInt32(limit) * (Convert.ToInt32(page) - 1) + 1, iEndRow = Convert.ToInt32(page) * Convert.ToInt32(limit);
            //var list = sysUserDAL.SqlQuery<SysUserGroupDto>($@"
            //                               SELECT *
            //                    FROM (
            //                        SELECT ROW_NUMBER() OVER (ORDER BY T1.CREATETIME DESC) AS RN, T1.*
            //                        FROM Sys_UserGroup T1
            //                        WHERE T1.UserGroupName LIKE '%{searchstr}%'
            //                            AND T1.DeleteSign = 1
            //                            AND T1.UserGroupId IN('{String.Join("','", urRelateds.Count == 0 ? new Guid[] { Guid.Empty } : urRelateds.Select(t => t.UserGroupId))}')
            //                    ) T
            //                    WHERE RN BETWEEN {iBeginRow} AND {iEndRow}");
            var list = sysUserGroupDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression);
            PageModel.Data = Mapper.Map<List<SysUserGroupDto>>(list);
            messageModel.Data = PageModel;
            return messageModel;
        }
        #endregion
        #region 为角色分配用户组
        /// <summary>
        /// 为角色分配用户组
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserGroupIds"></param>
        /// <returns></returns>
        public MessageModel AssignmentRoleUserGroup(Guid RoleId, List<Guid> UserGroupIds)
        {
            //StringBuilder builderDelSql = new StringBuilder(20);
            //builderDelSql.AppendLine($"DELETE FROM Sys_UgrRelated WHERE RoleId = '{RoleId}'");

            //builderDelSql.AppendLine("INSERT INTO Sys_UgrRelated(UserGroupId,RoleId) ");
            //foreach (var item in UserGroupIds)
            //{
            //    builderDelSql.AppendLine($"SELECT '{item}', '{RoleId}' UNION ALL");
            //}
            //var sql = builderDelSql.ToString().Remove(builderDelSql.ToString().LastIndexOf("UNION ALL"));
            //bool bReuslt = sysRoleDAL.ExecuteSql(sql) > 0;
            var sysUgrRelateds = sysUgrRelatedDAL.GetModels(t => t.RoleId.Equals(RoleId));
            sysUgrRelatedDAL.Delete(sysUgrRelateds);
            foreach (var item in UserGroupIds)
            {
                sysUgrRelatedDAL.Add(new SysUgrRelated { UserGroupId = item, RoleId = RoleId });
            }
            bool bReuslt = sysUgrRelatedDAL.SaveChanges();
            return new MessageModel
            {
                Message = bReuslt ? "分配成功" : "分配失败",
                Result = bReuslt
            };
        }
        #endregion
        #region 取消用户组角色
        /// <summary>
        /// 取消用户组角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="UserGroupIds"></param>
        /// <returns></returns>
        public MessageModel CancelUserGroupAssignment(Guid RoleId, List<Guid> UserGroupIds)
        {
            //bool bReuslt = sysRoleDAL.ExecuteSql($"DELETE FROM Sys_UgrRelated WHERE RoleId='{RoleId}' " +
            //  $"AND UserGroupId IN('{String.Join("','", UserGroupIds)}')") > 0;
            var sysUgrRelateds = sysUgrRelatedDAL.GetModels(t => t.RoleId.Equals(RoleId) && UserGroupIds.Any(a => a.Equals(t.UserGroupId)));
            sysUgrRelatedDAL.Delete(sysUgrRelateds);
            bool bReuslt = sysUgrRelatedDAL.SaveChanges();
            return new MessageModel
            {
                Message = bReuslt ? "取消授权成功" : "取消授权失败",
                Result = bReuslt
            };
        }
        #endregion
    }
}
