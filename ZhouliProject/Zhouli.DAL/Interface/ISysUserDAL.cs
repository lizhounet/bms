﻿using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Zhouli.DAL.Interface
{
    public interface ISysUserDAL : IBaseDAL<SysUser>
    {
        /// <summary>
        /// 获取需要登录的用户所有信息
        /// </summary>
        /// <returns></returns>
        SysUser SetLoginSysUser(SysUser user);
    }
}
