namespace Patterns.Pages;

public sealed class ProductsPage : BasePage
{
    public ProductsPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator => By.XPath("//select[@class='product_sort_container']");

    private readonly Button _addToCart = new(By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light']"), "Add To Cart");

    private readonly Button _basket = new(By.XPath("//a[@class='shopping_cart_link']"), "Basket");
    
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

    public ProductsPage ClickAddToCart()
    {
        _addToCart.Click();

        return this;
    }

    public ProductsPage ClickBasket()
    {
        _basket.Click();

        return this;
    }
}