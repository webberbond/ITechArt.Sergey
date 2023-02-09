namespace SeleniumWrapper.Utils;

public class Browser : IBrowser
{
    public WebDriverWait BrowserWait { get; set; }
    public WebDriver WebDriver { get; }

    public Browser(WebDriver webDriver)
    {
        WebDriver = webDriver;
        MaximizeWindow();
        SetImplicitTime();
    }

    public void GoToUrl(Uri uri)
    {
        GoToUrl(uri.ToString());
    }

    private void GoToUrl(string uri)
    {
        WebDriver.Navigate().GoToUrl(uri);
    }

    public void Quit()
    {
        WebDriver.Quit();
    }

    private void MaximizeWindow()
    {
        WebDriver.Manage().Window.Maximize();
    }

    private void SetImplicitTime()
    {
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public void BackPage()
    {
        WebDriver.Navigate().Back();
    }

    public bool IsStarted => WebDriver.SessionId != null;
}