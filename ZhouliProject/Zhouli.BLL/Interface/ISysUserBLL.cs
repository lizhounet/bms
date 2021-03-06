﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Zhouli.DbEntity.Views;
using Zhouli.DbEntity.Models;
using Zhouli.Dto.ModelDto;
using Zhouli.Common.ResultModel;

namespace Zhouli.BLL.Interface
{
    public interface ISysUserBLL : IBaseBLL<SysUser>
    {
        #region 获取需要登录的用户所有信息
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        HandleResult<SysUser> GetLoginSysUser(SysUser sysUsers);
        #endregion
        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="limit">页容量</param>
        /// <param name="searchstr">搜索内容</param>
        /// <returns></returns>
        HandleResult<PageModel> GetUserList(string page, string limit, string searchstr);
        #endregion
        #region 添加/编辑用户
        /// <summary>
        /// 添加/编辑用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="userId">当前登录用户id</param>
        /// <returns></returns>
        HandleResult<bool> AddorEditUser(SysUserDto userDto, string userId);
        #endregion
        #region 删除用户(批量删除)
        /// <summary>
        /// 删除用户(批量删除)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        HandleResult<bool> DelUser(IEnumerable<string> UserId);
        #endregion
    }
}
