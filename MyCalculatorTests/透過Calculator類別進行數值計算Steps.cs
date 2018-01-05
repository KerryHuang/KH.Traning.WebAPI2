using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator;
using System;
using TechTalk.SpecFlow;

namespace MyCalculatorTests
{
    [Binding]
    public class 透過Calculator類別進行數值計算Steps
    {
        private Calculator target;

        [BeforeScenario()]
        public void BeforeFeatureCalculator()
        {
            target = new Calculator();
            ScenarioContext.Current.Clear();
        }

        [AfterScenario()]
        public void AfterFeatureCalculator()
        {
            ScenarioContext.Current.Clear();
        }

        [Given(@"我輸入第一個整數(.*)到計算機")]
        public void Given我輸入第一個整數到計算機(int p0)
        {
            ScenarioContext.Current.Add("first", p0);

        }

        [Given(@"我輸入第二個整數(.*)到計算機")]
        public void Given我輸入第二個整數到計算機(int p0)
        {
            ScenarioContext.Current.Add("second", p0);
        }

        [When(@"呼叫Calculator的Add的int多載方法")]
        public void When呼叫Calculator的Add的Int多載方法()
        {
            var first = (int)ScenarioContext.Current["first"];
            var second = (int)ScenarioContext.Current["second"];

            var result = target.Add(first, second);

            ScenarioContext.Current.Add("result", result);
        }

        [Then(@"應該得到整數結果為(.*)")]
        public void Then應該得到整數結果為(int p0)
        {
            var actual = p0;
            var expected = (int)ScenarioContext.Current["result"];

            Assert.AreEqual(expected, actual);
        }

        [Given(@"我輸入第一個浮點數(.*)到計算機")]
        public void Given我輸入第一個浮點數到計算機(double p0)
        {
            ScenarioContext.Current.Add("first", p0);
        }

        [Given(@"我輸入第二個浮點數(.*)到計算機")]
        public void Given我輸入第二個浮點數到計算機(double p0)
        {
            ScenarioContext.Current.Add("second", p0);
        }

        [When(@"呼叫Calculator的Add的double多載方法")]
        public void When呼叫Calculator的Add的Double多載方法()
        {
            var first = (double)ScenarioContext.Current["first"];
            var second = (double)ScenarioContext.Current["second"];

            var result = target.Add(first, second);

            ScenarioContext.Current.Add("result", result);
        }

        [Then(@"應該得到浮點數結果為(.*)")]
        public void Then應該得到浮點數結果為(double p0)
        {
            var actual = p0;
            var expected = (double)ScenarioContext.Current["result"];

            Assert.AreEqual(expected, actual);
        }

    }
}
