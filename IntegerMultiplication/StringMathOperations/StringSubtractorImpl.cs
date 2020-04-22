using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMathOperations
{
    public class StringSubtractorImpl : IStringSubtractor
    {
        public string Subtract(string term1, string term2)
        {
            //if (term1.Length < term2.Length)
            //{
            //    Utils.Swap(ref term1,ref term2);
            //}
            //else if(term1.Length == term2.Length)
            //{
            //    var leftMostDigitInTerm1 = int.Parse(term1.Substring(term1.Length - 1, 1));
            //    var leftMostDigitInTerm2 = int.Parse(term2.Substring(term1.Length - 1, 1));
            //    if(leftMostDigitInTerm1 < leftMostDigitInTerm2)
            //        Utils.Swap(ref term1,ref term2);
            //}

            bool resultNegative = false;
            if (Utils.StringIsSmaller(term1, term2))
            {
                Utils.Swap(ref term1,ref term2);
                resultNegative = true;
            }
            term2 = term2.PadLeft(term1.Length, '0');

            string result = string.Empty;
            int carry = 0;
            for (int i = term1.Length - 1; i >= 0; i--)
            {
                var num1 = int.Parse(term1.Substring(i, 1));
                var num2 = int.Parse(term2.Substring(i, 1));
                num1 = num1 - carry;
                if (num1 < num2)
                {
                    carry = 1;
                    num1+= 10;
                }
                else
                {
                    carry = 0;
                }
                var temp = num1 - num2;
                result = result.Insert(0, temp.ToString());
            }
            result = Utils.SanitizeResult(result);
            return resultNegative ? result.Insert(0, "-") : result;
        }
    }
}
