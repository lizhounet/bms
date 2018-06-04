using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysRole
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Note { get; set; }
    }
}
