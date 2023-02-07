using OpenQA.Selenium;

namespace Selenium.Lection.SimpleWrapper.Core;

public abstract class DriverSettings
{
    public abstract DriverOptions DriverOptions { get; }
}