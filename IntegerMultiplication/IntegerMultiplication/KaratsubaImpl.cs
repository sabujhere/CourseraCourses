using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerMultiplication
{

    public interface IIntegerMultiplication
    {
        long Multiply(long num1, long num2);
    }


    public class KaratsubaImpl : IIntegerMultiplication
    {
        public long Multiply(long num1, long num2)
        {
            var maxDigitCount = getMaxDigitCount(num1, num2);
            if (maxDigitCount <= 2)
                return num1 * num2;
            
            var m = Math.Pow(10, maxDigitCount/2);
            var a = (long)(num1 / m);
            var b = (long)(num1 % m);
            var c = (long)(num2 / m);
            var d = (long)(num2 % m);

            var ac = Multiply(a, c);
            var bd = Multiply(b, d);
            var a_b_c_d = Multiply(a + b, c + d);
            var minDigitCount = getMinDigitCount(num1, num2);
            var result = (long)((Math.Pow(10, minDigitCount) * ac) + (Math.Pow(10, (int)(minDigitCount / 2)) * (a_b_c_d - ac - bd)) + bd);
            Console.WriteLine($"Mulitplying: {num1} and {num2}, result: {result}");
            return result;
        }


        private int getMaxDigitCount(long num1, long num2)
        {
            int num1Count = num1.ToString().Count();
            int num2Count = num2.ToString().Count();

            return Math.Max(num1Count, num2Count);
        }
        private int getMinDigitCount(long num1, long num2)
        {
            var num1Count = num1.ToString().Count();
            var num2Count = num2.ToString().Count();

            return Math.Min(num1Count, num2Count);
        }
    }
}
