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
    }
}
