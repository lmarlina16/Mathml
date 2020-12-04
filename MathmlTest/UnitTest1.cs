using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathml;

namespace MathmlTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PerformOperationSumTest()
        {
            string name = "Joe";
            int n1 = 25;
            int n2 = 5;
            string op = "SUM";
            int ans = n1+n2;
            string expectedResponse = name + " - " + op + " - " + n1 + " + " + n2 + " = " + ans;

            MathmlHelper m = new Mathml.MathmlHelper();
            string response = m.PerformOperation(n1, n2, op, name);

            Assert.AreEqual(expectedResponse, response);
        }
        [TestMethod]
        public void PerformOperationMultiplyTest()
        {
            string name = "Joe";
            int n1 = 20;
            int n2 = 5;
            string op = "MULTIPLY";
            int ans = n1 * n2;
            string expectedResponse = name + " - " + op + " - " + n1 + " * " + n2 + " = " + ans;

            MathmlHelper m = new Mathml.MathmlHelper();
            string response = m.PerformOperation(n1, n2, op, name);

            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void PerformOperationSubTest()
        {
            string name = "Joe";
            int n1 = 20;
            int n2 = 5;
            string op = "SUB";
            int ans = n1 - n2;
            string expectedResponse = name + " - " + op + " - " + n1 + " - " + n2 + " = " + ans;

            MathmlHelper m = new Mathml.MathmlHelper();
            string response = m.PerformOperation(n1, n2, op, name);

            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void PerformOperationDivideTest()
        {
            string name = "Joe";
            int n1 = 20;
            int n2 = 5;
            string op = "DIVIDE";
            int ans = n1/n2;
            string expectedResponse = name + " - " + op + " - " + n1 + " / " + n2 + " = " + ans;

            MathmlHelper m = new Mathml.MathmlHelper();
            string response = m.PerformOperation(n1, n2, op, name);

            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void IsValidDigitTest()
        {
            string name = "Joe";
            string s = "15o";
            bool expectedResponse = false;

            MathmlHelper m = new Mathml.MathmlHelper();
            bool response = m.IsValidDigit(name,s);

            Assert.AreEqual(expectedResponse, response);
        }
    }
}
/*
Tests for correct and incorrect data.
1. Input file exists. If yes, proceed else return;
2. Operation calculations (unit tests) for both correct and incorrect input.
3. Values are valid digits - error handling inside code

 */