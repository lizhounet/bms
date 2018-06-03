using Model.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL.Interface
{
    public  interface ISysUsersDAL:IBaseDAL<SysUsers>
    {
        string show();
    }
}
