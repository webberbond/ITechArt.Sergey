namespace WebDriverBasics.Pages;

public class HomePage : BasePage
{
    private IWebDriver driver;
    public HomePage(IWebDriver webDriver) : base(webDriver) => PageFactory.InitElements(webDriver, this);

    protected override By UniqueWebLocator =>
        By.XPath("//div[@class='project-navigation project-navigation_overflow project-navigation_scroll']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Мобильные телефоны')]")]
    private IWebElement MobilePhonesTab;

public MobilePhonesPage ClickTab_MobilePhones()
    {
        MobilePhonesTab.Click();
        return new MobilePhonesPage(WebDriver);
    }
}