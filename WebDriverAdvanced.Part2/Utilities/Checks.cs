namespace WebDriverBasics.Utilities;

public abstract class Checks : DownloadFilePage
{
    protected Checks(IWebDriver webDriver) : base(webDriver)
    {
    }

    public static void IfFileExists()
    {
        var result = CheckFile(Name);
        if (result)
            TestContext.WriteLine("The file exists");
        else if (result == false)
            TestContext.Error.WriteLine("The file does not exist");
        else
            TestContext.Error.WriteLine("The directory or folder does not exist!");
    }

    private static bool CheckFile(string name)
    {
        CurrentFile = $"C:\\Users\\HomeUser\\Downloads\\{name}";
        if (File.Exists(CurrentFile))
            return true;

        return false;
    }
}