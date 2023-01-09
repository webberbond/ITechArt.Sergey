namespace UnitTesting.Tests;

[TestFixture]
[Parallelizable(ParallelScope.None)]
[assembly: LevelOfParallelism(3)]
public class BaseAttributes
{
    public IWebDriver Driver;
    
    [SetUp]
    public void StartBrowser()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        Driver = new ChromeDriver();

        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Driver.Manage().Window.Maximize();
        Driver.Url = "https://calculator.com/";
    }

    [OneTimeSetUp]
    public void PrintSetup()
    {
        TestContext.WriteLine("OneTimeSetUp attribute was used");
    }

    [TearDown]
    public void CloseBrowser()
    {
        Driver.Close();
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