using System;
using System.Collections.Generic;

namespace Assignment.Common
{
    public interface ISort<T> where T : IComparable<T>
    {
        ICollection<T> Sort(ICollection<T> unsortedCollection);
    }
}