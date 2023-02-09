namespace SeleniumWrapperTests.Config;

public abstract class AppConfiguration
{
    private const string UrlKey = "url";

    private const string BrowserKey = "browser";

    private const string StartArgumentKey = "startArguments";

    private const string ConditionTimeoutKey = "conditionTimeout";

    public static readonly string? BaseUrl = Configurator.GetConfiguration().GetSection(UrlKey).Value;


    public static BrowserProfile BrowserProfile
    {
        get
        {
            var browserModel = new BrowserProfile
            {
                BrowserName =
                    Enum.Parse<BrowserEnum>(Configurator.GetConfiguration().GetSection(BrowserKey).Value!, true),
                BrowserSettings = Configurator.GetConfiguration().GetSection(StartArgumentKey).Get<string[]>(),
                ConditionTimeWait =
                    Convert.ToInt32(Configurator.GetConfiguration().GetSection(ConditionTimeoutKey).Value)
            };
            return browserModel;
        }
    }
}