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
            var intMulti = new KaratsubaImpl();
            Console.WriteLine($"Multi: {intMulti.Multiply(5678, 1234)}");

            //Console.WriteLine($"Multi: {intMulti.Multiply(134, 46)}");
        }
    }
}
