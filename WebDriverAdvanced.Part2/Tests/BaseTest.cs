using WebDriverBasics.Pages;

namespace WebDriverBasics.Tests;

public abstract class BaseTest
{
    protected IWebDriver WebDriver { get; private set; }


    protected AuthorizationPage AuthorizationPage { get; private set; }

    protected SliderPage SliderPage { get; private set; }

    protected UploadFilePage UploadFilePage { get; private set; }

    protected DownloadFilePage DownloadFilePage { get; private set; }

    protected HoversPage HoversPage { get; private set; }

    protected WindowsPage WindowsPage { get; private set; }

    [SetUp]
    public void SetUp()
    {
        WebDriver = new WebDriverFactory().GetDriver();
        WebDriver.Manage().Window.Maximize();
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        AuthorizationPage = new AuthorizationPage(WebDriver);
        SliderPage = new SliderPage(WebDriver);
        UploadFilePage = new UploadFilePage(WebDriver);
        DownloadFilePage = new DownloadFilePage(WebDriver);
        HoversPage = new HoversPage(WebDriver);
        WindowsPage = new WindowsPage(WebDriver);
    }

    [TearDown]
    public void TearDown()
    {
        WebDriver.Quit();
    }
}