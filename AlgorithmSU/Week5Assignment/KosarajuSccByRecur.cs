using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week5Assignment
{
    public class KosarajuSccByRecur
    {
        private long rankNew = 0;
        private int numSCC = 0;
        private IEnumerable<KosarajuNode> nodes;

        public void Run(IEnumerable<KosarajuNode> graphNodes)
        {
            nodes = graphNodes;
            const int stackSize = 1024 * 1024 * 64;
            var thread = new Thread(Dowork, stackSize);
            thread.Start();
            thread.Join();


           
        }

        private void Dowork()
        {
            try
            {
                var nodeById = nodes.ToDictionary(node => node.Id);
                var orderedNode = nodeById.Values.OrderByDescending(node => node.Id);
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
