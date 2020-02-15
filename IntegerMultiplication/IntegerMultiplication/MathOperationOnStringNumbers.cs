using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerMultiplication
{
    public static class MathOperationOnStringNumbers
    {

        public static string StringAddition(string a, string b)
        {
            // # of digits in a is alway greater
            if (a.Length < b.Length)
                Swap(ref a, ref b);
            b = b.PadLeft(a.Length,'0');
            int carry = 0, intermResult;
            string result = ""; 
            for(int i = a.Length-1; i>=0; i--)
            {
                int num1 = int.Parse(a.Substring(i, 1));
                var num2 = int.Parse(b.Substring(i, 1));
                intermResult = num1 + num2 + carry;
                carry = intermResult / 10;
                result = result.Insert(0,$"{intermResult % 10}");
            }

            if(carry != 0)
                result = result.Insert(0, carry.ToString());

            return result;
        }

        private static void Swap(ref string a, ref string b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
