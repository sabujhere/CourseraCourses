using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Common;

namespace Week3Assignment
{
    public class QuickSortImpl<T> : ISort<T> where T : IComparable<T>
    {
        public IPivotPositionFinder PivotPositionFinder { get; private set; }

        public QuickSortImpl(IPivotPositionFinder pivotPositionFinder)
        {
            PivotPositionFinder = pivotPositionFinder;
        }

        public ICollection<T> Sort(ICollection<T> unsortedCollection)
        {
            var unsortedArray = unsortedCollection.ToArray();
            Sort(ref unsortedArray,0,unsortedArray.Length-1);
            return unsortedArray;
        }

        private void Sort(ref T[] unsortedArray, int startIndex, int endIndex)
        {
            if(endIndex - startIndex <= 1) return;
            var pivotIndex = PivotPositionFinder.Get(startIndex,endIndex);

            //partition around pivot
            int partitionIndex = Partition(ref unsortedArray, startIndex,endIndex, pivotIndex);

            //sort left
            Sort(ref unsortedArray, startIndex, partitionIndex -1);
            
            //sort right
            Sort(ref unsortedArray, partitionIndex+1,unsortedArray.Length - 1);
        }


        private int Partition(ref T[] unsortedArray, int startIndex,int endIndex, int pivotIndex)
        {
            var isPivotIndexValid = pivotIndex >= startIndex && pivotIndex <= endIndex;
            if(!isPivotIndexValid)
                throw new Exception($"Pivot index not valid, PivotIndex: {pivotIndex}, startIndex:{startIndex}, endIndex: {endIndex}");

            if(pivotIndex != startIndex)
                Swap(ref unsortedArray, pivotIndex,startIndex);

            pivotIndex = startIndex;
            var pivotItem = unsortedArray[pivotIndex];
            var i = pivotIndex + 1;
            for (int j = pivotIndex+1; j <= endIndex; j++)
            {
                if (pivotItem.CompareTo(unsortedArray[j]) > 0)
                {
                    //swap(i, j)
                    Swap(ref unsortedArray, i, j);
                    i++;
                }
            }
            Swap(ref unsortedArray, pivotIndex, i - 1);
            return i - 1;
        }


        private void Swap(ref T[] unsortedArray, int index1, int index2)
        {
            if(index1 == index2) return;
            var temp = unsortedArray[index1];
            unsortedArray[index1] = unsortedArray[index2];
            unsortedArray[index2] = temp;
        }
    }
}
