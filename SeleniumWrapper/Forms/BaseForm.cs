namespace SeleniumWrapper.Forms;

public abstract class BaseForm
{
    protected BaseForm(Browser browser)
    {
    }

    protected abstract By UniqueWebLocator { get; }


    private BaseElement UniqueElement => new Label(UniqueWebLocator, "Unique Element ");

    protected BaseForm(BaseElement uniqueElement, string nameOfPage)
    {
    }

    public bool IsPageOpened => UniqueElement.IsDisplayed();

    protected void WaitForPageOpened()
    {
        try
        {
            BrowserService.Browser.BrowserWait.Until(driver => driver.FindElement(UniqueWebLocator).Displayed);
        }
        catch (WebDriverTimeoutException e)
        {
            throw new NotImplementedException();
        }
    }
}