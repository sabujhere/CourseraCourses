using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Assignment
{
    public static class UnionFind
    {
        private static Random _random = new Random();
        public static Vertex Find(Vertex start)
        {
            var element = start;
            while (element.Parent != element)
            {
                element = element.Parent;
            }
            return element;
        }

        public static void Union(Vertex head, Vertex tail)
        {
            var headRoot = Find(head);
            var tailRoot = Find(tail);
            if(headRoot.CompareTo(tailRoot) == 0) return;

            var rankComparisonResult = head.Rank.CompareTo(tailRoot.Rank);
            if (rankComparisonResult < 0)
            {
                headRoot.Parent = tailRoot;
            }
            else if(rankComparisonResult > 0)
            {
                tailRoot.Parent = headRoot;
            }
            else
            {
                if (_random.Next(0, 1) == 0)
                {
                    headRoot.Parent = tailRoot;
                    tailRoot.Rank++;
                }
                else
                {
                    tailRoot.Parent = headRoot;
                    headRoot.Rank++;
                }
            }
        }
    }
}
