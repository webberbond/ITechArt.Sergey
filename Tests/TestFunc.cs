namespace UnitTesting.Tests
{
    [NonParallelizable]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    public class TestFunc : BaseAttributes
    { 
        static object[] operators =
        {
            new object[] { "+", "15", "6", "21"},
            new object[] { "-", "21", "6", "15"},
            new object[] { "*", "13", "13", "169"},
            new object[] { "/", "169", "13", "13"}
        };

        void EnterNumber(string strNum)
        {
            var List = strNum.ToCharArray();
            foreach (var number in List)
            {
                driver.FindElement(By.XPath($"//input[@type='button'][@value='{number}']")).Click();
            }
        }
        
        [Test, Order(1), Author("Sergey")]
        [TestCase("16")]
        public void TestPlus(string value)
        {
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(2)']")).Click();
            
            driver.FindElement(By.XPath("//input[@type='button'][@onclick='javascript:operator(\"+\")']")).Click();
            
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(4)']")).Click();
            
            driver.FindElement(By.Id("equals_btn")).Click();
            var finalNum = driver.FindElement(By.Id("fld_5")).GetAttribute("value");
            
            Assert.AreEqual(value, finalNum );
        }

        [Test, Order(2), Retry(2)]
        [TestCase("8")]
        public void TestMinus(string value)
        {
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(2)']")).Click();
            
            driver.FindElement(By.XPath("//input[@type='button'][@onclick='javascript:operator(\"-\")']")).Click();
            
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(4)']")).Click();
            
            driver.FindElement(By.Id("equals_btn")).Click();
            var finalNum = driver.FindElement(By.Id("fld_5")).GetAttribute("value");
            
            Assert.AreEqual(value, finalNum );
        }

        [Category("Testing TestCaseSource")]
        [Test]
        [TestCaseSource(nameof(operators))]
        public void Actions(string oper, string firstVar, string secondVar, string expectedRes)
        {
            EnterNumber(firstVar);
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick='javascript:operator(\"{oper}\")']")).Click();
            EnterNumber(secondVar);
            driver.FindElement(By.Id("equals_btn")).Click();
            var displayedVal = driver.FindElement(By.XPath($"//input[@id='fld_5']"));
            switch (oper)
            {
                case "+":
                    Assert.AreEqual(displayedVal.GetAttribute("value"), expectedRes);
                    break;
                case "-":
                    Assert.AreEqual(displayedVal.GetAttribute("value"), expectedRes);
                    break;
                case "*":
                    Assert.AreEqual(displayedVal.GetAttribute("value"), expectedRes);
                    break;
                case "/":
                    Assert.AreEqual(displayedVal.GetAttribute("value"), expectedRes);
                    break;
            }
        }
    }
}