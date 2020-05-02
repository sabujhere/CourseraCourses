using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assignment
{
    public interface IPivotPositionFinder
    {
        int Get(int startIndex, int endIndex);
    }
}
