// <copyright file="CalculatorTest.cs">Copyright ©  2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator;

namespace MyCalculator.Tests
{
    /// <summary>此類別包含 Calculator 的參數化單元測試</summary>
    [PexClass(typeof(Calculator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CalculatorTest
    {
        /// <summary>Square(Int32) 的測試虛設常式</summary>
        [PexMethod]
        public int SquareTest([PexAssumeUnderTest]Calculator target, int num)
        {
            int result = target.Square(num);
            return result;
            // TODO: 將判斷提示加入 方法 CalculatorTest.SquareTest(Calculator, Int32)
        }
    }
}
