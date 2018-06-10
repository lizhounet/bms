using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysUrRelatedDAL : BaseDAL<SysUrRelated>, ISysUrRelatedDAL
    {
        private ZhouLiContext db;
        public SysUrRelatedDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
        
    }
}
