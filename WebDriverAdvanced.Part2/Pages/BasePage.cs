namespace WebDriverBasics.Pages;

public abstract class BasePage
{
    protected IWebDriver WebDriver { get; }

    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    private IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);

    protected abstract By? UniqueWebLocator { get; }

    protected abstract string UrlPath { get; }

    private const string UrlKey = "url";

    private readonly string _baseUrl = Configurator.GetConfiguration().GetSection(UrlKey).Value;

    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(uri);
    }

    public bool IsPageOpened
    {
        get
        {
            bool isOpened;
            try
            {
                isOpened = UniqueWebElement.Displayed;
            }
            catch (Exception)
            {
                isOpened = false;
            }

            return isOpened;
        }
    }
}