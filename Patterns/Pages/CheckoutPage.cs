using Patterns.Components;

namespace Patterns.Pages;

public class CheckoutPage : BasePage
{
    public CheckoutPage(Browser browser) : base(browser)
    {
    }

    private CheckoutPageComponents CheckoutPageComponents => new();

    protected override By UniqueWebLocator { get; }

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
        CheckoutPageComponents.Checkout.Click();

        return this;
    }

    public CheckoutPage EnterInformation(Person person)
    {
        CheckoutPageComponents.FirstName.SendText(person.GetFirstName());
        CheckoutPageComponents.LastName.SendText(person.GetLastName());
        CheckoutPageComponents.ZipCode.SendText(person.GetZipCode());

        return this;
    }

    public CheckoutPage ClickContinueButton()
    {
        CheckoutPageComponents.ContinueButton.Click();

        return this;
    }

    public CheckoutPage ClickFinishOrder()
    {
        CheckoutPageComponents.FinishOrder.Click();

        return this;
    }
}