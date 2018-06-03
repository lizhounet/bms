using DAL.Interface;
using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements
{
    public class SysRoleDAL : BaseDAL<SysRole>, ISysRoleDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysRoleDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
    }
}
