namespace WebDriverBasics.Pages;

public class MyPage : BasePage
{
    public MyPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }


    protected override By UniqueWebLocator => By.XPath("//div[@class='avatar-and-interests']");
    protected override string UrlPath => string.Empty;
}