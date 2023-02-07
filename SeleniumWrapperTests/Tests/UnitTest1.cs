using OpenQA.Selenium;
using Selenium.Lection.SimpleWrapper.Core;
using SeleniumWrapper;
using SeleniumWrapper.Elements;

namespace SeleniumWrapperTests;

public class Tests
{
    private Browser Browser => BrowserService.Browser;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var url = "https://www.mediapark.uz/products/category/8";
        Browser.GoToUrl(url);
        
        Button FirstProduct = new Button(By.CssSelector("body > form:nth-child(8) > section:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(8) > img:nth-child(2)"), "First");
        
        FirstProduct.Click();
        
        Button SecondProduct = new Button(By.CssSelector("body > form:nth-child(8) > section:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > div:nth-child(8) > img:nth-child(2)"), "Second");

        SecondProduct.Click();
    }
}
