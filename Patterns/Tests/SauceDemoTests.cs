namespace Patterns.Tests;

[AllureNUnit]
public class SauceDemoTests : BaseTest
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Login Test Using Steps")]
    public void SuccesfullLogin()
    {
        LoginSteps
            .Login(Username, Password)
            .ValidateIsProductsPageOpened();
    }

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Error Login Test Using Steps")]
    public void ErrorLogin()
    {
        LoginSteps
            .Login("", Password)
            .ValidateErrorMessage("Epic sadce: Username is required");
    }

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Successful Login Using Value Object")]
    public void LoginViaValueObject()
    {
        SauceDemo.SetUserName("standard_user");
        SauceDemo.SetPassword("secret_sauce");
        LoginPage
            .OpenPage()
            .EnterUsername(SauceDemo)
            .EnterPassword(SauceDemo)
            .ClickLogin();
    }

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Checkout Page Test Using Builder")]
    public void CheckoutPageTest()
    {
        SuccesfullLogin();

        var person = Person.Builder
            .FirstName("Sergey")
            .LastName("Zarochentsev")
            .ZipCode("100123")
            .Build();

        ProductsPage
            .ClickAddToCart()
            .ClickBasket();

        CheckoutPage
            .ClickCheckout()
            .EnterInformation(person)
            .ClickContinueButton()
            .ClickFinishOrder();
    }

    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Checking Product Using Strategy")]
    public void CheckProductAndNavigateToHomePage()
    {
        SuccesfullLogin();
        var context = new Context();
        context.SetStrategy(new ProductTitleStrategy());

        context.AddProduct();
        Assert.That(context.GetBackPackRemoveButtonText(), Does.Contain("Remove"));

        context.ClickProduct();
        Assert.That(context.GetProductName(), Does.Contain("Sauce Labs Backpack"));

        context.GetBackToProducts();

        context.RemoveProduct();
        Assert.That(context.GetBackPackAddButtonText(), Does.Contain("Add to cart"));
    }
}