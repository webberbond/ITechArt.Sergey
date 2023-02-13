namespace Patterns.Pages;

public class CheckoutPage : BasePage
{
    public CheckoutPage(Browser browser) : base(browser)
    {
    }

    protected override By UniqueWebLocator { get; }

    private readonly TextField _firstName = new(By.Id("first-name"), "First Name");

    private readonly TextField _lastName = new(By.Id("last-name"), "Last Name");

    private readonly TextField _zipCode = new(By.Id("postal-code"), "Postal Code");

    private readonly Button _checkout = new(By.XPath("//button[@id='checkout']"), "Checkout");

    private readonly Button _continueButton = new(By.Id("continue"), "Continue Button");

    private readonly Button _finishOrder = new(By.Id("finish"), "Finish Order");

    private new CheckoutPage IsPageOpened()
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

    public CheckoutPage ClickCheckout()
    {
        _checkout.Click();

        return this;
    }

    public CheckoutPage EnterInformation(Person person)
    {
        _firstName.SendText(person.GetFirstName());
        _lastName.SendText(person.GetLastName());
        _zipCode.SendText(person.GetZipCode());

        return this;
    }

    public CheckoutPage ClickContinueButton()
    {
        _continueButton.Click();

        return this;
    }

    public CheckoutPage ClickFinishOrder()
    {
        _finishOrder.Click();

        return this;
    }
}