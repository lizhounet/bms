using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysRole
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid? CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
