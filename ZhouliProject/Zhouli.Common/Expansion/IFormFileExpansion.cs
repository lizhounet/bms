using System;
using System.Collections.Generic;
using System.Text;

namespace Zhouli.Common.Expansion
{
    public static class IFormFileExpansion
    {
        /// <summary>
        /// 计算文件大小,单位KB,M,G(默认:M)
        /// </summary>
        /// <param name="Size"></param>
        /// <param name="Format">KB,M,G(默认:M)</param>
        /// <returns></returns>
        public static double FileSize(this long Size, string Format = "M")
        {
            double FactSize = 0;
            switch (Format)
            {
                case "KB":
                    FactSize = (Size / 1024.00);
                    break;
                case "M":
                    FactSize = (Size / 1024.00 / 1024.00);
                    break;
                case "G":
                    FactSize = (Size / 1024.00 / 1024.00 / 1024.00);
                    break;
            }
            return FactSize;
        }

    }
}
