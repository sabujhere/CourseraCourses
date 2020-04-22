using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringMathOperations;

namespace StringMathOperationTest
{
    [TestClass]
    public class KaratsubaStringMultiplicationImplTest
    {
        [TestMethod]
        public void MultiplyTwoNumbers_WithEqualNumberOfDigits()
        {
            var multiplyHelper = new KaratsubaStringMultiplicationImpl();;
            var term1 =  "5782";
            var term2 = "7329";
            var exptectedResult = int.Parse(term1) * int.Parse(term2);
            var result = multiplyHelper.Multiply(term1, term2);

            Assert.AreEqual(exptectedResult.ToString(),result);
        }
    }
}
