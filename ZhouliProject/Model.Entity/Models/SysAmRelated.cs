using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysAmRelated
    {
        public Guid AmRelatedId { get; set; }
        public Guid RoleId { get; set; }
        public Guid MenuId { get; set; }
    }
}
