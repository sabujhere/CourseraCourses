using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Week2Assignment;

namespace Week2AssignmentTest
{
    [TestClass]
    public class InversionCounterUsingDivideConquerImplTest
    {
        [TestMethod]
        public void GetCount_SmallDataSet_Pass()
        {
            var unsortedCollection = new Collection<int>()
            {
                1,3,5,2,4,6
            };
            var counter = new InversionCounterUsingDivideConquerImpl();
            var expectedCount = 3;

            //Act
            var countActual = counter.GetCount(unsortedCollection);

            //Assert
            Assert.AreEqual(expectedCount,countActual);
        }

        [TestMethod]
        public void GetCount_LargerDataSet_Pass()
        {
            //Arrange
            var fileLocation = @"..\..\TestData\IntegerArray.txt";

            if (!File.Exists(fileLocation))
                Assert.Fail("File not found");

            var lines = File.ReadAllLines(fileLocation);
            var unsortedCollection = lines.Select(line => Convert.ToInt32(line)).ToList();

            var counter = new InversionCounterUsingDivideConquerImpl();
            var expectedCount = 2407905288;

            //Act
            var countActual = counter.GetCount(unsortedCollection);

            //Assert
            Assert.AreEqual(expectedCount,countActual);
        }
    }
}
