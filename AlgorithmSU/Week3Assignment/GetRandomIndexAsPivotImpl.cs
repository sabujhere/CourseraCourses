using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assignment
{
    public class GetRandomIndexAsPivotImpl:IPivotPositionFinder
    {
        private readonly Random _rnd;

        public GetRandomIndexAsPivotImpl()
        {
            _rnd = new Random();
        }

        public int Get(int startIndex, int endIndex)
        {
            return _rnd.Next(startIndex, endIndex);
        }
    }
}
