namespace SeleniumWrapperTests.Pages;

public class ProductsPage : BasePage
{
    public ProductsPage(Browser browser) : base(browser)
    {
    }

    protected override string UrlPath => string.Empty;

    protected override By UniqueWebLocator => By.XPath("//h3[contains(text(),'Телевизоры')]");

    private readonly Button _firstProduct = new(By.XPath("(//img[@alt='yes'])[11]"), "FirstProduct");
    private readonly Button _secondProduct = new(By.XPath("(//img[@alt='yes'])[12]"), "SecondProduct");
    private readonly Button _shoppingCart = new(By.XPath("//a[@class='karzinka']"), "ShoppingCart");
    private readonly Label _itemsTotalCount = new(By.XPath("//*[@class= 'totalCount']"), "ItemsTotalCount");

    private readonly Button _order = new(By.XPath("//a[@class='karzinka-open-bottom-block-a2']"), "Order");

    public void AddProducts()
    {
        _firstProduct.Click();
        _secondProduct.Click();
    }

    public void ClickShoppingCart()
    {
        _shoppingCart.Click();
    }

    public void MakeOrder()
    {
        _order.Click();
    }

    public string Count()
    {
        Thread.Sleep(3000);
        return _itemsTotalCount.GetInnerHtml();
    }
}