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

        public static string Neighboor(this string value, int index, int range)
        {
            var leftIndex = Clamp(index - range, 0, index);
            var rightIndex = Clamp(index + range, 0, value.Length - 1);
            var length = rightIndex - leftIndex + 1;

            return value.Substring(leftIndex, length);
        }

        private static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }
    }
}
