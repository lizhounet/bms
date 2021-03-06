﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;
using Zhouli.BLL.Interface;
using Zhouli.Common.ResultModel;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using Zhouli.Dto.ModelDto;
using Zhouli.Enum;

namespace Zhouli.BLL.Implements
{
    /// <summary>
    /// 菜单表Service接口
    /// </summary>
    public class SysMenuBLL : BaseBLL<SysMenu>, ISysMenuBLL
    {
        private List<SysMenuDto> listMenuDtos;
        private readonly ISysMenuDAL sysMenuDAL;
        private readonly ISysAuthorityBLL sysAuthorityBLL;
        private readonly ISysAmRelatedDAL sysAmRelatedDAL;
        /// <summary>
        /// 用于实例化父级，sysMenuDAL
        /// </summary>
        /// <param name="sysMenuDAL"></param>
        public SysMenuBLL(ISysMenuDAL sysMenuDAL, ISysAuthorityBLL sysAuthorityBLL, ISysAmRelatedDAL sysAmRelatedDAL) : base(sysMenuDAL)
        {
            this.sysMenuDAL = sysMenuDAL;
            this.sysAuthorityBLL = sysAuthorityBLL;
            this.sysAmRelatedDAL = sysAmRelatedDAL;
        }
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public HandleResult<List<SysMenuDto>> GetMenusBy(SysUser user)
        {
            var listMenuDto = new List<SysMenuDto>();
            listMenuDtos = Mapper.Map<List<SysMenuDto>>(((List<SysAuthority>)(sysAuthorityBLL.GetSysAuthorities(user, AuthorityType.Type_Menu).Data)).Select(t => t.sysMenu).ToList());
            //找出所有一级菜单
            listMenuDto.AddRange(listMenuDtos.Where(t => Guid.Empty.ToString().Equals(t.ParentMenuId)).OrderByDescending(t => t.MenuSort).ThenBy(t => t.CreateTime));
            foreach (var item in listMenuDto)
            {
                item.children = GetMenuChildren(item.MenuId);
            }
            return new HandleResult<List<SysMenuDto>>
            {
                Data = listMenuDto
            };
        }
        /// <summary>
        /// 递归获取子集菜单
        /// </summary>
        /// <param name="ParentMenuId"></param>
        /// <returns></returns>
        private List<SysMenuDto> GetMenuChildren(string ParentMenuId)
        {
            var listMenuDto = listMenuDtos.Where(t => t.ParentMenuId.Equals(ParentMenuId)).OrderByDescending(t => t.MenuSort).ThenBy(t => t.CreateTime).ToList();
            foreach (var item in listMenuDto)
            {
                item.children = GetMenuChildren(item.MenuId);
            }

            return listMenuDto;
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        public HandleResult<bool> DelMenu(string MenuId)
        {
            bool bResult = false;
            //获取菜单
            var menuModel = sysMenuDAL.GetModels(t => t.MenuId.Equals(MenuId)).First();
            //获取菜单与权限关联表
            var relatedModel = sysAmRelatedDAL.GetModels(t => t.MenuId.Equals(MenuId)).First();
            var authorityModel = sysAuthorityBLL.GetModels(y => y.AuthorityId.Equals(relatedModel.AuthorityId)).First();
            sysMenuDAL.Delete(menuModel);
            sysAmRelatedDAL.Delete(relatedModel);
            sysAmRelatedDAL.SaveChanges();
            sysAuthorityBLL.Delete(authorityModel);
            return new HandleResult<bool>
            {
                Msg = "删除成功",
                Result = bResult
            };
        }
        /// <summary>
        /// 获取角色的菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public HandleResult<List<SysMenuDto>> GetRoleMenuList(string RoleId)
        {

            var list = Mapper.Map<List<SysMenuDto>>(sysAuthorityBLL.GetRoleAuthoritieList(RoleId, AuthorityType.Type_Menu).Data.Select(t => t.sysMenu).ToList());
            return new HandleResult<List<SysMenuDto>>
            {
                Data = list
            };
        }
    }
}
