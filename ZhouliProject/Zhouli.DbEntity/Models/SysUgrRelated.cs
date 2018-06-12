using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class SysUgrRelated
    {
        public Guid UgrRelatedId { get; set; }
        public Guid UserGroupId { get; set; }
        public Guid RoleId { get; set; }
    }
}
