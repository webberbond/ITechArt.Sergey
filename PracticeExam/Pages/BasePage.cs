namespace PracticeExam.Pages;

public abstract class BasePage
{
    private readonly string _baseUrl = Configurator.BaseUrl;

    protected BasePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    protected IWebDriver WebDriver { get; }

    private IWebElement UniqueWebElement => WebDriver.FindElement(UniqueWebLocator);

    protected abstract By UniqueWebLocator { get; }

    protected abstract string UrlPath { get; }

    public bool IsPageOpened
    {
        get
        {
            bool isOpened;
            try
            {
                isOpened = UniqueWebElement.Displayed;
            }
            catch (Exception e)
            {
                isOpened = false;
            }

            return isOpened;
        }
    }

    public void OpenPage()
    {
        var uri = new Uri(_baseUrl.TrimEnd('/') + UrlPath, UriKind.Absolute);
        WebDriver.Navigate().GoToUrl(uri);
    }
}