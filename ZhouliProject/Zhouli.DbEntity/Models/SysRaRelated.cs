using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class SysRaRelated
    {
        public Guid RaRelatedId { get; set; }
        public Guid RoleId { get; set; }
        public Guid AuthorityId { get; set; }
    }
}
