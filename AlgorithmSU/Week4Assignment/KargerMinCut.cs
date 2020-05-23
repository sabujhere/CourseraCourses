using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Assignment
{
    public class KargerMinCut
    {
        public List<Vertex> Vertices { get; private set; }
        public List<Edge> Edges { get; private set; }
        private readonly Random _rand = new Random();

        public KargerMinCut(IEnumerable<Vertex> vertices)
        {
            Vertices = vertices.ToList();
            Edges = Vertices.SelectMany(ver => ver.AdjacentVertexIds.Select(adjVId => new Edge(ver.Id, adjVId)))
                .ToList();
        }

        public int GetCount()
        {
            foreach (var vertex in Vertices)
            {
                vertex.Parent = vertex;
                vertex.Rank = 0;

            }

            var numberOfEdgesToProcess = Edges.Count() - 1;
            var mergedVertexCount = 0;
            while (numberOfEdgesToProcess >= 0)
            {
                var randomEdgeIndexSelected = _rand.Next(0, numberOfEdgesToProcess);
                var selectedEdge = Edges[randomEdgeIndexSelected];
                Vertex mergedHead = Vertices[selectedEdge.HeadId - 1];
                Vertex mergedTail = Vertices[selectedEdge.TailId - 1]; 

                Swap(randomEdgeIndexSelected, numberOfEdgesToProcess);
                numberOfEdgesToProcess--;

                if(UnionFind.Find(mergedHead).Id == UnionFind.Find(mergedTail).Id)
                    continue;
                
                UnionFind.Union(mergedHead, mergedTail);
                mergedVertexCount++;
                if(mergedVertexCount == Vertices.Count() - 2)
                    break;
            }

            int firstVerticeRootId = UnionFind.Find(Vertices.First()).Id;
            var hashSet = new HashSet<int>(Vertices.Where(v => UnionFind.Find(v).Id == firstVerticeRootId).Select(v => v.Id));
            var minCut = Edges.Count(e => hashSet.Contains(e.HeadId) && !hashSet.Contains(e.TailId));
            return minCut;
        }

        private void Swap(int randomEdgeIndexSelected, int numberOfEdgesToProcess)
        {
            var temp = Edges[randomEdgeIndexSelected];
            Edges[randomEdgeIndexSelected] = Edges[numberOfEdgesToProcess];
            Edges[numberOfEdgesToProcess] = temp;
        }
    }
}
