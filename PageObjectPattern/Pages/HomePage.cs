using Logger = WebDriverBasics.Utilities.Logger;

namespace WebDriverBasics.Pages;

public class HomePage : BasePage
{
    private IWebDriver _driver;

    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator =>
        By.XPath("//div[@class='project-navigation project-navigation_overflow project-navigation_scroll']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Мобильные телефоны')]")]
    private IWebElement _mobilePhonesTab;

    [FindsBy(How = How.XPath, Using = "//div[@class='auth-bar__item auth-bar__item--text']")]
    private IWebElement _authButton;


    [AllureStep("Open Mobile Phones Tab")]
    public MobilePhonesPage ClickTab_MobilePhones()
    {
        Logger.Instance.Info($"Open {_mobilePhonesTab}");
        _mobilePhonesTab.Click();
        return new MobilePhonesPage(WebDriver);
    }

    public AuthPage ClickButton_Auth()
    {
        Logger.Instance.Info($"Click auth{_authButton}");
        _authButton.Click();

        return new AuthPage(WebDriver);
    }
}