using DAL.Interface;
using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements
{
    public class SysUserGroupDAL : BaseDAL<SysUserGroup>, ISysUserGroupDAL
    {
        private GRWEBSITEContext gRWEBSITEContext;
        public SysUserGroupDAL(GRWEBSITEContext gRWEBSITEContext) : base(gRWEBSITEContext)
        {
            this.gRWEBSITEContext = gRWEBSITEContext;
        }
    }
}
