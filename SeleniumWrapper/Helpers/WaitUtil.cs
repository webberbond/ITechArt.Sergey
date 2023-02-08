namespace SeleniumWrapper.Helpers;

public static class WaitUtil
{
    private static readonly WebDriverWait Wait = new(Browser.WebDriver, JsonReader.GetTimeSpanValue("appsettings.json"));

    public static void WaitUntil(bool condition)
    {
        Wait.Until(_=>condition);
    }
}