using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Touscript
{
    public static class StringExtensions
    {
        public static string StripWhiteSpace(this string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
}
