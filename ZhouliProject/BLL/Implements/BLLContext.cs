using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Zhouli.BLL.Interface;

namespace Zhouli.BLL.Implements
{
    public class BLLContext : IBllContext
    {
        private IHttpContextAccessor httpContextAccessor;
        public BLLContext(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
        public T GetBllClass<T>()
        {
            return (T)httpContextAccessor.HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}
