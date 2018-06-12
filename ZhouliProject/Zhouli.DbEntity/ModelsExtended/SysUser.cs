﻿using System;
using System.Collections.Generic;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.DbEntity.Models
{
    public partial class SysUser
    {
        /// <summary>
        /// 用户组
        /// </summary>
        public List<SysUserGroup> sysUserGroups { set; get; }
        public List<SysRole> sysRoles { set; get; }
    }
}
