using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Entity.Models
{
    public  class SysUserLogin
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public SysUser sysUsers { set; get; }
        /// <summary>
        /// 用户组
        /// </summary>
        public List<SysUserGroup> sysUserGroups { set; get; }
    }
}
