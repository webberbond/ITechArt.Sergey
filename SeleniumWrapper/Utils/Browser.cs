namespace SeleniumWrapper.Utils;

public class Browser : IBrowser
{
    public WebDriverWait BrowserWait { get; set; }
    public WebDriver WebDriver { get; }

    public Browser(WebDriver webDriver)
    {
        Logger.Instance.Info("Starting Browser");
        WebDriver = webDriver;
        SetImplicitTime();
        MaximizeWindow();
    }

    public void GoToUrl(Uri uri)
    {
        GoToUrl(uri.ToString());
    }

    private void GoToUrl(string uri)
    {
        Logger.Instance.Info($"Go To Url {uri}");
        WebDriver.Navigate().GoToUrl(uri);
    }

    public void Quit()
    {
        Logger.Instance.Info("Quit Browser");
        WebDriver.Quit();
    }

    private void MaximizeWindow()
    {
        Logger.Instance.Info("Maximize Window");
        WebDriver.Manage().Window.Maximize();
    }

    private void SetImplicitTime()
    {
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public void BackPage()
    {
        Logger.Instance.Info("Navigate To Previous Page");
        WebDriver.Navigate().Back();
    }

    public bool IsStarted => WebDriver.SessionId != null;
}