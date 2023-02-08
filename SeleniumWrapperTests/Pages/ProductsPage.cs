using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWrapper.Elements;
using SeleniumWrapper.Forms;
using SeleniumWrapper.Pages;
using SeleniumWrapper.Tests;

namespace SeleniumWrapperTests.Pages;

public class ProductsPage : Page
{
   

    private static  Button FirstProduct = new(By.XPath("(//img[@alt='yes'])[1]"), "FirstProduct");
    private static  Button SecondProduct = new(By.XPath("(//img[@alt='yes'])[2]"), "SecondProduct");

    private static  Button ShoppingCart = new(By.XPath("//a[@class='karzinka']"), "ShoppingCart");

    public static void AddProducts()
    {
        FirstProduct.Click();
        SecondProduct.Click();
    }

    public static void ClickShoppingCart()
    {
        ShoppingCart.Click();
    }

    public ProductsPage(BaseElement uniqueElement) : base(uniqueElement)
    {
        UniqueElement = new TextField(By.XPath("//h3[contains(text(),'Телевизоры')]"), "Logo");
    }
}
