using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Assignment
{
    public class DijkstraMinPathImpl
    {
        private int _unreachableDestination = 1000000;

        public Node[] Nodes { get; private set; }
        private int[] _minPaths;
        //private Node[] Nodes;
        private List<Node> _processedNodes;

        public DijkstraMinPathImpl(Node[] nodes)
        {
            Nodes = nodes;
        }

        public int[] CalculateMinPaths(int sourceNodeId)
        {
            Initialize(sourceNodeId);
            
            for (int i = 1; i < Nodes.Length; i++)
            {
                int minLength = _unreachableDestination;
                Node nextNodeToProcess = null;
                foreach (var processedNode in _processedNodes)
                {
                    foreach (var processedNodeAdjacentEdge in processedNode.AdjacentEdges)
                    {
                        var processingAdjacentNodeId = processedNodeAdjacentEdge.NodeId;
                        if (!_processedNodes.Contains(Nodes[processingAdjacentNodeId - 1]))
                        {
                            if (minLength > _minPaths[processedNode.Id - 1] + processedNodeAdjacentEdge.Weight)
                            {
                                minLength = _minPaths[processedNode.Id - 1] + processedNodeAdjacentEdge.Weight;
                                nextNodeToProcess = Nodes[processingAdjacentNodeId - 1];
                            }
                        }
                    }
                }
                if (nextNodeToProcess == null)
                {
                    // remaining node are unreachable
                    break;
                }
                _processedNodes.Add(nextNodeToProcess);
                _minPaths[nextNodeToProcess.Id - 1] = minLength;
            }
            return _minPaths;


        }

        private void Initialize(int sourceNodeId)
        {
            _minPaths = new int[Nodes.Length];
            for (int i = 0; i < Nodes.Length; i++)
            {
                _minPaths[i] = _unreachableDestination;
            }

            _minPaths[sourceNodeId - 1] = 0;
            _processedNodes = new List<Node>(){Nodes[sourceNodeId -1]};
        }
    }
}
