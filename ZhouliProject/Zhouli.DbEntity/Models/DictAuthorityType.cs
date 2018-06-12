using System;
using System.Collections.Generic;

namespace Zhouli.DbEntity.Models
{
    public partial class DictAuthorityType
    {
        public int AuthorityTypeId { get; set; }
        public string AuthorityTypeName { get; set; }
        public Guid? CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
