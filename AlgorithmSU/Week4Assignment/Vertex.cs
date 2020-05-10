using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Assignment
{
    public class Vertex : IComparable<Vertex>
    {
        public int[] AdjacentVertexIds { get; private set; }
        public int Id { get; private set; }
        public Vertex Parent { get; set; }
        public int Rank { get; set; }

        public Vertex(int id):this(id,null)
        {
        }

        public Vertex(int id, int[] adjacentVertexIds)
        {
            Id = id;
            AdjacentVertexIds = adjacentVertexIds;
            Parent = this;
            Rank = 0;
        }

        public int CompareTo(Vertex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}
