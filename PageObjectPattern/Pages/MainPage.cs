namespace WebDriverBasics.Pages;

public class MainPage : BasePage
{
    public MainPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    private WebDriverWait Wait => new(WebDriver, TimeSpan.FromSeconds(20));
    protected override By UniqueWebLocator => By.XPath("//div[@class='login-form']");
    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Choose Password']")]
    private IWebElement PasswordInput;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Your email']")]
    private IWebElement EmailInput;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Domain']")]
    private IWebElement DomainInput;

    [FindsBy(How = How.XPath, Using = "//div[@class='dropdown__header']")]
    private IWebElement DropdownAfterDomain;

    [FindsBy(How = How.XPath, Using = "//div[@class='dropdown__list-item']")]
    private IList<IWebElement> DropdownOptions;

    [FindsBy(How = How.XPath, Using = "//span[@class='checkbox__box']")]
    private IWebElement AcceptTermsCheckbox;

    [FindsBy(How = How.XPath, Using = "//a[@class='button--secondary']")]
    private IWebElement NextStepButton;

    [FindsBy(How = How.XPath, Using = "//div[@class='cookies']")]
    private IWebElement CookiesForm;

    [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Not really, no']")]
    private IWebElement CookiesAcceptButton;

    [FindsBy(How = How.XPath, Using = "//div[@class='timer timer--white timer--center']")]
    private IWebElement Timer;

    [FindsBy(How = How.XPath, Using = "//div[@class='help-form__container']")]
    private IWebElement HelpContainer;

    [FindsBy(How = How.XPath, Using = "//span[@class='discrete']")]
    private IWebElement HelpToBottomButton;

    [FindsBy(How = How.XPath, Using = "//button[@class='button button--solid button--blue help-form__close-button']")]
    private IWebElement HelpToUpButton;

    public void SendData()
    {
        PasswordInput.Clear();
        PasswordInput.SendKeys("G1enemator$Or");

        EmailInput.Clear();
        EmailInput.SendKeys("sergey.zrch@gmail.com");

        DomainInput.Clear();
        DomainInput.SendKeys("rbond");

        DropdownAfterDomain.Click();
        DropdownOptions[2].Click();
    }

    public void AcceptTerms()
    {
        AcceptTermsCheckbox.Click();
    }

    public void GoToNextStep()
    {
        NextStepButton.Click();
    }

    public void AcceptCookies()
    {
        Wait.Until(drv => CookiesForm.Displayed);
        CookiesAcceptButton.Click();
    }

    public string GetTimerValue()
    {
        return Timer.Text;
    }

    public void HideHelp()
    {
        HelpToBottomButton.Click();
    }

    public bool WaitForDissapear()
    {
        return Wait.Until(drv => HelpToUpButton.Displayed == false);
    }
}