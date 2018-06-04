using System;
using System.Collections.Generic;

namespace Zhouli.Entity.Models
{
    public partial class SysUsers
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
        public DateTime UserCreateTime { get; set; }
        public DateTime? UserEditTime { get; set; }
        public string Note { get; set; }
    }
}
