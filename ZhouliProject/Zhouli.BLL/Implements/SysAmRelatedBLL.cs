using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL.Implements
{
    public class SysAmRelatedBLL : BaseBLL<SysAmRelated>, ISysAmRelatedBLL
    {
        private readonly ISysAmRelatedDAL sysAmRelated;
        /// <summary>
        /// 用于实例化父级，sysAmRelated
        /// </summary>
        /// <param name="sysAmRelated"></param>
        public SysAmRelatedBLL(ISysAmRelatedDAL sysAmRelated) : base(sysAmRelated)
        {
            this.sysAmRelated = sysAmRelated;
        }
    }
}
