namespace UnitTesting.Tests
{
    [SingleThreaded]
    public class TestTrigFunc : BaseAttributes
    {
        [SetUp, Category("Getting OS Version")]
        public void GetOs()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//button[normalize-space()='View']")).Click();

            var element = driver.FindElement(By.XPath("//input[@id='trig']"));
            element.Click();
            driver.SwitchTo().Alert().Accept();
        }
        
        [Test]
        public void TestSin()
        {
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            driver.FindElement(By.CssSelector("button[onclick='javascript:trigfunc(\"sin\")']")).Click();

            string expectedNum = "0.8414709848078965";
            var finalNum = driver.FindElement(By.Id("fld_4")).GetAttribute("value");
            
            Assert.AreEqual(expectedNum, finalNum);
        }

        [Test]
        public void TestCos()
        {
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            driver.FindElement(By.CssSelector("button[onclick='javascript:trigfunc(\"cos\")']")).Click();

            string expectedNum = "0.5403023058681398";
            var finalNum = driver.FindElement(By.Id("fld_4")).GetAttribute("value");
            
            Assert.AreEqual(expectedNum, finalNum);
        }

        [Ignore("Not important")]
        public void TestAtan()
        {
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(8)']")).Click();
            driver.FindElement(By.CssSelector("button[onclick='javascript:trigfunc(\"atan\")']")).Clear();

            string expectedNum = "1.446441332248135";
            var finalNum = driver.FindElement(By.Id("fld_4")).GetAttribute("value");

            Assert.AreEqual(expectedNum, finalNum);
        }
    }
}