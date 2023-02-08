namespace SeleniumWrapper.Utils;

public class ChromeSettings : DriverSettings
{
    public override ChromeOptions DriverOptions
    {
        get
        {
            var options = new ChromeOptions();

            return options;
        }
    }
}