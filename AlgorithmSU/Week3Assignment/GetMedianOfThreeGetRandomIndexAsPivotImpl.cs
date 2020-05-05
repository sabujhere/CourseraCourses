using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assignment
{
    public class GetMedianOfThreeGetRandomIndexAsPivotImpl<T> : IPivotPositionFinder<T> where T : IComparable<T>
    {
        public int Get(T[] items, int startIndex, int endIndex)
        {
            
            var mid = (startIndex + endIndex) / 2;
            var itemsForPivot = new List<T>()
            {
                items[startIndex],
                items[mid],
                items[endIndex]
            };
            return items.ToList().IndexOf(itemsForPivot.OrderBy(it => it).Skip(1).First());
        }
    }
}
