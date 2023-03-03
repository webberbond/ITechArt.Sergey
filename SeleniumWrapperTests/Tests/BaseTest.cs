namespace SeleniumWrapperTests.Tests;

public class BaseTest
{
    private Browser Browser { get; set; }

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