using OpenQA.Selenium;
using SeleniumWrapper;
using SeleniumWrapper.Elements;
using SeleniumWrapper.Helpers;
using SeleniumWrapper.Tests;
using SeleniumWrapper.Utils;
using SeleniumWrapperTests.Pages;

namespace SeleniumWrapperTests;

public class Tests 
{
    private Browser Browser => BrowserService.Browser;
  
    [Test]
    public void Test1()
    {
        Browser.GoToUrl($"{JsonReader.GetValueByKey("appsettings.json", "url")}");

        ProductsPage.AddProducts();
        ProductsPage.ClickShoppingCart();
    }
}
