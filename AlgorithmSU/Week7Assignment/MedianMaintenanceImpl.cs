using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week7Assignment
{
    public class MedianMaintenanceImpl
    {
        public static int CalculateMedianSum(int[] numbers)
        {
            int medianSum = 0;
            var lowHeap = new SortedDictionary<int, int>();
            var highHeap = new SortedDictionary<int, int>();
            lowHeap.Add(numbers[0],0);
            medianSum += numbers[0];

            for (int index = 1; index < numbers.Length; index++)
            {
                int lowHeapMax = lowHeap.Last().Key;
                int currentNumber = numbers[index];

                //update heap
                if (currentNumber < lowHeapMax)
                {
                    lowHeap.Add(currentNumber, 0);
                }
                else
                {
                    highHeap.Add(currentNumber,0);
                }

                //Re balancing
                var mayRequireReBalancing = (index +1) % 2 == 0;

                if (mayRequireReBalancing && lowHeap.Count != highHeap.Count)
                {
                    if (lowHeap.Count > highHeap.Count)
                    {
                        lowHeapMax = lowHeap.Last().Key;
                        lowHeap.Remove(lowHeapMax);
                        highHeap.Add(lowHeapMax,0);
                    }
                    else
                    {
                        var highHeapMin = highHeap.First().Key;
                        highHeap.Remove(highHeapMin);
                        lowHeap.Add(highHeapMin,0);
                    }
                }

                if (lowHeap.Count >= highHeap.Count)
                {
                    medianSum += lowHeap.Last().Key;
                }
                else
                {
                    medianSum += highHeap.First().Key;
                }

            }


            return medianSum;
        }
    }
}
