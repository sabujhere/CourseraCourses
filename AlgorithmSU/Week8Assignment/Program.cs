using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\TestData\prob-2sum.txt";
            if (args.Length != 0)
                filePath = args[0];
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"using File path: {filePath}");
            var nodes = File.ReadAllLines(filePath).Select(long.Parse).ToArray();
        }
    }
}
