namespace WebDriverBasics.Pages;

public class DownloadFilePage : BasePage
{
    private IWebDriver driver;

    public DownloadFilePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => "/download";

    protected override By? UniqueWebLocator => By.XPath("//h3[normalize-space()='File Downloader']");

    protected static string CurrentFile = string.Empty;

    protected static string Name = string.Empty;

    public void Download()
    {
        Name = WebDriver.FindElement(By.LinkText("SeleniumPicture.png")).Text;
        WebDriver.FindElement(By.LinkText("SeleniumPicture.png")).Click();
        Task.Delay(5000).Wait();
    }
}