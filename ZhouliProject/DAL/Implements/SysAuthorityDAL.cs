using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysAuthorityDAL : BaseDAL<SysAuthority>, ISysAuthorityDAL
    {
        private ZhouLiContext db;
        public SysAuthorityDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
      
    }
}
