namespace WebDriverBasics.Tests;

public class DemoQA : BaseTest
{
    [Test]
    public void DemoQA_Task1()
    {
        MainPage.OpenPage();
        Assert.True(MainPage.IsPageOpened, "MainPage Should Be Opened");

        MainPage.AlertsPageOpen();
        Assert.True(AlertsPage.IsPageOpened, "AlertsPage Be Opened");

        AlertsPage.GetAlert();
        Assert.That(AlertsPage.IsAlertShown);
        AlertsPage.AlertTextEquals();
        AlertsPage.AcceptAlert();
        Assert.That(AlertsPage.IsAlertClosed);

        AlertsPage.GetConfirmBox();
        Assert.True(AlertsPage.IsAlertShown);
        AlertsPage.ConfirmBoxTextEquals();
        AlertsPage.AcceptAlert();
        Assert.Multiple(() =>
        {
            Assert.True(AlertsPage.IsAlertClosed);
            Assert.True(AlertsPage.ConfirmBoxDisplaySuccess());
        });

        AlertsPage.GetPromptBox();
        Assert.That(AlertsPage.IsAlertShown);
        AlertsPage.SendTextToPromptBox();
        Assert.Multiple(() =>
        {
            Assert.That(AlertsPage.IsAlertClosed);
            Assert.That(AlertsPage.IsPromptBoxLabelDisplayed(), Is.EqualTo(true));
        });
    }

    [Test]
    public void DemoQA_Task2()
    {
        MainPage.OpenPage();
        Assert.True(MainPage.IsPageOpened, "MainPage Should Be Opened");

        MainPage.AlertsPageOpen();
        Assert.True(AlertsPage.IsPageOpened, "AlertsPage Should Be Opened");

        AlertsPage.SwitchToParentFrame();
        Assert.That(AlertsPage.IsParentTextDisplayed(), Is.EqualTo(true));

        AlertsPage.SwitchToChildFrame();
        Assert.That(AlertsPage.IsChildTextDisplayed(), Is.EqualTo(true));

        AlertsPage.TestFrames();
    }

    [Test]
    public void DemoQA_Task3()
    {
        MainPage.OpenPage();
        Assert.That(MainPage.IsPageOpened, "MainPage Should Be Opened");

        MainPage.WidgetsPageOpen();
        Assert.That(WidgetsPage.IsPageOpened, "WidgetsPage Should Be Opened");

        WidgetsPage.ProgressBarButtonClick();
        WidgetsPage.StopProgressBarOnSpecificPercent("46%");
        Assert.That(WidgetsPage.IsStopped(), Is.EqualTo(true));
    }

    [Test]
    public void Additional_Task()
    {
        MainPage.OpenPage();
        Assert.True(MainPage.IsPageOpened, "MainPage Should Be Opened");

        MainPage.AlertsPageOpen();
        Assert.True(AlertsPage.IsPageOpened, "AlertsPage Be Opened");

        AlertsPage.BrowserWindowsTest();

        AlertsPage.SwitchToNewTab();
        Assert.That(AlertsPage.IsNewPageOpened());

        AlertsPage.CloseTab();
        Assert.That(WebDriver.Title, Is.EqualTo("ToolsQA"));

        AlertsPage.LinksPageOpen();
        AlertsPage.HomeButtonClick();
        Assert.That(AlertsPage.MainPageOpen);

        AlertsPage.SwitchToPreviousTab();
    }
}