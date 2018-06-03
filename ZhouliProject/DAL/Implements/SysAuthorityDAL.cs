using DAL.Interface;
using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements
{
    public class SysAuthorityDAL : BaseDAL<SysAuthority>, ISysAuthorityDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysAuthorityDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
      
    }
}
