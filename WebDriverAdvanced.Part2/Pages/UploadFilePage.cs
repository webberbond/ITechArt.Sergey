namespace WebDriverBasics.Pages;

public class UploadFilePage : BasePage
{
    private IWebDriver driver;

    public UploadFilePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => "/upload";


    protected override By? UniqueWebLocator => By.XPath("//h3[normalize-space()='File Uploader']");

    [FindsBy(How = How.XPath, Using = "//input[@id='file-upload']")]
    private IWebElement _chooseFileButton;

    [FindsBy(How = How.XPath, Using = "//input[@id='file-submit']")]
    private IWebElement _uploadButton;

    [FindsBy(How = How.XPath, Using = "//h3")]
    private IWebElement _successParagraph;

    private const string NameOfFile = "SeleniumPicture.png";

    private static readonly string ImagePath = Configurator.PathToDefaultDirectory + NameOfFile;


    public void UploadPicture()
    {
        _chooseFileButton.SendKeys(ImagePath);
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