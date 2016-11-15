using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public static class DataTimeExtensions
    {
        public static string ToyyyyMMdd(this DateTime o)
        {
            return o.ToString("yyyy-MM-dd");
        }
        public static string ToyyyyMMddHHmmss(this DateTime o)
        {
            return o.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
