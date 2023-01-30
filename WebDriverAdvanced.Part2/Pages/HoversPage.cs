namespace WebDriverBasics.Pages;

public class HoversPage : BasePage
{
    private IWebDriver driver;

    public HoversPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    private WebDriverWait Wait => new(WebDriver, TimeSpan.FromSeconds(5));

    public enum ImageId
    {
        Image1 = 1,
        Image2 = 2,
        Image3 = 3
    }

    protected override string UrlPath => string.Empty;

    protected override string _baseUrl => "http://the-internet.herokuapp.com/hovers";

    protected override By UniqueWebLocator => By.XPath("//h3[normalize-space()='Hovers']");

    [FindsBy(How = How.XPath, Using = "//h3[normalize-space()='Hovers']")]
    private IWebElement _header;

    [FindsBy(How = How.CssSelector, Using = ".figure:nth-child(3) h5")]
    private IWebElement _pageSubHeader1;

    [FindsBy(How = How.CssSelector, Using = ".figure:nth-child(4) h5")]
    private IWebElement _pageSubHeader2;

    [FindsBy(How = How.CssSelector, Using = ".figure:nth-child(5) h5")]
    private IWebElement _pageSubHeader3;

    [FindsBy(How = How.CssSelector, Using = ".figure:nth-child(3) > img")]
    private IWebElement _image1;

    [FindsBy(How = How.CssSelector, Using = ".figure:nth-child(4) > img")]
    private IWebElement _image2;

    [FindsBy(How = How.CssSelector, Using = ".figure:nth-child(5) > img")]
    private IWebElement _image3;

    [FindsBy(How = How.LinkText, Using = "View profile")]
    private IWebElement _linkViewProfile;

    public void HoverOverImage(ImageId imageId)
    {
        var actions = new Actions(WebDriver);
        switch (imageId)
        {
            case ImageId.Image1:
                actions.MoveToElement(_image1);
                break;
            case ImageId.Image2:
                actions.MoveToElement(_image2);
                break;
            case ImageId.Image3:
                actions.MoveToElement(_image3);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(imageId), imageId, null);
        }

        actions.Perform();
    }

    public string ReadSubHeaderTextForImage(ImageId imageId)
    {
        var headerText = imageId switch
        {
            ImageId.Image1 => _pageSubHeader1.Text,
            ImageId.Image2 => _pageSubHeader2.Text,
            ImageId.Image3 => _pageSubHeader3.Text,
            _ => null
        };

        return headerText;
    }

    public void ClickViewProfileLink()
    {
        _linkViewProfile.Click();
    }

    public bool IsRightPage()
    {
        WebDriver.Navigate().Back();
        if (_header.Text == "Hovers")
            return true;

        return false;
    }
}