using NUnit.Framework;

namespace TDD.SauceDemoTesting;

public class SauceDemoTests
{
    [Test]
    public void Login()
    {
        SauceDemo.StartBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");

        var element = SauceDemo.FindElement("#shopping_cart_container");
        Assert.IsTrue(element.Displayed);
    }

    [Test]
    public void AddToCart()
    {
        SauceDemo.StartBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");

        var element = SauceDemo.FindElement("Add");
        element.Click();
            
        element = SauceDemo.FindByClass(".shopping_cart_link");
        element.Click();

        element = SauceDemo.FindByClass(".shopping_cart_badge");
        Assert.AreEqual(element.GetAttribute("value"), "1");
    }

    [Test]
    public void Logout()
    {
        SauceDemo.StartBrowser();
        SauceDemo.Login("standard_user", "secret_sauce");

        var element = SauceDemo.FindElement("#react-burger-menu-btn");
        element.Click();

        element = SauceDemo.FindElement("#logout_sidebar_link");
        element.Click();

        element = SauceDemo.FindByClass(".submit-button");
        Assert.AreEqual(element.GetAttribute("value"), "Login");
    }

    private static class SauceDemo
    {
        public static void StartBrowser()
        {
            throw new NotFoundException();
        }

        public static void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public static IWebElement FindElement(string container)
        {
            throw new NotImplementedException();
        }
        public static IWebElement FindByClass(string value)
        {
            throw new NotImplementedException();
        }
    }
}