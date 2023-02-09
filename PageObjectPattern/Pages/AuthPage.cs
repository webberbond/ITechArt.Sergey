using Logger = WebDriverBasics.Utilities.Logger;

namespace WebDriverBasics.Pages;

public class AuthPage : BasePage
{
    private IWebDriver _driver;

    public AuthPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator =>
        By.XPath("//div[@class='auth-form__body']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Ник или e-mail']")]
    private IWebElement _nickNameInput;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Пароль']")]
    private IWebElement _passwordInput;

    [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Войти')]")]
    private IWebElement _loginButton;

    [FindsBy(How = How.XPath, Using = "//iframe[@title='reCAPTCHA']")]
    private IWebElement _captchaFrame;

    [FindsBy(How = How.Id, Using = "recaptcha-anchor")]
    private IWebElement _captchaButton;

    [FindsBy(How = How.XPath, Using = "//div[@class='b-news-layer']")]
    private IWebElement _newsLayer;

    [AllureStep("Input nickname as {0} and password as {1}")]
    public void InputNicknameAndPassword()
    {
        const string nickname = "2846794";
        const string password = "ItechArt12345";

        Logger.Instance.Info($"Input nickname {nickname} in {_nickNameInput}");
        _nickNameInput.SendKeys(nickname);

        Logger.Instance.Info($"Input password {password} in {_passwordInput}");
        _passwordInput.SendKeys(password);

        _passwordInput.Submit();
    }

    [AllureStep("Pass Captcha")]
    public void CaptchaPass()
    {
        WebDriver.SwitchTo().Frame(_captchaFrame);
        Logger.Instance.Info($"Click on {_captchaButton}");
        _captchaButton.Click();
    }

    public bool IsAuthenticationPass()
    {
        var isPassed = false;
        try
        {
            if (_newsLayer.Displayed)
            {
                Logger.Instance.Info("Successfully authenticated");
                isPassed = true;
            }
        }
        catch (NoSuchElementException)
        {
            Logger.Instance.Error("Authentication error");
            isPassed = false;
        }

        return isPassed;
    }
}