namespace PracticeExam.Pages;

public class MainPage : BasePage {
    public MainPage(IWebDriver webDriver) : base(webDriver) => PageFactory.InitElements(webDriver, this);

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

    [FindsBy(How = How.XPath, Using = "//li[normalize-space()='2018']")]
    private IWebElement _deselectiveYearButton;

    [FindsBy(How = How.CssSelector, Using = "li:nth-child(1)")]
    private IWebElement _addYearsList;

    [FindsBy(How = How.CssSelector, Using = "li:nth-child(201)")]
    private IWebElement _subtractYearsList;

    [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sep']")]
    private IWebElement _septemberButton;

    public void MoveToSection() => ((IJavaScriptExecutor) WebDriver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

    public void DeselectDates() {
        _yearButton.Click();
        _deselectiveYearButton.Click();
        _septemberButton.Click();
        _firstSelectedDate.Click();
        _secondSelectedDate.Click();
    }

    public void PickDate(int daysDelta) {
        var targetDate = DateTime.Today.AddDays(daysDelta);
        var targetDateYear = targetDate.Year.ToString();
        
        void ClickDay() {
            WebDriver.FindElement(By.XPath($"//li[contains(text(), '{targetDate.Year}')]")).Click();
            WebDriver.FindElement(By.XPath($"//div[contains(@class, \"v-btn__content\") and contains(text(), '{targetDate.ToString("MMM dd").Split(" ")[0]}')]")).Click();
            WebDriver.FindElement(By.XPath($"//div[@class=\"v-btn__content\" and contains(text(), '{targetDate.Day}')]")).Click();
        }
        
        try {
            _yearButton.Click();
            ClickDay();
        }
        catch (Exception) {
            if (int.Parse(targetDateYear) > 2118) {
                while (WebDriver.FindElement(By.XPath("//ul[@class='v-date-picker-years']")).Text.Contains(targetDateYear) == false) {
                    _addYearsList.Click();
                    _yearButton.Click();
                }

                ClickDay();
            }
            else {
                while (WebDriver.FindElement(By.XPath("//ul[@class='v-date-picker-years']")).Text.Contains(targetDateYear) == false) {
                    _subtractYearsList.Click();
                    _yearButton.Click();
                }

                ClickDay();
            }
        }
    }
}