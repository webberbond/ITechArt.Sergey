namespace Patterns.Classes;

public class ProductTitleStrategy : IStrategy
{
    private readonly Button _addToCart =
        new(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']"), "Add To Cart");

    private readonly Button _removeFromCart =
        new(By.XPath("//button[@id='remove-sauce-labs-backpack']"), "Remove from Cart");

    private readonly Button _backToProducts = new(By.XPath("//button[@id='back-to-products']"), "Back To Products");

    private readonly Button _backPackDescription =
        new(By.XPath("//div[normalize-space()='Sauce Labs Backpack']"), "Backpack Description");

    private readonly Label _backpackNameClass =
        new(By.XPath("//div[@class='inventory_details_name large_size']"), "BackPack Name Class");

    public string GetBackPackAddButtonText()
    {
        return _addToCart.GetText();
    }

    public string GetBackPackRemoveButtonText()
    {
        return _removeFromCart.GetText();
    }

    public string GetProductName()
    {
        return _backpackNameClass.GetText();
    }

    public void AddProductToCart()
    {
        _addToCart.Click();
    }

    public void RemoveProductFromCart()
    {
        _removeFromCart.Click();
    }

    public void ClickProduct()
    {
        _backPackDescription.Click();
    }

    public void GetBackToProducts()
    {
        _backToProducts.Click();
    }
}