using WebDriverBasics.Pages;

namespace WebDriverBasics.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }

    protected HomePage HomePage { get; private set; }

    protected MainPage MainPage { get; private set; }

    protected MyPage MyPage { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        HomePage = new HomePage(WebDriver);
        MainPage = new MainPage(WebDriver);
        MyPage = new MyPage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}