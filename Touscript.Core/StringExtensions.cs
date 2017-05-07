using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Touscript.Core
{
    public static class StringExtensions
    {
        public static string StripWhiteSpace(this string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }

        public static bool In(this string value, params string[] array)
        {
            return Array.IndexOf(array, value) != -1;
        }
    }
}
