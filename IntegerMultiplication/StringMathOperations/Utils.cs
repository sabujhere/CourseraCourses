using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMathOperations
{
    public static class Utils
    {
        public static void Swap(ref string term1, ref string term2)
        {
            var temp = term1;
            term1 = term2;
            term2 = temp;
        }
        public static string SanitizeResult(string result)
        {
            result = result.TrimStart(new char[] { '0' });
            if (result.Length == 0)
                result = "0";
            return result;
        }
        public static bool StringIsSmaller(string a, string b)
        {
            if (a.Length > b.Length)
                return false;
            if (b.Length > a.Length)
                return true;
            var aArray = a.ToCharArray();
            var bArray = b.ToCharArray();
            for(var i = 0; i<a.Length; i++)
            {
                if (aArray[i] > bArray[i])
                    return false;
                if (bArray[i] > aArray[i])
                    return true;
            }
            return false;
        }
    }
}
