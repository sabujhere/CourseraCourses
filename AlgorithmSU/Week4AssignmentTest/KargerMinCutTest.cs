using System;
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
            var lines = File.ReadAllLines(fileLocation);
            var vertices = new List<Vertex>();
            foreach (var line in lines)
            {
                var lineItems = line.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                vertices.Add(new Vertex(int.Parse(lineItems.First()),lineItems.Skip(1).Select(adjV=>int.Parse(adjV)).ToArray()));
            }
            
        }
    }
}
