namespace WebDriverBasics.Pages;

public class AuthorizationPage : BasePage
{
    private IWebDriver driver;

    public AuthorizationPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => string.Empty;

    protected override string _baseUrl =>
        "http://" + _username + ":" + _password + "@" + "the-internet.herokuapp.com/basic_auth";

    protected override By UniqueWebLocator => By.XPath("//h3[normalize-space()='Basic Auth']");

    [FindsBy(How = How.CssSelector, Using = "div[class='example'] p")]
    private IWebElement _actualString;

    private string _username = "admin";
    private string _password = "admin";

    public bool StringExists
    {
        get
        {
            var expectedString = "Congratulations! You must have the proper credentials.";

            if (_actualString.Text != expectedString)
                return false;

            return true;
        }
    }
}