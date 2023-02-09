namespace SeleniumWrapperTests.Tests;

public class MediaParkTests : BaseTest
{
    [Test]
    [Obsolete("Obsolete")]
    public void MakeOrder()
    {
        ProductsPage.OpenPage();
        Assert.True(ProductsPage.IsPageOpened);

        ProductsPage.AddProducts();
        ProductsPage.ClickShoppingCart();
        Assert.That(ProductsPage.Count(), Does.Contain("2"));

        ProductsPage.MakeOrder();
        Assert.True(OrderPage.IsPageOpened);

        OrderPage.ClientInfoEnter();
        OrderPage.NextStepAfterClientInfoEnter();
        OrderPage.DeliveryInfoEnter();
        OrderPage.NextStepAfterDeliveryInfoEnter();
        OrderPage.CashInfoEnter();
        OrderPage.FinishOrder();
        Assert.True(OrderPage.IsSuccessDisplayed);
    }
}