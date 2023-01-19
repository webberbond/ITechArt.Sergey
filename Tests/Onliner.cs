namespace WebDriverBasics.Tests;

public class Onliner 
{
    private IWebDriver Driver;
    [SetUp]
    public void GetDriver()
    {
        Driver = new WebDriverFactory().GetDriver();
        Driver.Navigate().GoToUrl(Configurator.BaseUrl);
    }

    [Test]
    [Retry(3)]
    public void OnlinerTests()
    {
        //step 1
        var logo = Driver.FindElement(By.XPath("//img[@alt='Onlíner']"));

        Assert.Multiple(() =>
        {
            Assert.That(logo.Displayed);
            Assert.That(Driver.Title, Is.EqualTo("Onliner"));
        });


        //step 2
        Driver.FindElement(By.XPath("//span[contains(text(),'Мобильные телефоны')]")).Click();

        var mobilePhonesHeader = Driver.FindElement(By.XPath("//h1[contains(text(),'Мобильные телефоны')]"));

        Assert.Multiple(() =>
        {
            Assert.That(mobilePhonesHeader.Displayed);
            Assert.That(Driver.Title, Is.EqualTo("Мобильный телефон купить в Минске"));
        });


        //step 3
        var apple = Driver.FindElement(By.XPath("//*[contains(@value, 'apple')]//parent::*"));
        ScrollToView(apple);
        apple.Click();
        var honor = Driver.FindElement(By.XPath("//*[contains(@value, 'honor')]//parent::*"));
        honor.Click();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        // 4th step
        var containsHonor = Driver.FindElement(By.XPath("//*[contains(@data-bind, 'removeTag')]//span[contains(text(), 'HONOR')]"));
        containsHonor.Click();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
        try
        { 
            Driver.FindElement(By.XPath("//*[contains(@data-bind, \"product.full_name\") and contains(text(), \"Honor\")]"));
        }
        catch (NoSuchElementException)
        {
            Assert.That(true);
        }

        // 5th step
        WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(5));
        
        var firstProduct = Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[2]/div/div[1]/div[1]"));
        var thirdProduct = Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div/div[2]/div[1]/div[4]/div[3]/div[4]/div[5]/div/div[1]/div[1]"));
        
        wait.Until(ExpectedConditions.ElementToBeClickable(firstProduct));
        firstProduct.Click();
        wait.Until(ExpectedConditions.ElementToBeClickable(thirdProduct));
        thirdProduct.Click();
        var compareButton = Driver.FindElement(By.XPath("//a[contains(@class, 'compare-button__sub_main')]//span"));
        Assert.That(compareButton.Text, Does.Contain("2"));

        // 6th step
        Driver.FindElement(By.XPath("//a[@class='compare-button__sub compare-button__sub_main']")).Click();
        Assert.That(Driver.Title, Does.Contain("Сравнить"));

        // 7th step
        Actions action = new Actions(Driver);
        var descriptionTable = Driver.FindElement(
            By.XPath("//table//tbody[4]//tr[4]//td[contains(@class,'product-table__cell')][1]"));
        action.MoveToElement(descriptionTable);
        
        var description =
            Driver.FindElement(
                By.XPath("//table//tbody[4]//tr[4]//td[contains(@class,'product-table__cell')][1]//div"));
        action.MoveToElement(description);

        var descriptionText = Driver.FindElement(By.XPath("//*[contains(@data-tip-term , 'Описание')]"));
        descriptionText.Click();
        Assert.That(descriptionText.GetAttribute("class"), Does.Contain("product-table-tip__trigger_visible"));

        // 8th step
        var expectedResult =
            "Краткая информация об отличиях товара от конкурентных моделей и аналогов, сведения о позиционировании на рынке, преемственности и др.";
        description = Driver.FindElement(By.XPath("//*[contains(@data-tip-term , 'Описание')]"));
        Assert.That(description.GetAttribute("data-tip-text"), Does.Contain(expectedResult));

        // 9th step
        Driver.Navigate().Back();
        Assert.That(Driver.Title, Does.Contain("Мобильные телефоны Apple"));
    }
    [TearDown]
    public void QuitDriver()
    {
        Driver.Quit();
    }
    public void ScrollToView(IWebElement element)
    {
        if (element.Location.Y > 200)
        {
            var js = $"window.scrollTo({0}, {element.Location.Y-80})";
            IJavaScriptExecutor scriptExecutor= Driver as IJavaScriptExecutor;
            scriptExecutor.ExecuteScript(js);
        }
    }
}