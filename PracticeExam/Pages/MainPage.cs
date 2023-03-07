namespace PracticeExam.Pages;

public class MainPage : BasePage
{
    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Mar']")]
    private IWebElement _calendarMonth;

    [FindsBy(How = How.XPath,
        Using =
            "//body/div[@id='app']/div[@class='v-application--wrap']/main[@class='v-main']/div[@class='v-main__wrap']/div[@id='test-task']/div[@class='row']/div[@class='col-sm-6 col-12']/div[@class='v-picker v-card v-picker--date theme--light']/div[@class='v-picker__body theme--light']/div[1]")]
    private IWebElement _calendarMonthButton;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='15']")]
    private IWebElement _firstSelectedDate;

    [FindsBy(How = How.XPath, Using = "//i[@class='v-icon notranslate mdi mdi-chevron-left theme--light']")]
    private IWebElement _previousMonth;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='20']")]
    private IWebElement _secondSelectedDate;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Mar']")]
    private IWebElement _specificMonth;

    [FindsBy(How = How.XPath, Using = "//li[normalize-space()='2023']")]
    private IWebElement _specificYear;

    [FindsBy(How = How.XPath, Using = "//div[@class='v-picker__title__btn v-date-picker-title__year']")]
    private IWebElement _yearButton;

    [FindsBy(How = How.XPath, Using = "//i[@class='v-icon notranslate mdi mdi-chevron-right theme--light']")]
    private IWebElement _nextMonth;

    public MainPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.CssSelector("body div pre");
    protected override string UrlPath => string.Empty;
    public IWebElement TestTaskSection => WebDriver.FindElement(By.CssSelector(".text-h2"));

    public void MoveToSection()
    {
        ((IJavaScriptExecutor)WebDriver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
    }

    public void DeselectDates()
    {
        _firstSelectedDate.Click();
        _secondSelectedDate.Click();
    }

    public void SelectMonth()
    {
        _yearButton.Click();
        _specificYear.Click();
        _specificMonth.Click();
    }

    public void PeekDate(int daysDelta)
    {
        SelectMonth();
        var dateForButton = DateTime.Today.AddDays(daysDelta);
        var specificDay = dateForButton.Day.ToString();
        var day = By.XPath($"//div[normalize-space()='{specificDay}']");
        int dayS = int.Parse(specificDay);
        
        if (dayS > 31)
        {
            _nextMonth.Click();
            WebDriver.FindElement(day).Click();
        }
        else
        {
            _previousMonth.Click();
            WebDriver.FindElement(day).Click();
        }
    }

    public void PeekDate2(int daysDelta)
    {
        SelectMonth();
        var dateForButton = DateTime.Today.AddDays(daysDelta);
        var specificDay = dateForButton.Day.ToString();
        
        IWebElement datepicker = WebDriver.FindElement(By.XPath($"//div[normalize-space()='{specificDay}']"));
        
        datepicker.Click();
    }
}