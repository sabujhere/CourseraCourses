using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringMathOperations;

namespace StringMathOperationTest
{
    [TestClass]
    public class StringAdditionTest
    {
        [TestMethod]
        public void AddTwoNumbers_WithEqualNumberOfDigits()
        {
            var additionHelper = new StringAdditionImpl();
            var term1 = "5782";
            var term2 = "7329";
            var exptectedResult = int.Parse(term1) + int.Parse(term2);
            var result = additionHelper.Add(term1, term2);

            Assert.AreEqual(exptectedResult.ToString(),result);
        }

        [TestMethod]
        public void AddTwoNumbers_WithUnEqualNumberOfDigits()
        {
            var additionHelper = new StringAdditionImpl();
            var term1 = "5782";
            var term2 = "73";
            var exptectedResult = int.Parse(term1) + int.Parse(term2);
            var result = additionHelper.Add("5782", "73");

            Assert.AreEqual(exptectedResult.ToString(),result);
        }
    }
}
