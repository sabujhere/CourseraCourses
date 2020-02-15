using System;
using IntegerMultiplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegerMultiplicationTest
{
    [TestClass]
    public class UnitTest1MathOperationOnStringNumbersTest
    {
        [TestMethod]
        public void StringAdditionTest()
        {
            //Arrange
            int num1 = 556;
            int num2 = 69874;
            //Act

            var result = MathOperationOnStringNumbers.StringAddition(num1.ToString(), num2.ToString());

            //Assert
            Assert.AreEqual(num1 + num2, Convert.ToInt32(result));
        }
    }
}
