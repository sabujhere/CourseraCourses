using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Assignment
{
    public class Edge
    {
        public long HeadNodeId { get; private set; }

        public long TailNodeId { get; private set; }

        public Edge(long headNodeId, long tailNodeId)
        {
            HeadNodeId = headNodeId;
            TailNodeId = tailNodeId;
        }
    }
}
