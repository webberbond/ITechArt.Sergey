namespace SeleniumWrapper.Elements;

public abstract class BaseElement
{
    private By Locator { get; }

    private string Name { get; }

    protected BaseElement(By locator, string name)
    {
        Locator = locator;
        Name = name;
    }

    private WebDriver WebDriver => BrowserService.Browser.WebDriver;

    public void Click()
    {
        Logger.Instance.Info($"Click {Name} element");
        FindElement().Click();
    }

    public string GetText()
    {
        Logger.Instance.Info($"Take text from {Name} element");
        return FindElement().Text;
    }

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }

    protected IWebElement FindElement()
    {
        Logger.Instance.Info($"Find element with locator {Locator}");
        return WebDriver.FindElement(Locator);
    }
}