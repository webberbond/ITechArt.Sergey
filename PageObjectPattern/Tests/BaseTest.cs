namespace WebDriverBasics.Tests;

public abstract class BaseTest
{
    protected static IWebDriver WebDriver { get; private set; }

    protected HomePage HomePage { get; private set; }

    protected AuthPage AuthPage { get; private set; }

    protected ComparePage ComparePage { get; private set; }

    protected MobilePhonesPage MobilePhonesPage { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        HomePage = new HomePage(WebDriver);
        AuthPage = new AuthPage(WebDriver);
        MobilePhonesPage = new MobilePhonesPage(WebDriver);
        ComparePage = new ComparePage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        ScreenShotting.TakeScreenshot();
        WebDriver.Quit();
    }
}