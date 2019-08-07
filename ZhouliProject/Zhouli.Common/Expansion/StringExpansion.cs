using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhouli.Common.Expansion
{
    public static class StringExpansion
    {
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            return input.First().ToString().ToLower() + input.Substring(1);
        }
    }
}
