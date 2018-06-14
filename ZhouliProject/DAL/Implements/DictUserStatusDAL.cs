using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class DictUserStatusDAL : BaseDAL<DictUserStatus>, IDictUserStatusDAL
    {
        private DapperContext dapper;
        public DictUserStatusDAL(DapperContext dapper) : base(dapper)
        {
            this.dapper = dapper;
        }

    }
}
