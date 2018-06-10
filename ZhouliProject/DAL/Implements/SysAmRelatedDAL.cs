using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysAmRelatedDAL : BaseDAL<SysAmRelated>, ISysAmRelatedDAL
    {
        private ZhouLiContext db;
        public SysAmRelatedDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
       
    }
}
