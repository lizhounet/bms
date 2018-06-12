using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUserGroupDAL : BaseDAL<SysUserGroup>, ISysUserGroupDAL
    {
        private ZhouLiContext db;
        public SysUserGroupDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
    }
}
