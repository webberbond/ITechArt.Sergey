using Patterns.Components;

namespace Patterns.Pages;

public sealed class LoginPage : BasePage
{
    public LoginPage(Browser browser) : base(browser)
    {
    }

    private LoginPageComponents LoginPageComponents => new();

    protected override By UniqueWebLocator => By.XPath("//input[@id='login-button']");

    public LoginPage OpenPage()
    {
        WebDriver.Navigate().GoToUrl(BaseUrl);
        IsPageOpened();

        return this;
    }

    private new LoginPage IsPageOpened()
    {
        try
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(UniqueWebLocator));
        }
        catch (TimeoutException)
        {
            Logger.Instance.Info("Page was not opened");
        }

        return this;
    }

    public ProductsPage Login(string username, string password)
    {
        LoginPageComponents.Login.SendText(username);
        LoginPageComponents.Password.SendText(password);
        LoginPageComponents.LoginButton.Click();

        return new ProductsPage(Browser);
    }

    public string GetErrorMessage()
    {
        return LoginPageComponents.ErrorContainer.GetText();
    }

    public LoginPage EnterUsername(SauceDemo sauceDemo)
    {
        LoginPageComponents.Login.SendText(sauceDemo.GetUserName());

        return this;
    }

    public LoginPage EnterPassword(SauceDemo sauceDemo)
    {
        LoginPageComponents.Password.SendText(sauceDemo.GetPassword());

        return this;
    }

    public LoginPage ClickLogin()
    {
        LoginPageComponents.LoginButton.Click();

        return this;
    }
}