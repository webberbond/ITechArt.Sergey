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

        // Read start arguments option
        string[] chromeOptions = config.GetSection("startArguments").Get<string[]>();
        Settings = new ChromeOptions();
        Settings.AddArguments(chromeOptions);

        // Read browser 
        var browserName = config.GetValue<string>("browser");
        Browser = Enum.Parse<Browser>(browserName, true);

        // Read url
        BaseUrl = config.GetValue<string>("Url");
    }
}
