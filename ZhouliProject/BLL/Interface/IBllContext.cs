using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.BLL.Interface
{
    public interface IBllContext
    {
        T GetBllClass<T>();
    }
}
