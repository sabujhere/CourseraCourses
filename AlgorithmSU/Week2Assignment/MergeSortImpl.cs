using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Assignment
{
    public interface ISort<T> where T : IComparable<T>
    {
        ICollection<T> Sort(ICollection<T> unsortedCollection);
    }

    public class MergeSortImpl<T> : ISort<T> where T : IComparable<T>
    {
        public ICollection<T> Sort(ICollection<T> unsortedCollection)
        {
            if(unsortedCollection.Count <= 1)
                return unsortedCollection;
            int splitPosition = unsortedCollection.Count / 2;

            var sortedLeft = Sort(unsortedCollection.Take(splitPosition).ToList());
            var sortedRight = Sort(unsortedCollection.Skip(splitPosition).ToList());

            var sortedCollection = Merge(sortedLeft, sortedRight);

            return sortedCollection;
        }

        private ICollection<T> Merge(ICollection<T> sortedLeft, ICollection<T> sortedRight)
        {
            var result = new List<T>();
           
            while (sortedLeft.Count > 0 || sortedRight.Count > 0)
            {
                if (sortedLeft.Count > 0 && sortedRight.Count > 0)
                {
                    
                    if (sortedLeft.First().CompareTo(sortedRight.First()) <= 0)
                    {
                        var leftItem = sortedLeft.First();
                        result.Add(leftItem);
                        sortedLeft.Remove(leftItem);
                    }
                    else
                    {
                        var rightItem = sortedRight.First();
                        result.Add(rightItem);
                        sortedRight.Remove(rightItem);
                    }
                }
                else if(sortedLeft.Count == 0)
                {
                    result.AddRange(sortedRight);
                }
                else
                {
                    result.AddRange(sortedLeft);
                }
            }

            return result;
        }
    }
}
