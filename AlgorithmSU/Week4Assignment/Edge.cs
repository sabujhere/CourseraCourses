using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Assignment
{
    public class Edge:IComparable<Edge>
    {
        public int HeadId { get; private set; }

        public int TailId { get; set; }

        public Edge(int headId, int tailId)
        {
            HeadId = headId;
            TailId = tailId;
        }
        public int CompareTo(Edge other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var headIdComparison = HeadId.CompareTo(other.HeadId);
            if (headIdComparison != 0) return headIdComparison;
            return TailId.CompareTo(other.TailId);
        }
    }
}
