using Logger = WebDriverBasics.Utilities.Logger;

namespace WebDriverBasics.Pages;

public class MobilePhonesPage : BasePage
{
    private IWebDriver driver;

    public MobilePhonesPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator => By.XPath("//h1[contains(text(),'Мобильные телефоны')]");

    protected override string UrlPath => string.Empty;

    private WebDriverWait Wait => new(WebDriver, TimeSpan.FromSeconds(5));

    [FindsBy(How = How.XPath, Using = "//*[contains(@value, 'apple')]//parent::*")]
    private IWebElement Apple;

    [FindsBy(How = How.XPath, Using = "//*[contains(@value, 'honor')]//parent::*")]
    private IWebElement Honor;

    [FindsBy(How = How.XPath, Using = "//*[contains(@data-bind, 'removeTag')]//span[contains(text(), 'HONOR')]")]
    private IWebElement ContainsHonor;

    [FindsBy(How = How.XPath,
        Using =
            "//div[@id='schema-products']/div[2]/div[contains(@class,'schema-product_narrow-sizes')]/div[contains(@class,'schema-product__part_1')]//label[@class='schema-product__control']")]
    private IWebElement FirstProduct;

    [FindsBy(How = How.XPath,
        Using =
            "//div[@id='schema-products']/div[5]/div[contains(@class,'schema-product_narrow-sizes')]/div[contains(@class,'schema-product__part_1')]//label[@class='schema-product__control']")]
    private IWebElement ThirdProduct;

    [FindsBy(How = How.XPath, Using = "//a[@class='compare-button__sub compare-button__sub_main']")]
    private IWebElement CompareButton;

    private static By HonorTag =>
        By.XPath("//*[contains(@data-bind, 'product.full_name') and contains(text(), 'Honor')]");

    public bool AreItemsAdded => CompareButton.Text.Contains('2');

    [AllureStep("Select Apple And Honor In Checkboxes")]
    public void SelectChekboxes()
    {
        ScrollToView(Apple);

        Logger.Instance.Info($"Select checkboxes {Apple} and {Honor}");

        Apple.Click();
        Honor.Click();
    }

    [AllureStep("Remove Honor From The List (Unselect The Checkbox)")]
    public void DeleteHonor()
    {
        Logger.Instance.Info($"Remove {ContainsHonor}");
        ContainsHonor.Click();
    }

    public bool IsHonorTagVisible
    {
        get
        {
            try
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(HonorTag));
                return WebDriver.FindElement(HonorTag).Displayed;
            }
            catch (NoSuchElementException)
            {
                Logger.Instance.Info("Honor tag was successfully removed");
                return true;
            }
        }
    }

    [AllureStep("Add First And Third Products")]
    public void AddFirstAndThirdProducts()
    {
        WebDriverWait wait = new(WebDriver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementToBeClickable(FirstProduct));
        wait.Until(ExpectedConditions.ElementToBeClickable(ThirdProduct));

        Logger.Instance.Info($"Add {FirstProduct}");
        FirstProduct.Click();
        Logger.Instance.Info($"Add {ThirdProduct}");
        ThirdProduct.Click();
    }

    [AllureStep("Click Compare Button")]
    public void CompareButtonClick()
    {
        Logger.Instance.Info($"Click {CompareButton}");
        CompareButton.Click();
    }

    private void ScrollToView(IWebElement element)
    {
        switch (element.Location.Y)
        {
            case > 200:
            {
                var js = $"window.scrollTo({0}, {element.Location.Y - 80})";
                var scriptExecutor = WebDriver as IJavaScriptExecutor ?? throw new InvalidOperationException();
                scriptExecutor.ExecuteScript(js);
                break;
            }
        }
    }
}