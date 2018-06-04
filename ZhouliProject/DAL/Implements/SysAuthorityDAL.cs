using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
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
