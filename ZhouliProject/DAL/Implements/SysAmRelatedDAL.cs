using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysAmRelatedDAL : BaseDAL<SysAmRelated>, ISysAmRelatedDAL
    {
        private DapperContext dapper;
        public SysAmRelatedDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }

    }
}
