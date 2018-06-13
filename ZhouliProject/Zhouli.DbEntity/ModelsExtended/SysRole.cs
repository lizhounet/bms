using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DbEntity.Models
{
    public partial class SysRole
    {
        //角色对应的权限集合
        public List<SysAuthority> sysAuthorities { set; get; }
    }
}
