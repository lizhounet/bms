using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class SysUuRelated
    {
        public Guid UuRelatedId { get; set; }
        public Guid UserId { get; set; }
        public Guid UserGroupId { get; set; }
    }
}
