using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysMenuDAL : BaseDAL<SysMenu>, ISysMenuDAL
    {
        public SysMenuDAL(DapperContext dapper, ZhouLiContext db) : base(dapper, db)
        {
        }
    }
}
