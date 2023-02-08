namespace SeleniumWrapper.Utils;

public class Browser : IBrowser
{
    public static WebDriver WebDriver { get; private set; }

    public Browser(WebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    public void GoToUrl(Uri uri)
    {
        GoToUrl(uri.ToString());
    }
    
    public void GoToUrl(string uri)
    {
        WebDriver.Navigate().GoToUrl(uri);
    }

    public static void Quit()
    {
        WebDriver.Quit();
    }

    public static void MaximizeWindow()
    {
        WebDriver.Manage().Window.Maximize();
    }
    
    private void SetImplicitTime()
    {
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public bool IsStarted => WebDriver.SessionId != null;
}