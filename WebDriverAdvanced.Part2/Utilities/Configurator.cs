namespace WebDriverBasics.Utilities;

public abstract class Configurator
{
    public static IConfiguration GetConfiguration()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json");
        var builder = new ConfigurationBuilder().AddJsonFile(path);
        var config = builder.Build();
        return config;
    }

    public static readonly ChromeOptions Settings = GetSettings();
    public static readonly Browser Browser = Enum.Parse<Browser>(GetConfiguration().GetSection("browser").Value, true);

    public static readonly string PathToDefaultDirectory =
        Path.Combine(AppContext.BaseDirectory, "Resources\\");

    private static ChromeOptions GetSettings()
    {
        var options = GetConfiguration().GetSection("startArguments").Get<string[]>();
        var settings = new ChromeOptions();
        settings.AddUserProfilePreference("download.default_directory", PathToDefaultDirectory);
        settings.AddArguments(options);
        return settings;
    }
}