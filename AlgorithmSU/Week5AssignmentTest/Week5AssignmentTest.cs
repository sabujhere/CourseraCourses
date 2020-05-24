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
        public void ElevenEdgesTest()
        {
            var fileLocation = @"..\..\TestData\11Edges.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            var expected = new List<int>(){3,3,3};
            CollectionAssert.AreEqual(expected,result.Select(grp=>grp.Count()).ToList());
        }

        [TestMethod]
        public void FourteenEdgesTest()
        {
            var fileLocation = @"..\..\TestData\14Edges.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            var expected = new List<int>() { 3, 3, 2 };
            CollectionAssert.AreEqual(expected, result.Select(grp => grp.Count()).OrderByDescending(num=>num).ToList());
        }

        [TestMethod]
        public void NineEdgesTest()
        {
            var fileLocation = @"..\..\TestData\9Edges.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            var expected = new List<int>() { 3, 3, 1, 1 };
            CollectionAssert.AreEqual(expected, result.Select(grp => grp.Count()).OrderByDescending(num => num).ToList());
        }

        [TestMethod]
        public void AnotherElevenEdgesTest()
        {
            var fileLocation = @"..\..\TestData\Another11Edges.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            var expected = new List<int>() { 7,1 };
            CollectionAssert.AreEqual(expected, result.Select(grp => grp.Count()).OrderByDescending(num => num).ToList());
        }

        [TestMethod]
        public void TwentyEdgesTest()
        {
            var fileLocation = @"..\..\TestData\20Edges.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            var expected = new List<int>() { 6,3,2,1 };
            CollectionAssert.AreEqual(expected, result.Select(grp => grp.Count()).OrderByDescending(num => num).ToList());
        }

        [TestMethod]
        public void AssignmentTest()
        {
            var fileLocation = @"..\..\TestData\SCC_Test.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            foreach (var group in result)
            {
                Console.WriteLine($"Member count: {group.Count()}");
            }
        }


        [TestMethod]
        public void TenEdgesTest()
        {
            var fileLocation = @"..\..\TestData\10Edges.txt";
            var edges = GetEdges(fileLocation).ToList();
            var nodesById = GetNodes(edges);
            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var result = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            var expected = new List<int>() { 4, 3, 3, 1 };
            CollectionAssert.AreEqual(expected, result.Select(grp => grp.Count()).OrderByDescending(num => num).ToList());
            //foreach (var group in result)
            //{
            //    Console.WriteLine($"Member count: {group.Count()}");
            //}
        }

        [TestMethod]
        public void FiveEdgesTest()
        {
            //Arrange
            var edges = Get5Edges(); //GetEdges().ToList();
            var nodesById = GetNodes(edges);

            var graphAlgo = new KosarajuSccByRecur();

            //Act
            graphAlgo.Run(nodesById.Values);

            //Assert
            var enumerable = nodesById.Values.GroupBy(node => node.SCCNumber).Take(5);
            foreach (var group in enumerable)
            {
                Console.WriteLine($"Member count: {group.Count()}");
            }
        }

        private Dictionary<long, KosarajuNode> GetNodes(IEnumerable<Edge> edges)
        {
            var nodesById = edges.Select(ed => ed.HeadNodeId)
                .Concat(edges.Select(ed => ed.TailNodeId))
                .Distinct()
                .Select(id => new KosarajuNode(id))
                .ToDictionary(node => node.Id);


            foreach (var edge in edges)
            {
                nodesById[edge.HeadNodeId].AddAdjacentNode(edge.TailNodeId);
                nodesById[edge.TailNodeId].AddRevAdjacentNode(edge.HeadNodeId);
            }

            return nodesById;
        }


        private IEnumerable<Edge> GetEdges(string fileLocation)
        {
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

        private IEnumerable<Edge> Get5Edges()
        {
            return new List<Edge>()
            {
                new Edge(1,2),
                new Edge(1,4),
                new Edge(2,3),
                new Edge(3,1),
                new Edge(5,4),
            };
        }
    }
}
