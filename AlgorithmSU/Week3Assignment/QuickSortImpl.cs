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

        public ICollection<T> Sort(ICollection<T> unsortedCollection)
        {
            var unsortedArray = unsortedCollection.ToArray();
            Sort(ref unsortedArray,unsortedArray.Length,0);
            return unsortedArray;

        }

        private void Sort(ref T[] unsortedArray, int itemsToSortCount, int startIndex)
        {
            Debug.WriteLine("Sorting:");
            for (int i = startIndex; i < startIndex + itemsToSortCount; i++)
            {
                Debug.WriteLine(unsortedArray[i]);
            }
            if(itemsToSortCount <= 1) return;
            var pivotIndex = startIndex;

            //partition around pivot
            int partitionIndex = Partition(ref unsortedArray, itemsToSortCount,startIndex, pivotIndex);

            //sort left
            Sort(ref unsortedArray, partitionIndex - startIndex-1, startIndex);
            
            //sort right
            Sort(ref unsortedArray, unsortedArray.Length - partitionIndex-1, partitionIndex+1);
        }


        private int Partition(ref T[] unsortedArray, int itemsToCount, int startIndex, int pivotIndex)
        {
            var isPivotIndexValid = pivotIndex >= startIndex && pivotIndex <= startIndex + itemsToCount;
            if(!isPivotIndexValid)
                throw new Exception($"Pivot index not valid, PivotIndex: {pivotIndex}, startIndex:{startIndex}, ItemCount: {itemsToCount}");

            if(pivotIndex != startIndex)
                Swap(ref unsortedArray, pivotIndex,startIndex);

            pivotIndex = startIndex;
            var pivotItem = unsortedArray[pivotIndex];
            var i = pivotIndex + 1;
            for (int j = pivotIndex+1; j < startIndex + itemsToCount; j++)
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
