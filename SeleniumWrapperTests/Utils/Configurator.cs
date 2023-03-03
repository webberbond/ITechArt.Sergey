namespace SeleniumWrapperTests.Utils;

public abstract class Configurator
{
    public static IConfiguration GetConfiguration()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json"))
            .Build();
        return config;
    }
}