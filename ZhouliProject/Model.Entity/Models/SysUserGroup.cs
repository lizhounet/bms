using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysUserGroup
    {
        public Guid UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public Guid? ParentUserGroupId { get; set; }
    }
}
