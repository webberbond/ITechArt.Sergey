namespace WebDriverBasics.Pages;

public class ComparePage : BasePage
{
    private IWebDriver driver;
    public ComparePage(IWebDriver webDriver) : base(webDriver) => PageFactory.InitElements(webDriver, this);

    protected override By UniqueWebLocator =>
        By.XPath("(//h1[contains(text(),'Сравнение товаров')])[1]");

    protected override string UrlPath => string.Empty;

    [FindsBy(How = How.XPath, Using = "//table//tbody[4]//tr[4]//td[contains(@class,'product-table__cell')][1]")]
    private IWebElement descriptionTable;
    
    [FindsBy(How = How.XPath, Using = "//table//tbody[4]//tr[4]//td[contains(@class,'product-table__cell')][1]//div")]
    private IWebElement description;

    [FindsBy(How = How.XPath, Using = "//*[contains(@data-tip-term , 'Описание')]")]
    private IWebElement descriptionText;
    
    const string descriptionParagraph =
        "Краткая информация об отличиях товара от конкурентных моделей и аналогов, сведения о позиционировании на рынке, преемственности и др.";

    public bool IsDescriptionOpened =>
        descriptionText.GetAttribute("class").Contains("product-table-tip__trigger_visible");
    
    public bool IsDescriptionRight => descriptionText.GetAttribute("data-tip-text").Contains(descriptionParagraph);
    

    public void GetDescriptionTable()
    {
        var action = new Actions(WebDriver);
        action.MoveToElement(descriptionTable);

        action.MoveToElement(description);
        
        descriptionText.Click();
    }

    public void GetPreviousPage() => WebDriver.Navigate().Back();
}