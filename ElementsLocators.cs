using OpenQA.Selenium;

namespace Locators;

public class ElementsLocators
{
    private IWebDriver Driver;
    
    private  IWebElement HotelsButton => Driver.FindElement(By.XPath("//a[@class='form-tabs__link']"));
    private  IWebElement CurrencyChangeButton => Driver.FindElement(By.XPath("button[class='q8JaLokdctjkb1_n4aw0']"));
    private  IWebElement SiteLogo => Driver.FindElement(By.XPath("//a[@class='sFI433zopwKCZzUeA3vj']//span[@data-test-id='logo']"));
    private  IWebElement FlowChangeButton => Driver.FindElement(By.XPath("//*[@data-test-id='swap-places']"));
    private  IWebElement ProfileIcon => Driver.FindElement(By.XPath("//*[@class='lhBndfFd5uUAYinMmNLG']"));
    private  IWebElement ProfileButton => Driver.FindElement(By.XPath("//button[@data-test-id='profile-button']"));
    private  IWebElement ActualData => Driver.FindElement(By.XPath("//*[contains(@class,'today')]"));
    private  IWebElement DayOfMonth => Driver.FindElement(By.XPath("//div[@aria-label='Fri Jan 27 2023']//div[@class='calendar-day']"));
}