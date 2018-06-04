using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Entity.Models
{
    public partial class SysUsers
    {
        /// <summary>
        /// 用户组
        /// </summary>
        public List<SysUserGroup> sysUserGroups { set; get; }
    }
}
