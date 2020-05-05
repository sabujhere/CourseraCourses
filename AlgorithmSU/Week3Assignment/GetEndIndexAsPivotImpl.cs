using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assignment
{
    public class GetEndIndexAsPivotImpl<T> : IPivotPositionFinder<T> where T : IComparable<T>
    {
        public int Get(T[] items, int startIndex, int endIndex)
        {
            return endIndex;
        }
    }
}
