using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Assignment
{
    public class Node
    {
        public int Id { get; private set; }

        public IEnumerable<AdjacentEdge> AdjacentEdges { get; private set; }

        public Node(int id, IEnumerable<AdjacentEdge> adjacentEdges)
        {
            Id = id;
            AdjacentEdges = adjacentEdges;
        }
    }
}
