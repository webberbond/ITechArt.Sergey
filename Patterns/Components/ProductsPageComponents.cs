namespace Patterns.Components;

public class ProductsPageComponents
{
    public readonly Button AddToCart = new(By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light']"),
        "Add To Cart");

    public readonly Button Basket = new(By.XPath("//a[@class='shopping_cart_link']"), "Basket");
}