using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointHelpers.Utils.String
{
    public static class StringHelpers
    {
        public static string StringIsNullOrEmpty(object obj)
        {
            return ((obj != null) && (!string.IsNullOrEmpty(obj.ToString()))) ? obj.ToString() : string.Empty;
        }
    }
}
