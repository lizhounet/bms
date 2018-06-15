using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zhouli.DbEntity.Models
{
    public partial class SysUser
    {
        [NotMapped]
        /// <summary>
        /// 用户组
        /// </summary>
        public List<SysUserGroup> sysUserGroups { set; get; }
        [NotMapped]
        /// <summary>
        /// 用户所拥有的角色
        /// </summary>
        public List<SysRole> sysRoles { set; get; }
    }
}
