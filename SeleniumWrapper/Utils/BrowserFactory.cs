namespace SeleniumWrapper.Utils;

public abstract class BrowserFactory
{
    public Browser GetBrowser => new(WebDriver);

    protected abstract WebDriver WebDriver { get; }
}