using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week2Assignment;

namespace Week2AssignmentTest
{
    [TestClass]
    public class MergeSortImplTest
    {
        [TestMethod]
        public void Sort_IntCollection_Success()
        {
            var unsortedCollection = new Collection<int>()
            {
                1,5,4,7,9,3
            };
            var sorter = new MergeSortImpl<int>();

            var sortedResultActual = sorter.Sort(unsortedCollection);

            CollectionAssert.AreEqual(unsortedCollection.OrderBy(item=>item).ToList(),sortedResultActual.ToList());
        }

        [TestMethod]
        public void Sort_LargeDataSet_Pass()
        {
            //Arrange
            var fileLocation = @"..\..\TestData\IntegerArray.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");
            var lines = File.ReadAllLines(fileLocation);
            var unsortedCollection = lines.Select(line => Convert.ToInt32(line)).ToList();

            var sorter = new MergeSortImpl<int>();

            //Act
            var sortedResultActual = sorter.Sort(unsortedCollection);

            //Assert
            CollectionAssert.AreEqual(unsortedCollection.OrderBy(item=>item).ToList(),sortedResultActual.ToList());

        }
    }
}
