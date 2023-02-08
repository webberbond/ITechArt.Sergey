using Logger = SeleniumWrapper.Helpers.Logger;
namespace SeleniumWrapper.Elements;

public abstract class BaseElement
{
    protected By Locator { get; }

    protected string Name { get; }

    protected BaseElement(By locator, string name)
    {
        Locator = locator;
        Name = name;
    }

    private WebDriver WebDriver => Browser.WebDriver;
    
    public void Click()
    {
        Logger.Instance.Info("Clicking");
        FindElement().Click();
    }

    public string GetText()
    {
        Logger.Instance.Info("Getting text");
        return FindElement().Text;
    }

    public bool IsDisplayed()
    {
        return FindElement().Displayed;
    }

    protected IWebElement FindElement()
    {
        Logger.Instance.Info("Finding element");
        return WebDriver.FindElement(Locator);
    }
}