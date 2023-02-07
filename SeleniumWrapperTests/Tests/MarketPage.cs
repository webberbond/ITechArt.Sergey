using OpenQA.Selenium;
using SeleniumWrapper.Elements;

namespace SeleniumWrapperTests;

public class MarketPage
{
    private static Button FirstProduct =>
        new Button(
            By.CssSelector(
                "body > form:nth-child(8) > section:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div:nth-child(1) > div:nth-child(1) > div:nth-child(8) > img:nth-child(2)"),
            "First");
    private static Button SecondProduct => new Button(By.CssSelector("body > form:nth-child(8) > section:nth-child(1) > div:nth-child(2) > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > div:nth-child(8) > img:nth-child(2)"), "Second");
    public void Add()
    {
        FirstProduct.Click();
        SecondProduct.Click();
    }
}