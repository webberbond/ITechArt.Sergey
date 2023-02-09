namespace WebDriverBasics.Tests;

public class SiteTest : BaseTest
{
    [Test]
    [Order(1)]
    public void Step1()
    {
        HomePage.OpenPage();
        Assert.That(HomePage.IsPageOpened, Is.True, "HomePage should be opened");

        HomePage.GoToNextPage();
        Assert.That(MainPage.IsPageOpened, Is.True, "MainPage should be opened");

        MainPage.SendData();
        MainPage.AcceptTerms();
        MainPage.GoToNextStep();

        Assert.That(MyPage.IsPageOpened, Is.True, "MyPage should be opened");
    }

    [Test]
    [Order(2)]
    public void Step2()
    {
        HomePage.OpenPage();
        Assert.That(HomePage.IsPageOpened, Is.True, "HomePage should be opened");

        HomePage.GoToNextPage();
        Assert.That(MainPage.IsPageOpened, Is.True, "MainPage should be opened");

        MainPage.AcceptCookies();
    }

    [Test]
    [Order(3)]
    public void Step3()
    {
        HomePage.OpenPage();
        Assert.That(HomePage.IsPageOpened, Is.True, "HomePage should be opened");

        HomePage.GoToNextPage();
        Assert.That(MainPage.IsPageOpened, Is.True, "MainPage should be opened");

        const string startTimer = "00:00:00";
        Assert.That(MainPage.GetTimerValue(), Is.EqualTo(startTimer));
    }

    [Test]
    [Order(4)]
    public void Step4()
    {
        HomePage.OpenPage();
        Assert.That(HomePage.IsPageOpened, Is.True, "HomePage should be opened");

        HomePage.GoToNextPage();
        Assert.That(MainPage.IsPageOpened, Is.True, "MainPage should be opened");

        MainPage.HideHelp();

        Assert.That(MainPage.WaitForDissapear(), Is.EqualTo(true));
    }
}