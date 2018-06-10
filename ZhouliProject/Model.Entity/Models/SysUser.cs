using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysUser
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserNikeName { get; set; }
        public string UserPwd { get; set; }
        public int? UserSex { get; set; }
        public DateTime? UserBirthday { get; set; }
        public string UserEmail { get; set; }
        public string UserQq { get; set; }
        public string UserWx { get; set; }
        public string UserAvatar { get; set; }
        public string UserPhone { get; set; }
        public int UserStatus { get; set; }
        public Guid? CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int DeleteSign { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string Note { get; set; }
    }
}
