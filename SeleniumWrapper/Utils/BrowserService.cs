namespace Selenium.Lection.SimpleWrapper.Core;

public static class BrowserService
{
    private static readonly ThreadLocal<IBrowser> BrowserContainer = new ThreadLocal<IBrowser>();
    
    private static readonly ThreadLocal<BrowserFactory> BrowserFactoryContainer = new ThreadLocal<BrowserFactory>();

    private static bool IsApplicationStarted() => BrowserContainer.IsValueCreated && BrowserContainer.Value.IsStarted;

    public static Browser Browser => (Browser)GetBrowser();

    public static bool IsBrowserStarted => IsApplicationStarted();

    private static IBrowser GetBrowser()
    {
        if (!IsApplicationStarted())
        {
            BrowserContainer.Value = BrowserFactory.GetBrowser;
        }

        return BrowserContainer.Value;
    }

    private static BrowserFactory BrowserFactory
    {
        get
        {
            if (!BrowserFactoryContainer.IsValueCreated)
            {
                SetDefaultFactory();
            }
            
            return BrowserFactoryContainer.Value;
        }
        set => BrowserFactoryContainer.Value = value;
    }
    
    private static void SetDefaultFactory()
    {
        BrowserFactory =  new LocalBrowserFactory(BrowserProfile);
    }

    private static BrowserProfile BrowserProfile
    {
        get
        {
            return new BrowserProfile();
        }
    }
}