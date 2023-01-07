using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace ITechArt.Sergey.SeleniumBegin
{
    public class Tests
    {
        private IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://uzmarketing.com/";
        }

        [Test]
        public void Test_MarketingTools()
        {
            _driver.FindElement(By.XPath("//*[text()='Services']")).Click();
            bool visible = _driver.FindElement(By.XPath("//*[@class='fa fa-wrench fa-fw']")).Displayed;
            TestContext.WriteLine(visible);
        }

        [Test]
        public void Test_CreativeExecutions()
        {
            _driver.FindElement(By.XPath("//li[@id='menu-item-2522']//a[normalize-space()='Creative Executions']")).Click();
            bool creativeExecutions = _driver.FindElement(By.XPath("//*[text()='Graphic Design']")).Displayed;
            TestContext.WriteLine(creativeExecutions);
        }

        [Test]
        public void Test_Contact()
        {
            _driver.FindElement(By.XPath("//strong[text()='Contact']")).Click();

            string expectedFaxNumber = "Fax: (800) 217-9962";
            var faxNumberPath = _driver.FindElement(By.XPath("//span[@class][4]"));
            string actualFaxNumber = faxNumberPath.Text;
            Assert.AreEqual(expectedFaxNumber, actualFaxNumber);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}