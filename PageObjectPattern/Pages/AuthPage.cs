using Logger = WebDriverBasics.Utilities.Logger;

namespace WebDriverBasics.Pages;

public class AuthPage : BasePage
{
    private IWebDriver driver;

    public AuthPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator =>
        By.XPath("//div[@class='auth-form__body']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Ник или e-mail']")]
    private IWebElement NickNameInput;

    [FindsBy(How = How.XPath, Using = "//input[@placeholder='Пароль']")]
    private IWebElement PasswordInput;

    [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Войти')]")]
    private IWebElement LoginButton;

    [FindsBy(How = How.XPath, Using = "//iframe[@title='reCAPTCHA']")]
    private IWebElement CaptchaFrame;

    [FindsBy(How = How.Id, Using = "recaptcha-anchor")]
    private IWebElement CaptchaButton;

    [FindsBy(How = How.XPath, Using = "//div[@class='b-news-layer']")]
    private IWebElement NewsLayer;

    [AllureStep("Input nickname as {0} and password as {1}")]
    public void InputNicknameAndPassword()
    {
        const string nickname = "2846794";
        const string password = "ItechArt12345";

        Logger.Instance.Info($"Input nickname {nickname} in {NickNameInput}");
        NickNameInput.SendKeys(nickname);

        Logger.Instance.Info($"Input password {password} in {PasswordInput}");
        PasswordInput.SendKeys(password);

        PasswordInput.Submit();
    }

    [AllureStep("Pass Captcha")]
    public void CaptchaPass()
    {
        WebDriver.SwitchTo().Frame(CaptchaFrame);
        Logger.Instance.Info($"Click on {CaptchaButton}");
        CaptchaButton.Click();
    }

    public bool IsAuthenticationPass()
    {
        var isPassed = false;
        try
        {
            if (NewsLayer.Displayed)
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