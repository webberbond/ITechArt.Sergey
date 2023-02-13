using OpenQA.Selenium.Support.UI;

namespace Patterns.Pages;

public abstract class BasePage : BaseForm
{
    protected Browser Browser { get; }

    protected static WebDriver WebDriver => BrowserService.Browser.WebDriver;

    protected readonly WebDriverWait Wait = new(WebDriver, TimeSpan.FromSeconds(5));

    protected BasePage(BaseElement uniqueElement, string pageName, Browser browser) : base(uniqueElement, pageName)
    {
        Browser = browser;
    }

    protected BasePage(Browser browser) : base(browser)
    {
        Browser = browser;
    }

    protected abstract override By UniqueWebLocator { get; }

    protected static readonly string? BaseUrl = AppConfiguration.BaseUrl;
}