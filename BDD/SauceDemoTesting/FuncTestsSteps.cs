using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TDD.SauceDemoTesting;
using TechTalk.SpecFlow;

namespace BDD.SauceDemoTesting;

[Binding]
public class FuncTestsSteps
{
    private SauceDemo _sauceDemo;
    [Given(@"I go to the website saucedemo\.com")]
    public void GivenIGoToTheWebsiteSaucedemoCom()
    {
        var webDriver = new ChromeDriver();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        webDriver.Manage().Window.Maximize();

        _sauceDemo = new SauceDemo(webDriver);
        _sauceDemo.StartBrowser("https://www.saucedemo.com/");
    }

    [Given(@"I fill username in the placeholder")]
    public void GivenIFillUsernameInThePlaceholder()
    {
        _sauceDemo.FillUsernameInput("standard_user");
    }

    [Given(@"I fill password in the placeholder")]
    public void GivenIFillPasswordInThePlaceholder()
    {
        _sauceDemo.FillPasswordInput("secret_sauce");
    }

    [When(@"I click button Login")]
    public void WhenIClickButtonLogin()
    { 
        _sauceDemo.SubmitLogin();
    }

    [Then(@"User should be logged in")]
    public void ThenUserShouldBeLoggedIn()
    {
        Assert.IsTrue(_sauceDemo.IsContainerIconAppeared());
    }

    [Given(@"User should be logged in")]
    public void GivenUserShouldBeLoggedIn()
    {
        Assert.IsTrue(_sauceDemo.IsContainerIconAppeared());
    }

    [Given(@"I click Add To Cart button")]
    public void GivenIClickAddToCartButton()
    {
        _sauceDemo.AddBackpackToCartButton();
    }

    [Given(@"I see that the item was added to the shopping cart container")]
    public void GivenISeeThatTheItemWasAddedToTheShoppingCartContainer()
    {
        Assert.AreEqual("1", _sauceDemo.BadgeValue());
    }

    [Then(@"Quite the browser")]
    public void ThenQuiteTheBrowser()
    {
        _sauceDemo.CloseBrowser();
    }

    [Given(@"Quite the browser")]
    public void GivenQuiteTheBrowser()
    {
        _sauceDemo.CloseBrowser();
    }

    [Given(@"I click Remove button")]
    public void GivenIClickRemoveButton()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"I click Add To Cart button")]
    public void ThenIClickAddToCartButton()
    {
        _sauceDemo.AddBackpackToCartButton();
    }

    [Then(@"I see that the item was added to the shopping cart container")]
    public void ThenISeeThatTheItemWasAddedToTheShoppingCartContainer()
    {
        _sauceDemo.IsShoppingBadgeIconAppeared();
    }

    [Then(@"I click Remove button")]
    public void ThenIClickRemoveButton()
    {
        _sauceDemo.RemoveBackpackFromCartButton();
    }

    [Then(@"I see that the item was removed from the shopping cart container")]
    public void ThenISeeThatTheItemWasRemovedFromTheShoppingCartContainer()
    {
        Assert.IsTrue(_sauceDemo.IsContainerIconAppeared());
    }
}