using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Assignment
{
    public class AdjacentEdge
    {
        public int NodeId { get; private set; }

        public int Weight { get; private set; }

        public AdjacentEdge(int nodeId, int weight)
        {
            NodeId = nodeId;
            Weight = weight;
        }
    }
}
