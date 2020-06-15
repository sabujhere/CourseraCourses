using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week8Assignment
{
    public class TwoSumAlgoImpl
    {
        public static int Calculate(int start, int finish, List<long> rwnumbers)
        {
            var hashSet = rwnumbers.ToHashSet();
            int result = 0;
            var numRange = Enumerable.Range(start, finish - start);
            Parallel.ForEach(numRange,
                new ParallelOptions
                    {MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.75) * 1.0))},
                (currentNumber) =>
                {
                    foreach (var number in rwnumbers)
                    {
                        var y = currentNumber - number;
                        if (hashSet.Contains(y))
                        {
                            Interlocked.Increment(ref result);
                            if(result %10 == 0)
                                Console.WriteLine($"Current result: {result}");

                            return;
                        }
                    }
                });
           

            return result;
        }
    }
}
