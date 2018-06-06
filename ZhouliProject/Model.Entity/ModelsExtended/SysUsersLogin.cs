using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Entity.Models
{
    public  class SysUsersLogin
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public SysUsers sysUsers { set; get; }
        /// <summary>
        /// 用户组
        /// </summary>
        public List<SysUserGroup> sysUserGroups { set; get; }
    }
}
