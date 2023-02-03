﻿using Logger = WebDriverBasics.Utilities.Logger;

namespace WebDriverBasics.Pages;

public class HomePage : BasePage
{
    private IWebDriver driver;

    public HomePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator =>
        By.XPath("//div[@class='project-navigation project-navigation_overflow project-navigation_scroll']");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Мобильные телефоны')]")]
    private IWebElement MobilePhonesTab;

    [FindsBy(How = How.XPath, Using = "//div[@class='auth-bar__item auth-bar__item--text']")]
    private IWebElement AuthButton;


    [AllureStep("Open Mobile Phones Tab")]
    public MobilePhonesPage ClickTab_MobilePhones()
    {
        Logger.Instance.Info($"Open {MobilePhonesTab}");
        MobilePhonesTab.Click();
        return new MobilePhonesPage(WebDriver);
    }

    public AuthPage ClickButton_Auth()
    {
        Logger.Instance.Info($"Click auth{AuthButton}");
        AuthButton.Click();

        return new AuthPage(WebDriver);
    }
}