namespace WebDriverBasics.Pages;

public class WidgetsPage : BasePage
{
    private IWebDriver driver;

    public WidgetsPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//div[@class='main-header'][text()='Widgets']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']//li[@id='item-4'][.='Progress Bar']")]
    private IWebElement ProgressBarButton;

    [FindsBy(How = How.XPath, Using = "//div[@role='progressbar']")]
    private IWebElement ProgressBarLabel;

    [FindsBy(How = How.XPath, Using = "//button[@id='startStopButton']")]
    private IWebElement StartButton;

    public void StopProgressBarOnSpecificPercent(string a)
    {
        var i = 1;
        while (i == 1)
        {
            var b = ProgressBarLabel.Text;
            if (a.Equals(b))
            {
                StartButton.Click();
                i++;
            }
        }
    }

    public void ProgressBarButtonClick()
    {
        ProgressBarButton.Click();
        StartButton.Click();
    }

    public bool IsStopped()
    {
        if (ProgressBarLabel.Text.Contains("46"))
            return true;

        return false;
    }
}