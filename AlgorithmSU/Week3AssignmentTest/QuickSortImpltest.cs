using System;
using System.Collections.ObjectModel;
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
    }
}
