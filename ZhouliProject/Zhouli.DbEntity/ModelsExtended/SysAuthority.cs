using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zhouli.MsSql.DbEntity.Models
{
    public partial class SysAuthority
    {
        [NotMapped]
        /// <summary>
        /// 权限对应的菜单
        /// </summary>
        public SysMenu sysMenu { set; get; }
    }
}
