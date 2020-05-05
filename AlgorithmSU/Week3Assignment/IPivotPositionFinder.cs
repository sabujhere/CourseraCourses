using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assignment
{
    public interface IPivotPositionFinder<T> where T : IComparable<T>
    {
        int Get(T[] items, int startIndex, int endIndex);
    }
}
