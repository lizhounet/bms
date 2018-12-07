﻿using Zhouli.MsSql.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Zhouli.DAL.Interface
{
    public  interface ISysRoleDAL : IBaseDAL<SysRole>
    {
        /// <summary>
        /// 设置角色的权限集合
        /// </summary>
        /// <returns></returns>
        //List<SysRole> SetRolePowerList(List<SysRole> sysRoles);
        /// <summary>
        /// 为角色添加功能菜单
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="menuDtos"></param>
        /// <returns></returns>
        bool AddRoleMenu(Guid RoleId, List<SysMenu> menus);
    }
}
