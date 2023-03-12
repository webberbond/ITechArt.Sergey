namespace PracticeExam.Pages;

public class MainPage : BasePage
{
    public MainPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.CssSelector("body div pre");
    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.CssSelector, Using = ".text-h2")]
    public IWebElement TestTaskSection;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='15']")]
    private IWebElement _firstSelectedDate;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='20']")]
    private IWebElement _secondSelectedDate;

    [FindsBy(How = How.XPath, Using = "//div[@class='v-picker__title__btn v-date-picker-title__year']")]
    private IWebElement _yearButton;

    [FindsBy(How = How.XPath, Using = "//button[normalize-space()='November 2023']")]
    private IWebElement _yearAndMonthButton;

    [FindsBy(How = How.XPath, Using = "//li[normalize-space()='2018']")]
    private IWebElement _deselectiveYearButton;

    [FindsBy(How = How.CssSelector, Using = "li:nth-child(1)")]
    private IWebElement _addYearsList;

    [FindsBy(How = How.CssSelector, Using = "li:nth-child(201)")]
    private IWebElement _subtractYearsList;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Jan']")]
    private IWebElement _januaryButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Feb']")]
    private IWebElement _februaryButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Mar']")]
    private IWebElement _marchButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Apr']")]
    private IWebElement _aprilButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='May']")]
    private IWebElement _mayButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Jun']")]
    private IWebElement _juneButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Jul']")]
    private IWebElement _julyButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Aug']")]
    private IWebElement _augustButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sep']")]
    private IWebElement _septemberButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Oct']")]
    private IWebElement _octoberButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Nov']")]
    private IWebElement _novemberButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Dec']")]
    private IWebElement _decemberButton;

    public void MoveToSection() => ((IJavaScriptExecutor) WebDriver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

    public void DeselectDates()
    {
        var targetYear = 2018;
        _yearButton.Click();
        _deselectiveYearButton.Click();
        _septemberButton.Click();
        _firstSelectedDate.Click();
        _secondSelectedDate.Click();
    }

    public void PickDate(int daysDelta)
    {
        Thread.Sleep(2000);
        var dateForButton = DateTime.Today.AddDays(daysDelta);

        const string dateFormat = "%d";
        var targetDateStr = dateForButton.ToString(dateFormat);

        const string monthFormat = "MM";
        var targetMonthStr = dateForButton.ToString(monthFormat);

        const string yearFormat = "yyyy";
        var targetYearStr = dateForButton.ToString(yearFormat);

        void Switch()
        {
            switch (targetMonthStr)
            {
                case "01":
                    _januaryButton.Click();
                    Thread.Sleep(2000);
                    var datepicker = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    datepicker.Click();
                    break;
                case "02":
                    _februaryButton.Click();
                    Thread.Sleep(2000);
                    var datepicke = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    datepicke.Click();
                    break;
                case "03":
                    _marchButton.Click();
                    Thread.Sleep(2000);
                    var datepick = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    datepick.Click();
                    break;
                case "04":
                    _aprilButton.Click();
                    Thread.Sleep(2000);
                    var datepic = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    datepic.Click();
                    break;
                case "05":
                    _mayButton.Click();
                    Thread.Sleep(2000);
                    var datepi = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    datepi.Click();
                    break;
                case "06":
                    _juneButton.Click();
                    Thread.Sleep(2000);
                    var datep = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    datep.Click();
                    break;
                case "07":
                    _julyButton.Click();
                    Thread.Sleep(2000);
                    var date = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    date.Click();
                    break;
                case "08":
                    _augustButton.Click();
                    Thread.Sleep(2000);
                    var dat = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    dat.Click();
                    break;
                case "9":
                    _septemberButton.Click();
                    Thread.Sleep(2000);
                    var da = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    da.Click();
                    break;
                case "10":
                    _octoberButton.Click();
                    Thread.Sleep(2000);
                    var d = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    d.Click();
                    break;
                case "11":
                    _novemberButton.Click();
                    Thread.Sleep(2000);
                    var d1 = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    d1.Click();
                    break;
                case "12":
                    _decemberButton.Click();
                    Thread.Sleep(2000);
                    var d2 = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{targetDateStr}']"));
                    d2.Click();
                    break;
            }
        }

        try
        {
            if (_yearAndMonthButton.Text.Contains(targetYearStr))
            {
                Switch();
            }
        }
        catch (NoSuchElementException)
        {
            if (int.Parse(targetYearStr) > 2118)
            {
                _yearButton.Click();
                while (WebDriver.FindElement(By.XPath("//ul[@class='v-date-picker-years']")).Text.Contains(targetYearStr) == false)
                {
                    _addYearsList.Click();
                    _yearButton.Click();
                }

                var year = WebDriver.FindElement(By.XPath($"//li[normalize-space()='{targetYearStr}']"));
                year.Click();
                Switch();
            }
            else
            {
                _yearButton.Click();
                while (WebDriver.FindElement(By.XPath("//ul[@class='v-date-picker-years']")).Text.Contains(targetYearStr) == false)
                {
                    _subtractYearsList.Click();
                    _yearButton.Click();
                }

                var year = WebDriver.FindElement(By.XPath($"//li[normalize-space()='{targetYearStr}']"));
                year.Click();
                Switch();
            }
        }
    }
}