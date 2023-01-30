namespace WebDriverBasics.Pages;

public class WindowsPage : BasePage
{
    private IWebDriver driver;

    public WindowsPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => string.Empty;

    protected override string _baseUrl => "http://the-internet.herokuapp.com/windows ";

    protected override By? UniqueWebLocator => By.XPath("//h3[normalize-space()='Opening a new window']");

    [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Click Here']")]
    private IWebElement _clickButton;

    [FindsBy(How = How.XPath, Using = "//h3")]
    private IWebElement _newTabText;

    public void OpenNewTab()
    {
        _clickButton.Click();
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
    }

    public void SwitchToFirstTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
    }

    public void CloseSecondTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles[1]);
        WebDriver.Close();
    }

    public void CloseMainTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles[0]);
        WebDriver.Close();
    }

    public void CloseLastTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
        WebDriver.Close();
    }

    public bool IfTabTitleRight()
    {
        if (WebDriver.Title == "New Window")
            return true;

        return false;
    }

    public bool IfTextDisplayed()
    {
        if (_newTabText.Displayed || _newTabText.Text == "New Window")
            return true;

        return false;
    }
}