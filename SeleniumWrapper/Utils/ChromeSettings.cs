using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Lection.SimpleWrapper.Core;

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