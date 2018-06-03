using DAL.Interface;
using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements
{
    public class SysUsersDAL : BaseDAL<SysUsers>, ISysUsersDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysUsersDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
        public string show()
        {
            return "12345679";
        }
    }
}
