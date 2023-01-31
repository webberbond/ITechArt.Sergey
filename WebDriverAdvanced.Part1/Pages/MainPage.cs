namespace WebDriverBasics.Pages;

public class MainPage : BasePage
{
    private IWebDriver driver;

    public MainPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//div[@class='home-banner']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath,
        Using =
            "//body/div[@id='app']/div[@class='body-height']/div[@class='home-content']/div[@class='home-body']/div[@class='category-cards']/div[3]")]
    private IWebElement AlertsPage;

    [FindsBy(How = How.XPath,
        Using =
            "//body/div[@id='app']/div[@class='body-height']/div[@class='home-content']/div[@class='home-body']/div[@class='category-cards']/div[4]")]
    private IWebElement WidgetsPage;


    public void AlertsPageOpen()
    {
        AlertsPage.Click();
    }

    public void WidgetsPageOpen()
    {
        WidgetsPage.Click();
    }
}