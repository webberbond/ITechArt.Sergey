namespace SeleniumWrapper.Forms;

public abstract class BaseForm
{
    protected Browser Browser { get; }

    protected BaseForm(Browser browser)
    {
        Browser = browser;
    }

    protected abstract By UniqueWebLocator { get; }


    private BaseElement UniqueElement => new Label(UniqueWebLocator, "Unique Element ");

    public bool IsPageOpened => UniqueElement.IsDisplayed();

    protected void WaitForPageOpened()
    {
        try
        {
            BrowserService.Browser.BrowserWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException)
        {
            throw new WebDriverTimeoutException();
        }
    }
}