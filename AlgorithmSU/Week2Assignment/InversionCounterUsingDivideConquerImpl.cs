using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Assignment
{
    public interface IInversionCounter
    {
        long GetCount(ICollection<int> unsortedNumbers);
    }

    public class InversionCounterUsingDivideConquerImpl : IInversionCounter
    {
        private long _inversionCountLocal;
        public long GetCount(ICollection<int> unsortedNumbers)
        {
            _inversionCountLocal = 0;
            Sort(unsortedNumbers, out _);
            return _inversionCountLocal;
        }

        private ICollection<int> Sort(ICollection<int> unsortedCollection, out long inversionCount)
        {
            inversionCount = 0;
            
            if(unsortedCollection.Count <= 1)
                return unsortedCollection;
            var splitPosition = unsortedCollection.Count / 2;

            var sortedLeft = Sort(unsortedCollection.Take(splitPosition).ToList(),out var leftInversionCount);
            _inversionCountLocal += leftInversionCount;

            var sortedRight = Sort(unsortedCollection.Skip(splitPosition).ToList(),out var rightInversionCount);
            _inversionCountLocal += rightInversionCount;

            var sortedCollection = Merge(sortedLeft, sortedRight,out var mergeInversionCount);
            _inversionCountLocal += mergeInversionCount;

            return sortedCollection;
        }

        private  ICollection<int> Merge(ICollection<int> sortedLeft, ICollection<int> sortedRight, out long mergeInversionCount)
        {
            var result = new List<int>();
            mergeInversionCount = 0;
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
                        _inversionCountLocal += sortedLeft.Count;
                        sortedRight.Remove(rightItem);
                    }
                }
                else if(sortedLeft.Count == 0)
                {
                    result.AddRange(sortedRight);
                    sortedRight.Clear();
                }
                else
                {
                    result.AddRange(sortedLeft);
                    sortedLeft.Clear();
                }
            }

            return result;
        }
    }
}
