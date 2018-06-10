using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class DictUserStatusDAL : BaseDAL<DictUserStatus>, IDictUserStatusDAL
    {
        private ZhouLiContext db;
        public DictUserStatusDAL(ZhouLiContext db) : base(db)
        {
            this.db = db;
        }
        
    }
}
