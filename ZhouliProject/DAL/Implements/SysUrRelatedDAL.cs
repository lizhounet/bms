using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUrRelatedDAL : BaseDAL<SysUrRelated>, ISysUrRelatedDAL
    {
        private DapperContext dapper;
        public SysUrRelatedDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }

    }
}
