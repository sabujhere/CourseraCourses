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
            var term1 =  "3141592653589793238462643383279502884197169399375105820974944592";
            var term2 = "2718281828459045235360287471352662497757247093699959574966967627";
            var expectedResult ="8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184";//int.Parse(term1) * int.Parse(term2);
            var result = multiplyHelper.Multiply(term1, term2);

            Assert.AreEqual(expectedResult,result);
        }
    }
}
