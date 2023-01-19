namespace WebDriverBasics.DriverConfiguration;
public class WebDriverFactory
{
    public IWebDriver GetDriver()
    {
        IWebDriver driver;

        var browser = Configurator.Browser;

        switch (browser)
        {
            case Browser.Chrome:
                driver = new ChromeDriver(Configurator.Settings);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver;
            case Browser.Edge:
                driver = new EdgeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver; 
            case Browser.FireFox:
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver;
            default: throw new ArgumentException($"Browser '{browser}' is not supported yet");
        }
    }
}

public enum Browser
{
    Chrome,
    Edge,
    FireFox
}