using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringMathOperations;

namespace StringMathOperationTest
{
    [TestClass]
    public class StringAdditionTest
    {
        [TestMethod]
        public void AddTwoNumbers()
        {
            var additionHelper = new StringAdditionImpl();

            var result = additionHelper.Add("5782", "7329");

            Assert.AreEqual("13111",result);
        }
    }
}
