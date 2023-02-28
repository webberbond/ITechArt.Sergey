using OpenQA.Selenium.Support.UI;
using Patterns.Components;

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

    private BaseComponents BaseComponents => new();

    protected abstract override By UniqueWebLocator { get; }

    protected static readonly string? BaseUrl = AppConfiguration.BaseUrl;

    public string GetItemName()
    {
        return BaseComponents.ItemName.GetText();
    }

    public string GetItemPrice()
    {
        return BaseComponents.ItemPrice.GetText();
    }

    public BasePage ClickBurgerMenu()
    {
        BaseComponents.BurgerMenu.Click();

        return this;
    }

    public BasePage ClickLogout()
    {
        BaseComponents.Logout.Click();

        return this;
    }
}