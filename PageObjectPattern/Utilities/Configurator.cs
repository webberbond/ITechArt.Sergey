namespace WebDriverBasics.Utilities;

public abstract class Configurator
{
    public static readonly ChromeOptions Settings;
    public static readonly string BaseUrl;
    public static readonly Browser Browser;

    static Configurator()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json"))
            .Build();

        var chromeOptions = config.GetSection("startArguments").Get<string[]>();
        Settings = new ChromeOptions();
        Settings.AddArguments(chromeOptions);

        var browserName = config.GetValue<string>("browser");
        Browser = Enum.Parse<Browser>(browserName, true);

        BaseUrl = config.GetValue<string>("Url");
    }
}