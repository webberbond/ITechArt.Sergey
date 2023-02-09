namespace SeleniumWrapper.Utils;

public class LocalBrowserFactory : BrowserFactory
{
    private BrowserProfile BrowserModel { get; }

    public LocalBrowserFactory(BrowserProfile browserModel)
    {
        BrowserModel = browserModel;
    }

    protected override WebDriver WebDriver
    {
        get
        {
            var browserName = BrowserModel.BrowserName;
            var driverSettingsStrings = BrowserModel.BrowserSettings;
            var driverSettings = new ChromeOptions();
            driverSettings.AddArguments(driverSettingsStrings);

            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    var options = driverSettings;
                    WebDriver webDriver = new ChromeDriver(options);
                    return webDriver;
                default:
                    throw new InvalidEnumArgumentException($"WebDriver for browser {browserName} is not supported");
            }
        }
    }
}

public enum BrowserEnum
{
    Chrome,
    Opera
}