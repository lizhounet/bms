using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.BLL
{
    public class SysUserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserNikeName { get; set; }
        public int? UserSex { get; set; }
        public DateTime? UserBirthday { get; set; }
        public string UserEmail { get; set; }
        public string UserQq { get; set; }
        public string UserWx { get; set; }
        public string UserAvatar { get; set; }
        public string UserPhone { get; set; }
        public int UserStatus { get; set; }
        public Guid? CreateUserId { get; set; }
        public string Note { get; set; }
    }
}
