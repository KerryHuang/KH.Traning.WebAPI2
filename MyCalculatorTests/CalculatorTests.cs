using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        //[TestMethod()]
        //public void AddTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void 測試Add方法_輸入1與2_得到3()
        {
            //arrange
            Calculator target = new Calculator();
            int firstNumber = 1;
            int secondNumber = 2;
            int expected = 3;

            //act
            int actual;
            actual = target.Add(firstNumber, secondNumber);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 測試Add小數點方法_輸入50點1與70點1_得到120點3()
        {
            //arrange
            Calculator target = new Calculator();
            var firstNumber = 50.1;
            var secondNumber = 70.1;
            var expected = 120.2;

            //act
            var actual = Math.Round(target.Add(firstNumber, secondNumber), 1);

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}