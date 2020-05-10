using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Assignment
{
    public class Edge 
    {
        public int HeadId { get; private set; }

        public int TailId { get; private set; }

        public Edge(int headId, int tailId)
        {
            HeadId = headId;
            TailId = tailId;
        }
    }
}
