using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCHomework6.Extension
{
    public static class PageExtension
    {
        /// <summary>
        /// 取得分頁數值，預設1
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int GetPage(this int? i)
        {
            if (i is null) return 1;
            if (i < 1) return 1;
            if (i >= int.MaxValue) return int.MaxValue;
            return (int)i;
        }
    }
}