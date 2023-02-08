namespace SeleniumWrapper.Utils;

public class BrowserProfile
{
    public BrowserEnum BrowserName => BrowserEnum.Chrome;

    public DriverSettings DriverSettings
    {
        get
        {
            switch (BrowserName)
            {
                case BrowserEnum.Chrome:
                    return new ChromeSettings();
                default:
                    throw new InvalidOperationException($"Driver settings for browser '{BrowserName}' are not defined");
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