using System;
using System.Collections.Generic;

namespace Model.Entity.Models
{
    public partial class SysRole
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Note { get; set; }
    }
}
