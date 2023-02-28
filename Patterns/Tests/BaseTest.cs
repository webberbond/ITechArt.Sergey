namespace Patterns.Tests;

public class BaseTest
{
    protected const string Username = "standard_user";
    protected const string Password = "secret_sauce";

    private Browser Browser { get; set; }

    protected static WebDriver WebDriver => BrowserService.Browser.WebDriver;

    protected LoginPage LoginPage { get; private set; }

    protected LoginSteps LoginSteps { get; private set; }

    protected ProductsPage ProductsPage { get; private set; }

    protected CheckoutPage CheckoutPage { get; private set; }

    protected SauceDemo SauceDemo { get; private set; }


    [SetUp]
    public void SetUp()
    {
        Browser = BrowserService.StartBrowser(AppConfiguration.BrowserProfile);

        LoginPage = new LoginPage(Browser);

        LoginSteps = new LoginSteps(Browser);

        ProductsPage = new ProductsPage(Browser);

        CheckoutPage = new CheckoutPage(Browser);

        SauceDemo = new SauceDemo();
    }

    [TearDown]
    public void TearDown()
    {
        ScreenShotting.TakeScreenshot();
        Browser.Quit();
    }
}