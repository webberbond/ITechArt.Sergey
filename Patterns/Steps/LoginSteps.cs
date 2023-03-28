namespace Patterns.Steps;

public class LoginSteps
{
    private Browser Browser { get; }

    private readonly LoginPage _loginPage;
    private readonly ProductsPage _productsPage;

    public LoginSteps(Browser browser)
    {
        Browser = browser;
        _loginPage = new LoginPage(Browser);
        _productsPage = new ProductsPage(Browser);
    }

    public LoginSteps Login(string username, string password)
    {
        _loginPage
            .OpenPage()
            .Login(username, password);

        return this;
    }

    public LoginSteps ValidateIsProductsPageOpened()
    {
        _productsPage
            .IsPageOpened();

        return this;
    }

    public LoginSteps ValidateErrorMessage(string errorMessage)
    {
        Assert.That(errorMessage, Is.EqualTo(_loginPage.GetErrorMessage()));

        return this;
    }
}