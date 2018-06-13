using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DbEntity.Models
{
    public partial class SysAuthority
    {
        /// <summary>
        /// 权限对应的菜单
        /// </summary>
        public SysMenu sysMenu { set; get; }
    }
}
