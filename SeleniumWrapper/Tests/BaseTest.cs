namespace SeleniumWrapper.Tests;

public class BaseTest
{
    [SetUp]
    public void SetUp()
    {
        Browser.MaximizeWindow();
    }

    [TearDown]
    public void TearDown()
    {
        Browser.Quit();
    }
}