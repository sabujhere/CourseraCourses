using System;
using System.Collections.Generic;

namespace Week2Assignment
{
    public interface ISort<T> where T : IComparable<T>
    {
        ICollection<T> Sort(ICollection<T> unsortedCollection);
    }
}