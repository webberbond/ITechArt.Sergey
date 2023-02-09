namespace SeleniumWrapperTests.Tests;

public class BaseTest
{
    protected Browser Browser { get; private set; }

    protected ProductsPage ProductsPage { get; private set; }

    protected OrderPage OrderPage { get; private set; }

    [SetUp]
    public void SetUp()
    {
        Browser = BrowserService.StartBrowser(AppConfiguration.BrowserProfile);

        ProductsPage = new ProductsPage(Browser);

        OrderPage = new OrderPage(Browser);
    }

    [TearDown]
    public void TearDown()
    {
        Browser.Quit();
    }
}