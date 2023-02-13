using NUnit.Framework;
using Patterns.Steps;

namespace Patterns.Tests;

public class BaseTest
{
    protected const string Username = "standard_user";
    protected const string Password = "secret_sauce";

    private Browser Browser { get; set; }

    protected static WebDriver WebDriver => BrowserService.Browser.WebDriver;

    protected LoginSteps LoginSteps { get; private set; }


    [SetUp]
    public void SetUp()
    {
        Browser = BrowserService.StartBrowser(AppConfiguration.BrowserProfile);

        LoginSteps = new LoginSteps(Browser);
    }

    [TearDown]
    public void TearDown()
    {
        ScreenShotting.TakeScreenshot();
        Browser.Quit();
    }
}