using System;
using System.Collections.ObjectModel;
using System.Linq;
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
    }
}
