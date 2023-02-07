using Selenium.Lection.SimpleWrapper.Core;

namespace SeleniumWrapper.Elements;

public abstract class BaseElement
{
    protected By Locator { get; }

    protected string Name { get; }

    protected BaseElement(By locator, string name)
    {
        this.Locator = locator;
        Name = name;
    }

    private WebDriver WebDriver => BrowserService.Browser.WebDriver;

    public void Click()
    {
        FindElement().Click();
    }

    public string GetText()
    {
        return FindElement().Text;
    }

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }

    protected IWebElement FindElement()
    {
        return WebDriver.FindElement(Locator);
    }
}