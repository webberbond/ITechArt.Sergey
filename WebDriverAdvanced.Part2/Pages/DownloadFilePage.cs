namespace WebDriverBasics.Pages;

public class DownloadFilePage : BasePage
{
    private IWebDriver driver;

    public DownloadFilePage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => string.Empty;

    protected override string _baseUrl => "http://the-internet.herokuapp.com/download";

    protected override By? UniqueWebLocator => By.XPath("//h3[normalize-space()='File Downloader']");

    private string _currentFile = string.Empty;

    private string _name = string.Empty;
    
    public void Download()
    {
        _name = WebDriver.FindElement(By.LinkText("Практическое_задание_работа_с_компонентами_Selenium.docx")).Text;
        WebDriver.FindElement(By.LinkText("Практическое_задание_работа_с_компонентами_Selenium.docx")).Click();
        Task.Delay(5000).Wait();
    }

    public void IfFileExists()
    {
        var result = CheckFile(_name);
        if (result)
            TestContext.WriteLine("The file exists");
        else if (result == false)
            TestContext.WriteLine("The file does not exist");
        else
            TestContext.WriteLine("The directory or folder does not exist!");
    }

    public bool CheckFile(string name)
    {
        _currentFile = $"C:\\Users\\HomeUser\\Downloads\\{name}";
        if (File.Exists(_currentFile))
            return true;

        return false;
    }
}