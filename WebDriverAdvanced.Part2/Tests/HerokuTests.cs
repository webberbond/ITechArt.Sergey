namespace WebDriverBasics.Tests;

public class Onliner : BaseTest
{
    [Test]
    public void Authorization()
    {
        AuthorizationPage.OpenPage();
        AuthorizationPage.EnterCredentials();

        Assert.Multiple(() =>
        {
            Assert.True(AuthorizationPage.IsPageOpened);
            Assert.True(AuthorizationPage.StringExists);
        });
    }

    [Test]
    public void UploadFile()
    {
        UploadFilePage.OpenPage();
        Assert.True(UploadFilePage.IsPageOpened);

        UploadFilePage.UploadPicture();
        UploadFilePage.ClickUploadButton();

        Assert.True(UploadFilePage.IfContainsString());
    }

    [Test]
    public void Slider()
    {
        SliderPage.OpenPage();
        Assert.True(SliderPage.IsPageOpened);

        SliderPage.MoveSlider();
        Assert.True(SliderPage.IfValueEquals());
    }

    [Test]
    public void Windows()
    {
        WindowsPage.OpenPage();
        Assert.True(WindowsPage.IsPageOpened);

        WindowsPage.OpenNewTab();
        Assert.Multiple(() =>
        {
            Assert.True(WindowsPage.IfTabTitleRight());
            Assert.True(WindowsPage.IfTextDisplayed());
        });

        WindowsPage.SwitchToFirstTab();

        WindowsPage.OpenNewTab();
        Assert.Multiple(() =>
        {
            Assert.True(WindowsPage.IfTabTitleRight());
            Assert.True(WindowsPage.IfTextDisplayed());
        });

        WindowsPage.CloseSecondTab();
        WindowsPage.CloseMainTab();
        WindowsPage.CloseLastTab();
    }

    [TestCase(HoversPage.ImageId.Image1)]
    [TestCase(HoversPage.ImageId.Image2)]
    [TestCase(HoversPage.ImageId.Image3)]
    public void Hovers(HoversPage.ImageId imageId)
    {
        HoversPage.OpenPage();
        Assert.True(HoversPage.IsPageOpened);

        HoversPage.HoverOverImage(imageId);
        var result = HoversPage.ReadSubHeaderTextForImage(imageId);
        Assert.That(result, Is.EqualTo("name: user" + (int) imageId));


        HoversPage.HoverOverImage(imageId);
        HoversPage.ClickViewProfileLink();
        result = WebDriver.Url;
        Assert.That(result, Is.EqualTo("https://the-internet.herokuapp.com/users/" + (int) imageId));

        HoversPage.IsRightPage();
    }

    [Test]
    public void DownloadFile()
    {
        DownloadFilePage.OpenPage();
        Assert.True(DownloadFilePage.IsPageOpened);

        DownloadFilePage.Download();
        Checks.IfFileExists();
    }
}