using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.DbEntity.Views;
using Zhouli.Dto.ModelDto;
using Zhouli.Enum;

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
        /// <param name="roleId"></param>
        /// <returns></returns>
        public HandleResult<bool> DelRole(IEnumerable<string> roleId)
        {
            var handleResult = new HandleResult<bool>();
            //查出需要删除的角色
            var sysRoles = sysRoleDAL.GetModels(t => roleId.Any(a => a.Equals(t.RoleId)));
            foreach (var item in sysRoles)
            {
                //逻辑删除角色
                item.DeleteSign = (int)DeleteSign.Sign_Undeleted;
                item.DeleteTime = DateTime.Now;
                sysRoleDAL.Update(item);
            }
            //最后一起提交数据库
            bool bResult = sysRoleDAL.SaveChanges();
            handleResult.Result = bResult;
            handleResult.Msg = bResult ? "删除成功" : "删除失败";
            return handleResult;
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
        public HandleResult<PageModel> GetRoleList(string page, string limit, string searchstr)
        {
            var query = sysRoleDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime,
                t => t.RoleName.Contains(searchstr) || string.IsNullOrEmpty(searchstr)
                && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted));
            return new HandleResult<PageModel>
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
        /// <param name="roleId"></param>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        public HandleResult<bool> AddRoleMenu(string roleId, List<SysMenuDto> menuDtos)
        {
            return new HandleResult<bool>
            {
                Result = sysRoleDAL.AddRoleMenu(roleId, Mapper.Map<List<SysMenu>>(menuDtos))
            };
        }
        #endregion
        #region 获取角色所分配的用户
        /// <summary>
        /// 获取角色所分配的用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public HandleResult<PageModel> GetRoleUserList(string roleId, string page, string limit, string searchstr)
        {
            var handleResult = new HandleResult<PageModel>();
            var PageModel = new PageModel();
            var urRelateds = sysUrRelatedDAL.GetModels(t => t.RoleId.Equals(roleId)).ToList();
            //构建条件
            Expression<Func<SysUser, bool>> expression = t => (string.IsNullOrEmpty(searchstr) || t.UserName.Contains(searchstr) ||
                t.UserNikeName.Contains(searchstr) ||
                t.UserPhone.Contains(searchstr) ||
                t.UserQq.Contains(searchstr) ||
                t.UserWx.Contains(searchstr) ||
                t.UserEmail.Contains(searchstr)) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted)
                && urRelateds.Any(x => x.UserId == t.UserId);
            PageModel.RowCount = sysUserDAL.GetCount(expression);
            var list = sysUserDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression).ToList();
            PageModel.Data = Mapper.Map<List<SysUserDto>>(list);
            handleResult.Data = PageModel;
            return handleResult;
        }
        #endregion
        #region 为角色分配用户
        /// <summary>
        /// 为角色分配用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public HandleResult<bool> AssignmentRoleUser(string roleId, List<string> userIds)
        {
            //删除用户角色关联表的角色ID
            var listSysUrRelateds = sysUrRelatedDAL.GetModels(t => t.RoleId.Equals(roleId));
            if (listSysUrRelateds.Count() > 0)
                sysUrRelatedDAL.Delete(listSysUrRelateds);
            foreach (var item in userIds)
            {
                sysUrRelatedDAL.Add(new SysUrRelated { UserId = item.ToString(), RoleId = roleId.ToString() });
            }
            bool bReuslt = sysUrRelatedDAL.SaveChanges();
            return new HandleResult<bool>
            {
                Msg = bReuslt ? "分配成功" : "分配失败",
                Result = bReuslt
            };
        }
        #endregion
        #region 取消用户角色
        /// <summary>
        /// 取消用户角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public HandleResult<bool> CancelUserAssignment(string roleId, List<string> userIds)
        {
            var melSysUrRelateds = sysUrRelatedDAL.GetModels(t => t.RoleId.Equals(roleId) && userIds.Any(a => a.Equals(t.UserId)));
            sysUrRelatedDAL.Delete(melSysUrRelateds);
            bool bReuslt = sysUrRelatedDAL.SaveChanges();
            return new HandleResult<bool>
            {
                Msg = bReuslt ? "取消授权成功" : "取消授权失败",
                Result = bReuslt
            };
        }
        #endregion
        #region 获取角色所分配的用户组
        /// <summary>
        /// 获取角色所分配的用户组
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public HandleResult<PageModel> GetRoleUserGroupList(string roleId, string page, string limit, string searchstr)
        {
            var handleResult = new HandleResult<PageModel>();
            var PageModel = new PageModel();
            var urRelateds = sysUgrRelatedDAL.GetModels(t => t.RoleId.Equals(roleId));
            Expression<Func<SysUserGroup, bool>> expression = t => (string.IsNullOrEmpty(searchstr) ||
                t.UserGroupName.Contains(searchstr)) && t.DeleteSign.Equals((int)DeleteSign.Sing_Deleted)
                && urRelateds.Any(x => x.UserGroupId == t.UserGroupId);
            PageModel.RowCount = sysUserGroupDAL.GetCount(expression);
            var list = sysUserGroupDAL.GetModelsByPage(Convert.ToInt32(limit), Convert.ToInt32(page), false, t => t.CreateTime, expression);
            PageModel.Data = Mapper.Map<List<SysUserGroupDto>>(list);
            handleResult.Data = PageModel;
            return handleResult;
        }
        #endregion
        #region 为角色分配用户组
        /// <summary>
        /// 为角色分配用户组
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userGroupIds"></param>
        /// <returns></returns>
        public HandleResult<bool> AssignmentRoleUserGroup(string roleId, List<string> userGroupIds)
        {
            var sysUgrRelateds = sysUgrRelatedDAL.GetModels(t => t.RoleId.Equals(roleId));
            sysUgrRelatedDAL.Delete(sysUgrRelateds);
            foreach (var item in userGroupIds)
            {
                sysUgrRelatedDAL.Add(new SysUgrRelated { UserGroupId = item.ToString(), RoleId = roleId.ToString() });
            }
            bool bReuslt = sysUgrRelatedDAL.SaveChanges();
            return new HandleResult<bool>
            {
                Msg = bReuslt ? "分配成功" : "分配失败",
                Result = bReuslt
            };
        }
        #endregion
        #region 取消用户组角色
        /// <summary>
        /// 取消用户组角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userGroupIds"></param>
        /// <returns></returns>
        public HandleResult<bool> CancelUserGroupAssignment(string roleId, List<string> userGroupIds)
        {
            var sysUgrRelateds = sysUgrRelatedDAL.GetModels(t => t.RoleId.Equals(roleId) && userGroupIds.Any(a => a.Equals(t.UserGroupId)));
            sysUgrRelatedDAL.Delete(sysUgrRelateds);
            bool bReuslt = sysUgrRelatedDAL.SaveChanges();
            return new HandleResult<bool>
            {
                Msg = bReuslt ? "取消授权成功" : "取消授权失败",
                Result = bReuslt
            };
        }
        #endregion
    }
}
