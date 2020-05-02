using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assignment
{
    public class GetEndIndexAsPivotImpl:IPivotPositionFinder
    {
        public int Get(int startIndex, int endIndex)
        {
            return endIndex;
        }
    }
}
