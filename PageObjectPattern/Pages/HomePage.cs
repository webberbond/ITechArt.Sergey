namespace WebDriverBasics.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//div[@class='logo__icon']");
    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//a[contains(.,'HERE')]")]
    private IWebElement NextPageButton;

    public void GoToNextPage()
    {
        NextPageButton.Click();
    }
}