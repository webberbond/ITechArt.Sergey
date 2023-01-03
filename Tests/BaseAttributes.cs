namespace UnitTesting.Tests;

[TestFixture]
[Parallelizable(ParallelScope.None)]
[assembly: LevelOfParallelism(3)]
public class BaseAttributes
{
    public IWebDriver driver;
    
    [SetUp]
    public void StartBrowser()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Manage().Window.Maximize();
        driver.Url = "https://calculator.com/";
    }

    [OneTimeSetUp]
    public void PrintSetup()
    {
        TestContext.WriteLine("OneTimeSetUp attribute was used");
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Close();
    }
    
    [OneTimeTearDown]
    public void PrintTearDown()
    {
        TestContext.WriteLine("OneTimeTearDown attribute was used");
    }
}

[SetUpFixture]
public class WriteConsole
{
    [OneTimeSetUp]
    public void Write()
    {
        TestContext.WriteLine("SetUpFixture attribute using");
    }
}