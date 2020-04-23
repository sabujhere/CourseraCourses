using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var intMulti = MathOperationOnStringNumbers.KaratsubaStringMultiplication("3141592653589793238462643383279502884197169399375105820974944592",
                "2718281828459045235360287471352662497757247093699959574966967627");
            Console.WriteLine($"Multi: {intMulti}");

            //Console.WriteLine($"Multi: {intMulti.Multiply(134, 46)}");
        }
    }
}
