namespace Patterns.Strategy;

public interface IStrategy
{
    string GetBackPackAddButtonText();
    string GetBackPackRemoveButtonText();
    string GetProductName();
    void AddProductToCart();
    void RemoveProductFromCart();
    void ClickProduct();
    void GetBackToProducts();
}