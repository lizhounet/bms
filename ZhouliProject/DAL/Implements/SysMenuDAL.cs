using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysMenuDAL : BaseDAL<SysMenu>, ISysMenuDAL
    {
        private ZhouLiContext db;
        public SysMenuDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
      
    }
}
