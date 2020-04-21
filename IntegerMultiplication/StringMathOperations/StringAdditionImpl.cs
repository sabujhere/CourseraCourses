using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMathOperations
{
    public class StringAdditionImpl:IStringAddition
    {
        public string Add(string term1, string term2)
        {
            if (term1.Length < term2.Length)
            {
                Swap(ref term1,ref term2);
            }

            term2 = term2.PadLeft(term1.Length);

            string result = string.Empty;
            int carry = 0;
            for (int i = term1.Length - 1; i >= 0; i--)
            {
                var a = int.Parse(term1.Substring(i, 1));
                var b = int.Parse(term2.Substring(i, 1));
                var temp = a + b + carry;
                carry = temp / 10;
                result = result.Insert(0, $"{temp % 10}");
            }
            result = result.Insert(0, $"{carry}");
            return result;
        }

        public void Swap(ref string term1, ref string term2)
        {
            var temp = term1;
            term1 = term2;
            term2 = temp;
        }
    }
}
