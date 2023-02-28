namespace Patterns.Components;

public class CheckoutPageComponents
{
    public readonly TextField FirstName = new(By.Id("first-name"), "First Name");

    public readonly TextField LastName = new(By.Id("last-name"), "Last Name");

    public readonly TextField ZipCode = new(By.Id("postal-code"), "Postal Code");

    public readonly Button Checkout = new(By.XPath("//button[@id='checkout']"), "Checkout");

    public readonly Button ContinueButton = new(By.Id("continue"), "Continue Button");

    public readonly Button FinishOrder = new(By.Id("finish"), "Finish Order");
}