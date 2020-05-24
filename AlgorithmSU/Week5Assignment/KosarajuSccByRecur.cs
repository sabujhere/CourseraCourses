using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Assignment
{
    public class KosarajuSccByRecur
    {
        private long rankNew = 0;
        private int numSCC = 0;

        public void Run(IEnumerable<KosarajuNode> graphNodes)
        {
            var nodeById = graphNodes.ToDictionary(node => node.Id);
            var orderedNode = nodeById.Values.OrderBy(node => node.Id);
            Stack<KosarajuNode> processingNodesStack = new Stack<KosarajuNode>();
            long rank = 0;
            var secondIterationCollection = new KosarajuNode[nodeById.Values.Count];
            rankNew = 0; // nodeById.Values.Count;
            foreach (var currentOuterNode in orderedNode)
            {
                if (!currentOuterNode.Explored)
                    DfsTopo(currentOuterNode, nodeById, secondIterationCollection);
            }

            secondIterationCollection = secondIterationCollection.ToList().Select(node =>
            {
                node.Explored = false;
                return node;
            }).ToArray();
            //var sccNumber = 0;
            numSCC = 0;
            for (int i = secondIterationCollection.Length - 1; i >= 0; i--)
            {
                var currentOuterNode = secondIterationCollection[i];
                if (!currentOuterNode.Explored)
                {
                    numSCC = numSCC + 1;
                    DfsTopoSCC(currentOuterNode, nodeById);
                }
            }
        
        }
        private void DfsTopoSCC(KosarajuNode currentNode, Dictionary<long, KosarajuNode> nodeById)
        {
            currentNode.Explored = true;
            currentNode.SCCNumber = numSCC;
            foreach (var currentNodeAdjacentNodeId in currentNode.AdjacentNodeIds)
            {
                var nextNode = nodeById[currentNodeAdjacentNodeId];
                if (!nextNode.Explored)
                    DfsTopoSCC(nextNode, nodeById);
            }
        }

        private void DfsTopo(KosarajuNode currentNode, Dictionary<long, KosarajuNode> nodeById,
            KosarajuNode[] secondIterationCollection)
        {
            currentNode.Explored = true;
            foreach (var currentNodeAdjacentNodeId in currentNode.RevAdjacentNodeIds)
            {
                var nextNode = nodeById[currentNodeAdjacentNodeId];
                if (!nextNode.Explored)
                    DfsTopo(nextNode, nodeById, secondIterationCollection);
            }

            rankNew = rankNew + 1;
            currentNode.CurrentLabel = rankNew;
            secondIterationCollection[rankNew - 1] = currentNode;
            //rankNew -= 1;

        }
    }
}
