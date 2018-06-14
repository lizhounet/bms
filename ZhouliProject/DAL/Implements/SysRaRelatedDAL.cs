using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysRaRelatedDAL : BaseDAL<SysRaRelated>, ISysRaRelatedDAL
    {
        private DapperContext dapper;
        public SysRaRelatedDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }

    }
}
