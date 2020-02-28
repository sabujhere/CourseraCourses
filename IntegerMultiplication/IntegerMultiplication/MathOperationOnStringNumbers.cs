using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerMultiplication
{

    public static class MathOperationOnStringNumbers
    {
        public static string KaratsubaStringMultiplication(string first, string second)
        {
            var sizeFirst = first.Length;
            var sizeSecond = second.Length;
            if (sizeFirst == 1 && sizeSecond == 1)
                return $"{int.Parse(first) * int.Parse(second)}";

            if (first.Length < second.Length)
                first = first.PadLeft(second.Length, '0');
            if (second.Length < first.Length)
                second = second.PadLeft(first.Length, '0');

            var cutPosition = GetCutPosition(first, second);
            
            var a = first.Remove(first.Length - cutPosition);
            var b = first.Substring(first.Length - cutPosition);
            var c = second.Remove(second.Length - cutPosition);
            var d = second.Substring(second.Length - cutPosition);

            var ac = KaratsubaStringMultiplication(a, c);
            var bd = KaratsubaStringMultiplication(b, d);
            var a_b_c_d = KaratsubaStringMultiplication(StringAddition(a, b), StringAddition(c, d));
            return CalculateResult(ac, bd, a_b_c_d, b.Length + d.Length);
        }

        static string CalculateResult(string ac, string bd, string ab_cd, int padding)
        {
            string term0 = StringSubtraction(StringSubtraction(ab_cd, ac), bd);
            string term1 = term0.PadRight(term0.Length + padding / 2, '0');
            string term2 = ac.PadRight(ac.Length + padding, '0');
            return StringAddition(StringAddition(term1, term2), bd);
        }

        private static int GetCutPosition(string a, string b)
        {
            var minLength = Math.Min(a.Length, b.Length);
            if (minLength == 1)
                return 1;
            if (minLength % 2 == 0)
                return minLength / 2;
            return minLength / 2 + 1;
        }
         
        public static string StringAddition(string a, string b)
        {
            // # of digits in a is alway greater
            if (a.Length < b.Length)
                Swap(ref a, ref b);
            b = b.PadLeft(a.Length,'0');
            int carry = 0, res;
            string result = ""; 
            for(int i = a.Length-1; i>=0; i--)
            {
                var num1 = int.Parse(a.Substring(i, 1));
                var num2 = int.Parse(b.Substring(i, 1));
                res = num1 + num2 + carry;
                carry = res / 10;
                result = result.Insert(0,$"{res % 10}");
            }

            if(carry != 0)
                result = result.Insert(0, carry.ToString());

            return sanitizeResult(result);
        }
        static string sanitizeResult(string result)
        {
            result = result.TrimStart(new char[] { '0' });
            if (result.Length == 0)
                result = "0";
            return result;
        }
        public static string StringSubtraction(string a, string b)
        {
            bool resultNegative = false;
            string result = "";

            if (StringIsSmaller(a, b))
            {
                Swap(ref a, ref b);
                resultNegative = true;
            }

            b = b.PadLeft(a.Length, '0');
            var length = a.Length;
            int carry = 0, res = 0;
           

            for (int i = length - 1; i >= 0; i--)
            {
                bool nextCarry = false;
                var num1 = int.Parse(a.Substring(i, 1));
                var num2 = int.Parse(b.Substring(i, 1));
                if (num1 - carry < num2)
                {
                    num1 += 10;
                    nextCarry = true;
                }

                res = num1 - num2 - carry;
                result = result.Insert(0, res.ToString());
                carry = nextCarry ? 1 : 0;
            }

            result = sanitizeResult(result);
            return resultNegative ? result.Insert(0, "-") : result;
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

        private static void Swap(ref string a, ref string b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
