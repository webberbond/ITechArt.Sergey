using OpenQA.Selenium;

namespace Selenium.Lection.SimpleWrapper.Core;

public abstract class BrowserFactory
{
    public BrowserProfile BrowserProfile { get; }

    protected BrowserFactory(BrowserProfile browserProfile)
    {
        BrowserProfile = browserProfile;
    }
    
    public Browser GetBrowser => new Browser(WebDriver);
    
    protected abstract WebDriver WebDriver { get; }
}