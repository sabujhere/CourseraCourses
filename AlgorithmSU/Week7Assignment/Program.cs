using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\TestData\Median.txt";
            if (args.Length != 0)
                filePath = args[0];
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"using File path: {filePath}");
            var numbers = File.ReadAllLines(filePath).Select(line => Convert.ToInt32(line));

            Console.WriteLine("result={0}", MedianMaintenanceImpl.CalculateMedianSum(numbers.ToArray()) % 10000);
        }
    }
}
