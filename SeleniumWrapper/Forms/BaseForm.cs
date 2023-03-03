namespace SeleniumWrapper.Forms;

public abstract class BaseForm
{
    protected Browser Browser { get; }

    protected BaseForm(Browser browser)
    {
        Browser = browser;
    }

    protected abstract By UniqueWebLocator { get; }


    protected BaseElement UniqueElement => new Label(UniqueWebLocator, "Unique Element ");

    public bool IsPageOpened => UniqueElement.IsDisplayed();

    private bool IsDisplayed()
    {
        return UniqueElement.IsDisplayed();
    }

    public void WaitForPageOpened()
    {
        try
        {
            Browser.BrowserWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException error)
        {
            var errorMessage = $"Page with unique locator'{UniqueWebLocator}' wasn't opened";
            Logger.Instance.Fatal(errorMessage);
            throw new AssertionException(errorMessage, error);
        }
    }
}