namespace UnitTesting.Tests
{ 
    [Parallelizable]
    public class TestUI : BaseAttributes 
    {
        [Test]
        public void TestingInput()
        {
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(6)']")).Click();
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(9)']")).Click();
            
            var finalNum = driver.FindElement(By.Id("fld_1")).GetAttribute("value");

            driver.FindElement(By.XPath("//input[@type='button'][@onclick='javascript:operator(\"/\")']")).Click();
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(3)']")).Click();
            
            driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:equals()']")).Click();
            
            var afterDivide = driver.FindElement(By.Id("fld_5")).GetAttribute("value");
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual("169",finalNum);
                Assert.AreEqual("13", afterDivide);
            });
        }

        [Test]
        public void TestingView()
        {
            driver.FindElement(By.XPath("//button[normalize-space()='View']")).Click();

            var element = driver.FindElement(By.XPath("//input[@id='trig']"));
            element.Click();
            driver.SwitchTo().Alert().Accept();

            var sinButton = driver.FindElement(By.CssSelector("button[onclick='javascript:trigfunc(\"sin\")']")).Displayed;
        } 
    }
}