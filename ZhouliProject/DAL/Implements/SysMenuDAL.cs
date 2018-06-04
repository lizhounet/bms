using Zhouli.DAL.Interface;
using Zhouli.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class SysMenuDAL : BaseDAL<SysMenu>, ISysMenuDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysMenuDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
      
    }
}
