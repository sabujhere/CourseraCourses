using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week3Assignment;

namespace Week3AssignmentTest
{
    [TestClass]
    public class QuickSortImpltest
    {
        [TestMethod]
        public void Sort_IntCollection_Success()
        {
            var unsortedCollection = new Collection<int>()
            {
                3,8,2,5,1,4,7,6
            };

            IPivotPositionFinder pivotPositionFinder = new GetFirstIndexAsPivotImpl();
            var sorter = new QuickSortImpl<int>(pivotPositionFinder);

            var sortedResultActual = sorter.Sort(unsortedCollection);

            CollectionAssert.AreEqual(unsortedCollection.OrderBy(item=>item).ToList(),sortedResultActual.ToList());
        }

        [TestMethod]
        public void Sort_5ItemDataSet_ComparisonCountsMatches()
        {
            //Arrange
            var fileLocation = @"..\..\TestData\input_dgrcode_01_5.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");
            var lines = File.ReadAllLines(fileLocation);
            var unsortedCollection = lines.Select(line => Convert.ToInt32(line)).ToList();
            IPivotPositionFinder pivotPositionFinder = new GetFirstIndexAsPivotImpl();
            var sorter = new QuickSortImpl<int>(pivotPositionFinder);
            var expectedComparison = 6;
            //Act
            var sortedResultActual = sorter.Sort(unsortedCollection);

            //Assert
            Assert.AreEqual(expectedComparison,sorter.ComparisonCount);
        }

        [TestMethod]
        public void Sort_10ItemDataSet_ComparisonCountsMatches()
        {
            //Arrange
            var fileLocation = @"..\..\TestData\input_dgrcode_06_10.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");
            var lines = File.ReadAllLines(fileLocation);
            var unsortedCollection = lines.Select(line => Convert.ToInt32(line)).ToList();
            IPivotPositionFinder pivotPositionFinder = new GetFirstIndexAsPivotImpl();
            var sorter = new QuickSortImpl<int>(pivotPositionFinder);
            var expectedComparison = 26;
            //Act
            var sortedResultActual = sorter.Sort(unsortedCollection);

            //Assert
            Assert.AreEqual(expectedComparison,sorter.ComparisonCount);
        }

        [TestMethod]
        public void Sort_LargeDataSet_Pass()
        {
            //Arrange
            var fileLocation = @"..\..\TestData\QuickSort.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");
            var lines = File.ReadAllLines(fileLocation).Take(10);
            var unsortedCollection = lines.Select(line => Convert.ToInt32(line)).ToList();
            IPivotPositionFinder pivotPositionFinder = new GetFirstIndexAsPivotImpl();
            var sorter = new QuickSortImpl<int>(pivotPositionFinder);
            //Act
            var sortedResultActual = sorter.Sort(unsortedCollection);

            //Assert
            //Assert.AreEqual(expectedComparison,sorter.ComparisonCount);
            CollectionAssert.AreEqual(unsortedCollection.OrderBy(item=>item).ToList(),sortedResultActual.ToList());

        }
    }
}
