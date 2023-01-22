namespace WebDriverBasics.Pages;

public class MobilePhonesPage : BasePage
{
    private IWebDriver driver;

    public MobilePhonesPage(IWebDriver webDriver) : base(webDriver) => PageFactory.InitElements(webDriver, this);

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
        Using = "/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]")]
    private IWebElement FirstProduct;
    
    [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]")]
    private IWebElement ThirdProduct;
    
    [FindsBy(How = How.XPath, Using = "//a[@class='compare-button__sub compare-button__sub_main']")]
    private IWebElement CompareButton;

    private static By HonorTag =>
        By.XPath("//*[contains(@data-bind, 'product.full_name') and contains(text(), 'Honor')]");
    public bool AreItemsAdded => CompareButton.Text.Contains('2');

    public void SelectChekboxes()
    {
        ScrollToView(Apple);
        Apple.Click();
        Honor.Click();
    }

    public void DeleteHonor()
    {
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
                return true;
            }
        }
    }

    public void AddFirstAndThirdProducts()
    {
        WebDriverWait wait = new(WebDriver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementToBeClickable(FirstProduct));
        wait.Until(ExpectedConditions.ElementToBeClickable(ThirdProduct));
        
        FirstProduct.Click();
        ThirdProduct.Click();
    }

    public void CompareButtonClick() => CompareButton.Click();

    private void ScrollToView(IWebElement element)
    {
        switch (element.Location.Y)
        {
            case > 200:
            {
                var js = $"window.scrollTo({0}, {element.Location.Y-80})";
                var scriptExecutor= WebDriver as IJavaScriptExecutor ?? throw new InvalidOperationException();
                scriptExecutor?.ExecuteScript(js);
                break;
            }
        }
    }
}
