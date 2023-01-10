using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace TDD.SauceDemoTesting;

public class SauceDemoTests
{
    private IWebDriver _webDriver;
    [SetUp]
    public void SetupDriver()
    {
        _webDriver = new ChromeDriver();
        _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5); 
        _webDriver.Manage().Window.Maximize();
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        TestContext.WriteLine("Successfully started");
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver.Quit();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        TestContext.WriteLine("Successfully stopped");
    }

    [Test]
    [Author("Sergey"), Category("Testing Login function")]
    public void Login()
    {
        var sauceDemo = new SauceDemo(_webDriver);

        var userName = "standard_user";
        var password = "secret_sauce";
        
        sauceDemo.StartBrowser("https://www.saucedemo.com/");
        sauceDemo.FillUsernameInput(userName);
        sauceDemo.FillPasswordInput(password);
        sauceDemo.SubmitLogin();
        
        Assert.IsTrue(sauceDemo.IsContainerIconAppeared());
    }

    [Test]
    [Retry(2)]
    public void AddToCart()
    {
        var sauceDemo = new SauceDemo(_webDriver);
        Login();
        sauceDemo.AddBackpackToCartButton();
        sauceDemo.ClickCart();
        
        Assert.Multiple(() =>
        {
            Assert.IsTrue(sauceDemo.IsShoppingBadgeIconAppeared()); 
            Assert.AreEqual("1", sauceDemo.BadgeValue());
            
        });
    }

    [Test]
    public void AddAndRemove()
    {
        var sauceDemo = new SauceDemo(_webDriver);
        Login();
        sauceDemo.AddBackpackToCartButton();
        Assert.AreEqual("1", sauceDemo.BadgeValue());
        
        sauceDemo.RemoveBackpackFromCartButton();
        Assert.IsTrue(sauceDemo.IsContainerIconAppeared());
    }
}
public class SauceDemo
{
    private IWebDriver WebDriver { get; }

    public SauceDemo(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }
    private IWebElement UsernameInput => WebDriver.FindElement(By.CssSelector("#user-name"));
    private IWebElement PasswordInput => WebDriver.FindElement(By.CssSelector("#password"));
    private IWebElement LoginButton => WebDriver.FindElement(By.CssSelector("#login-button"));
    private IWebElement Container => WebDriver.FindElement(By.CssSelector("#shopping_cart_container"));
    private IWebElement BackpackToCartButton => WebDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack"));
    private IWebElement ShoppingCart => WebDriver.FindElement(By.CssSelector(".shopping_cart_link"));
    private IWebElement ShoppingCartBadge => WebDriver.FindElement(By.CssSelector(".shopping_cart_badge"));
    private IWebElement BackpackRemove => WebDriver.FindElement(By.CssSelector("#remove-sauce-labs-backpack"));
    public void StartBrowser(string url)
    {
        WebDriver.Navigate().GoToUrl(url);
    }
    public void FillUsernameInput(string user)
    {
        UsernameInput.SendKeys(user);
    }
    public void FillPasswordInput(string password)
    {
        PasswordInput.SendKeys(password);
    }
    public void SubmitLogin()
    {
        LoginButton.Click();
    }
    public bool IsLoginButtonDisplayed()
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
        return LoginButton.Displayed;
    }
    public bool IsContainerIconAppeared()
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
        return Container.Displayed;
    }
    public void AddBackpackToCartButton()
    {
        BackpackToCartButton.Click();
    }
    public void ClickCart()
    {
        ShoppingCart.Click();
    }
    public bool IsShoppingBadgeIconAppeared()
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
        return ShoppingCartBadge.Displayed;
    }
    public string BadgeValue()
    { 
        return ShoppingCartBadge.Text;
    }
    public void RemoveBackpackFromCartButton()
    {
        BackpackRemove.Click();
    }
    public void CloseBrowser()
    {
        WebDriver.Quit();
    }
}