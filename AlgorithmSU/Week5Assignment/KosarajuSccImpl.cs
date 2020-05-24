using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Assignment
{
    public class KosarajuSccImpl
    {
        public void Run(IEnumerable<KosarajuNode> graphNodes)
        {
            var nodeById = graphNodes.ToDictionary(node => node.Id);
            var orderedNode = nodeById.Values.OrderByDescending(node => node.Id);
            Stack<KosarajuNode> processingNodesStack = new Stack<KosarajuNode>();
            long rank = 0;
            var secondIterationCollection = new KosarajuNode[nodeById.Values.Count];
            foreach (var currentOuterNode in orderedNode)
            {
                if(currentOuterNode.Explored) continue;
                processingNodesStack.Push(currentOuterNode);

                while (processingNodesStack.Count > 0)
                {
                    var currentNode = processingNodesStack.Pop();
                    if (currentNode.Explored)
                    {
                        rank += 1;
                        currentNode.CurrentLabel = rank;
                        secondIterationCollection[rank - 1] = currentNode;
                        continue;
                    }
                    currentNode.Explored = true;
                   
                    processingNodesStack.Push(currentNode);
                    foreach (var currentNodeRevAdjacentNodeId in currentNode.RevAdjacentNodeIds)
                    {
                        var nextNode = nodeById[currentNodeRevAdjacentNodeId];
                        if (nextNode.Explored)
                        {
                            continue;
                        }
                        processingNodesStack.Push(nextNode);
                    }
                }
            }

            secondIterationCollection = secondIterationCollection.ToList().Select(node =>
            {
                node.Explored = false;
                return node;
            }).ToArray();
            var sccNumber = 0;
            for (int i = secondIterationCollection.Length -1 ; i >= 0; i--)
            {
                var currentOuterNode = secondIterationCollection[i];
                if (currentOuterNode.Explored) continue;
                sccNumber += 1;
                processingNodesStack.Push(currentOuterNode);
                while (processingNodesStack.Count > 0)
                {
                    var currentNode = processingNodesStack.Pop();
                    if (currentNode.Explored)
                    {
                        currentNode.SCCNumber = sccNumber;
                        continue;
                    }
                    currentNode.Explored = true;

                    processingNodesStack.Push(currentNode);
                    foreach (var currentNodeAdjacentNodeId in currentNode.AdjacentNodeIds)
                    {
                        var nextNode = nodeById[currentNodeAdjacentNodeId];
                        if (nextNode.Explored)
                        {
                            continue;
                        }
                        processingNodesStack.Push(nextNode);
                    }
                }

            }
        }
    }
}
