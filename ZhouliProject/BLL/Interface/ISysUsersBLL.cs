﻿using System;
using System.Collections.Generic;
using System.Text;
using Model.Entity.Models;

namespace BLL.Interface
{
    public interface ISysUsersBLL : IBaseBLL<SysUsers>
    {
        string show();
    }
}
