﻿using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.ModelDto;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Interface
{
    /// <summary>
    /// 菜单表Service接口
    /// </summary>
    public interface ISysMenuBLL : IBaseBLL<SysMenu>
    {
        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        List<SysMenuDto> GetMenusBy(Guid userId);
    }
}
