﻿using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class SysAmRelated
    {
        public Guid AmRelatedId { get; set; }
        public Guid AuthorityId { get; set; }
        public Guid MenuId { get; set; }
    }
}
