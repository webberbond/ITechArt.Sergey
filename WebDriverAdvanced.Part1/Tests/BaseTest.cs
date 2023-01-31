namespace WebDriverBasics.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }

    protected MainPage MainPage { get; private set; }

    protected AlertsPage AlertsPage { get; private set; }

    protected WidgetsPage WidgetsPage { get; private set; }


    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        MainPage = new MainPage(WebDriver);
        AlertsPage = new AlertsPage(WebDriver);
        WidgetsPage = new WidgetsPage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}