using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Assignment
{
    public class KargerMinCut
    {
        public IEnumerable<Vertex> Vertices { get; private set; }
        public IEnumerable<Edge> Edges { get; private set; }

        public KargerMinCut(IEnumerable<Vertex> vertices)
        {
            Vertices = vertices;
            Edges = Vertices.SelectMany(ver => ver.AdjacentVertexIds.Select(adjVId => new Edge(ver.Id, adjVId)));
        }

        public int GetCount()
        {
            foreach (var vertex in Vertices)
            {
                vertex.Parent = vertex;
                vertex.Rank = 0;

            }
            return 0;
        }
    }
}
