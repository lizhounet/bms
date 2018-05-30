using System;
using System.Collections.Generic;

namespace Model.Entity.Models
{
    public partial class SysUrRelated
    {
        public Guid UrRelatedId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
