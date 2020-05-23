using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Assignment
{
    public class Node
    {
        private readonly ICollection<long> _adjacentNodeIds;
        public long Id { get; private set; }


        public IEnumerable<long> AdjacentNodeIds => _adjacentNodeIds;

        public Node(long id):this(id,Enumerable.Empty<long>())
        {
        }

        public Node(long id, IEnumerable<long> adjacentNodeIds)
        {
            _adjacentNodeIds = adjacentNodeIds.ToList();
            Id = id;
        }

        public void AddAdjacentNode(int id)
        {
            if(!_adjacentNodeIds.Contains(id))
                _adjacentNodeIds.Add(id);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(AdjacentNodeIds)}: {AdjacentNodeIds}";
        }
    }

    public class KosarajuNode : Node
    {
        private readonly ICollection<long> _reverseAdjacentNodeIds = new List<long>();
        public KosarajuNode(long id) : base(id)
        {
        }

        public KosarajuNode(long id, IEnumerable<long> adjacentNodeIds) : base(id, adjacentNodeIds)
        {
        }

        public bool Explored { get; set; }

        public long SCCNumber { get; set; }

        public IEnumerable<long> RevAdjacentNodeIds => _reverseAdjacentNodeIds;

        public void AddRevAdjacentNode(int id)
        {
            if (!_reverseAdjacentNodeIds.Contains(id))
                _reverseAdjacentNodeIds.Add(id);
        }

        public override string ToString()
        {
            return $"{base.ToString()},{nameof(RevAdjacentNodeIds)}: {RevAdjacentNodeIds}";
        }
    }
}
