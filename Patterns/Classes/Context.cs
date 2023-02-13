namespace Patterns.Classes;

public class Context
{
    private IStrategy _strategy = null!;

    public Context()
    {
    }

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void AddProduct()
    {
        _strategy.AddProductToCart();
    }

    public string GetBackPackAddButtonText()
    {
        return _strategy.GetBackPackAddButtonText();
    }
    
    public string GetBackPackRemoveButtonText()
    {
        return _strategy.GetBackPackRemoveButtonText();
    }

    public string GetProductName()
    {
        return _strategy.GetProductName();
    }
    public void ClickProduct()
    {
        _strategy.ClickProduct();
    }

    public void GetBackToProducts()
    {
        _strategy.GetBackToProducts();
    }

    public void RemoveProduct()
    {
        _strategy.RemoveProductFromCart();
    }
}