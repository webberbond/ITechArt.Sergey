namespace WebDriverBasics.Pages;

public class UploadFilePage : BasePage
{
    private IWebDriver driver;

    public UploadFilePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => string.Empty;

    protected override string _baseUrl => "http://the-internet.herokuapp.com/upload";

    protected override By? UniqueWebLocator => By.XPath("//h3[normalize-space()='File Uploader']");

    [FindsBy(How = How.XPath, Using = "//input[@id='file-upload']")]
    private IWebElement _chooseFileButton;

    [FindsBy(How = How.XPath, Using = "//input[@id='file-submit']")]
    private IWebElement _uploadButton;

    [FindsBy(How = How.XPath, Using = "//h3")]
    private IWebElement _successParagraph;

    public void UploadPicture()
    {
        _chooseFileButton.SendKeys(
            $"C:\\Users\\HomeUser\\Desktop\\WebDriverAdvanced.Part2\\WebDriverAdvanced.Part2\\Pictures\\SeleniumPicture.png");
    }

    public void ClickUploadButton()
    {
        _uploadButton.Click();
    }

    public bool IfContainsString()
    {
        if (_successParagraph.Text.Contains("File Uploaded!"))
            return true;

        return false;
    }
}