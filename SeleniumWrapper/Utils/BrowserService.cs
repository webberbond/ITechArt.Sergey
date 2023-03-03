namespace SeleniumWrapper.Utils;

public static class BrowserService
{
    public static BrowserProfile? BrowserProfile { get; set; }
    private static readonly ThreadLocal<IBrowser?> BrowserContainer = new();

    private static readonly ThreadLocal<BrowserFactory?> BrowserFactoryContainer = new();

    private static bool IsApplicationStarted()
    {
        return BrowserContainer is {Value.IsStarted: true, IsValueCreated: true};
    }

    public static Browser StartBrowser(BrowserProfile? browserModel)
    {
        BrowserProfile = browserModel;
        var browser = (Browser) GetBrowser()!;
        return browser;
    }

    public static Browser? Browser => (Browser) GetBrowser()!;


    public static bool IsBrowserStarted => IsApplicationStarted();

    private static IBrowser? GetBrowser()
    {
        if (!IsApplicationStarted()) BrowserContainer.Value = BrowserFactory?.GetBrowser;

        return BrowserContainer.Value;
    }

    private static BrowserFactory? BrowserFactory
    {
        get
        {
            if (!BrowserFactoryContainer.IsValueCreated) SetDefaultFactory();

            return BrowserFactoryContainer.Value;
        }

        set => BrowserFactoryContainer.Value = value;
    }

    private static void SetDefaultFactory()
    {
        BrowserFactory = new LocalBrowserFactory(BrowserProfile);
    }
}