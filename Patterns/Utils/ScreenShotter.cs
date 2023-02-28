namespace Patterns.Utils;

public abstract class ScreenShotting : BaseTest
{
    public static void TakeScreenshot()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;

        if (status is TestStatus.Failed or TestStatus.Passed)
        {
            var webDriver = WebDriver;
            var screenshot = webDriver.GetScreenshot();
            var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".png";
            var path = Path.Combine(AppContext.BaseDirectory, "Resources", filename);
            screenshot.SaveAsFile(path);

            AllureLifecycle.Instance.AddAttachment(path);
        }
    }
}