using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringMathOperations;

namespace StringMathOperationTest
{
    [TestClass]
    public class StringSubtractionTest
    {
        [TestMethod]
        public void Subtract_WithEqualNumberOfDigits()
        {
            var subtractor = new StringSubtractorImpl();
            var term1 = "7329";
            var term2 = "5782";
            var exptectedResult = int.Parse(term1) - int.Parse(term2);
            var result = subtractor.Subtract(term1, term2);

            Assert.AreEqual(exptectedResult.ToString(),result);
        }

        [TestMethod]
        public void Subtract_WithUnEqualNumberOfDigits()
        {
            var subtractor = new StringSubtractorImpl();
            var term1 = "5782";
            var term2 = "73";
            var exptectedResult = int.Parse(term1) - int.Parse(term2);
            var result = subtractor.Subtract(term1, term2);

            Assert.AreEqual(exptectedResult.ToString(),result);
        }
    }
}
