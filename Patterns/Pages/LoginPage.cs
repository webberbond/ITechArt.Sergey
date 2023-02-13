namespace Patterns.Pages;

public sealed class LoginPage : BasePage
{
    public LoginPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//input[@id='login-button']");

    private readonly TextField _login = new(By.XPath("//input[@id='user-name']"), "Login Input");

    private readonly TextField _password = new(By.XPath("//input[@id='password']"), "Password Input");

    private readonly Button _loginButton = new(By.XPath("//input[@id='login-button']"), "Login Button");

    private readonly Label _errorContainer =
        new(By.XPath("//div[@class='error-message-container error']"), "Error Label");

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
        _login.SendText(username);
        _password.SendText(password);
        _loginButton.Click();

        return new ProductsPage(Browser);
    }

    public string GetErrorMessage()
    {
        return _errorContainer.GetText();
    }

    public LoginPage EnterUsername(SauceDemo sauceDemo)
    {
        _login.SendText(sauceDemo.GetUserName());

        return this;
    }
    
    public LoginPage EnterPassword(SauceDemo sauceDemo)
    {
        _password.SendText(sauceDemo.GetPassword());

        return this;
    }
    
    public LoginPage ClickLogib()
    {
        _loginButton.Click();

        return this;
    }
}