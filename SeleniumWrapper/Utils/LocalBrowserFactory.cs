namespace SeleniumWrapper.Utils;

public class LocalBrowserFactory : BrowserFactory
{
    private BrowserProfile? BrowserProfile { get; }

    public LocalBrowserFactory(BrowserProfile? browserProfile)
    {
        BrowserProfile = browserProfile;
    }

    protected override WebDriver WebDriver
    {
        get
        {
            var browserName = BrowserProfile.BrowserName;
            var driverSettingsOptions = BrowserProfile.BrowserSettings;
            var driverSettings = new ChromeOptions();
            driverSettings.AddArguments(driverSettingsOptions);

            switch (browserName)
            {
                case BrowserEnum.Chrome:
                    var options = driverSettings;
                    Logger.Instance.Debug("initialize Chrome Window");
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
    Edge,
    FireFox
}