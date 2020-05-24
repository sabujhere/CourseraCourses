using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week5Assignment;

namespace Week5AssignmentTest
{
    [TestClass]
    public class Week5AssignmentTest
    {
        [TestMethod]
        public void UoW_InitialCondition_ExpectedResult()
        {
            //Arrange
            var edges = GetEdges().ToList();
            var nodesById = edges.Select(ed=>new KosarajuNode(ed.HeadNodeId))
                .Concat(edges.Select(ed=>new KosarajuNode(ed.TailNodeId)))
                .Distinct()
                .ToDictionary(node=>node.Id);
           

            foreach (var edge in edges)
            {
                nodesById[edge.HeadNodeId].AddAdjacentNode(edge.TailNodeId);
                nodesById[edge.TailNodeId].AddRevAdjacentNode(edge.HeadNodeId);
            }

            foreach (var node in nodesById.Values)
            {
                Console.WriteLine(node);
            }

            var graphAlgo = new KosarajuSccImpl();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var enumerable = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            foreach (var group in enumerable)
            {
                Console.WriteLine($"Member count: {group.Count()}");

            }
        }

        private IEnumerable<Edge> GetEdges()
        {
            var fileLocation = @"..\..\TestData\SCC_Test.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");
            var lines = File.ReadAllLines(fileLocation).Where(line => !string.IsNullOrEmpty(line));
            var edges = new List<Edge>();
            foreach (var line in lines)
            {
                var lineItems = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                edges.Add(new Edge(int.Parse(lineItems[0]), int.Parse(lineItems[1])));
            }
            return edges;
        }
    }
}
