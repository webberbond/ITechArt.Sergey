using SeleniumExtras.WaitHelpers;

namespace Patterns.Pages;

public sealed class ProductsPage : BasePage
{
    public ProductsPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//select[@class='product_sort_container']");

    public BasePage OpenPage()
    {
        WebDriver.Navigate().GoToUrl(BaseUrl + "/inventory.html");
        IsPageOpened();

        return this;
    }

    public new ProductsPage IsPageOpened()
    {
        try
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(UniqueWebLocator));
        }
        catch (TimeoutException)
        {
            Logger.Instance.Info("Page was not opened");
        }

        return this;
    }
}