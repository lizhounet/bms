using System;
using System.Collections.Generic;

namespace Model.Entity.Models
{
    public partial class SysAuthority
    {
        public Guid AuthorityId { get; set; }
        public int AuthorityType { get; set; }
        public string Note { get; set; }
    }
}
