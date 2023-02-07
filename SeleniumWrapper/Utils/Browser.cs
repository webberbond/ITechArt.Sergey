using OpenQA.Selenium;

namespace Selenium.Lection.SimpleWrapper.Core;

public class Browser : IBrowser
{
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
    
    public void GoToUrl(string uri)
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

    public bool IsStarted => WebDriver.SessionId != null;
}