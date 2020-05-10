using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week4Assignment;

namespace Week4AssignmentTest
{
    [TestClass]
    public class KargerMinCutTest
    {
        [TestMethod]
        public void CalcualteMinCutTest()
        {
            //Arrange
            var fileLocation = @"..\..\TestData\SampleData_kargerMinCut.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");
            var lines = File.ReadAllLines(fileLocation).Where(line=> !string.IsNullOrEmpty(line));
            var vertices = new List<Vertex>();
            foreach (var line in lines)
            {
                var lineItems = line.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                vertices.Add(new Vertex(int.Parse(lineItems.First()),lineItems.Skip(1).Select(int.Parse).ToArray()));
            }
            vertices.Sort();
            var maxIteration = (int)Math.Pow(vertices.Count, 2);
            var kargerAlgo = new KargerMinCut(vertices);
            var minCutCount = Enumerable.Range(0, maxIteration).Select(index => kargerAlgo.GetCount()).ToList().Min();
            Assert.IsTrue(minCutCount == 17);
        }
    }
}
