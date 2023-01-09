namespace UnitTesting.Tests
{ 
    [Parallelizable]
    public class TestUI : BaseAttributes 
    {
        [Test]
        public void TestingInput()
        {
            Driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            Driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(6)']")).Click();
            Driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(9)']")).Click();
            
            var finalNum = Driver.FindElement(By.Id("fld_1")).GetAttribute("value");

            Driver.FindElement(By.XPath("//input[@type='button'][@onclick='javascript:operator(\"/\")']")).Click();
            Driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(1)']")).Click();
            Driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:digit(3)']")).Click();
            
            Driver.FindElement(By.XPath($"//input[@type='button'][@onclick = 'javascript:equals()']")).Click();
            
            var afterDivide = Driver.FindElement(By.Id("fld_5")).GetAttribute("value");
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual("169",finalNum);
                Assert.AreEqual("13", afterDivide);
            });
        }

        [Test]
        public void TestingView()
        {
            Driver.FindElement(By.XPath("//button[normalize-space()='View']")).Click();

            var element = Driver.FindElement(By.XPath("//input[@id='trig']"));
            element.Click();
            Driver.SwitchTo().Alert().Accept();

            var sinButton = Driver.FindElement(By.CssSelector("button[onclick='javascript:trigfunc(\"sin\")']")).Displayed;
        } 
    }
}