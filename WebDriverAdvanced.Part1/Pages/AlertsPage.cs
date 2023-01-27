namespace WebDriverBasics.Pages;

public class AlertsPage : BasePage
{
    private IWebDriver driver;

    public AlertsPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override By UniqueWebLocator =>
        By.XPath("//div[@class='main-header'][contains(.,'Alerts, Frame & Windows')]");

    protected override string UrlPath => string.Empty;

    private readonly List<string> _expectedText = new()
    {
        "You clicked a button",
        "Do you confirm action?"
    };

    private static readonly Random Random = new();

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    [FindsBy(How = How.XPath, Using = "//button[@id='alertButton']")]
    private IWebElement AlertButton;

    [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']//li[@id='item-1']")]
    private IWebElement Alerts;

    [FindsBy(How = How.XPath, Using = "//button[@id='confirmButton']")]
    private IWebElement ConfirmBoxButton;

    [FindsBy(How = How.XPath, Using = "//span[@id='confirmResult']")]
    private IWebElement ConfirmResult;

    [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']//li[@id='item-2'][.='Frames']")]
    private IWebElement FramesButton;

    [FindsBy(How = How.XPath,
        Using = "//div[@class='element-list collapse show']//li[@id='item-3'][.='Nested Frames']")]
    private IWebElement NestedFramesButton;

    [FindsBy(How = How.XPath, Using = "//button[@id='promtButton']")]
    private IWebElement PromptBoxButton;

    [FindsBy(How = How.XPath,
        Using = "//div[@class='element-list collapse show']//li[@id='item-0'][.='Browser Windows']")]
    private IWebElement BrowserWindowsButton;

    [FindsBy(How = How.XPath, Using = "//button[@id='tabButton'][contains(.,'New Tab')]")]
    private IWebElement NewTabButton;

    [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'header-wrapper')])")]
    private IWebElement ElementsDropdown;

    [FindsBy(How = How.XPath,
        Using = "//div[contains(@class,'element-list collapse show')]//li[@id='item-5'][.='Links']")]
    private IWebElement LinksButton;

    [FindsBy(How = How.XPath, Using = "//a[@id='simpleLink'][normalize-space()='Home']")]
    private IWebElement HomeButton;

    private IWebElement FrameBody => WebDriver.FindElement(By.TagName("body"));

    private IWebElement FrameHeader => WebDriver.FindElement(By.XPath("//h1[@id='sampleHeading']"));
    
    public void GetAlert()
    {
        Alerts.Click();
        AlertButton.Click();
    }

    public bool IsAlertShown
    {
        get
        {
            try
            {
                WebDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
        }
    }

    public bool IsAlertClosed
    {
        get
        {
            try
            {
                WebDriver.SwitchTo().Alert();
                return false;
            }
            catch (NoAlertPresentException)
            {
                return true;
            }  
        }
    }

    public bool AlertTextEquals()
    {
        var alert = WebDriver.SwitchTo().Alert();
        return alert.Text == _expectedText[0];
    }

    public void AcceptAlert()
    {
        var alert = WebDriver.SwitchTo().Alert();
        alert.Accept();
    }

    public void GetConfirmBox()
    {
        ConfirmBoxButton.Click();
    }

    public bool ConfirmBoxTextEquals()
    {
        var alert = WebDriver.SwitchTo().Alert();
        return alert.Text == _expectedText[1];
    }

    public bool ConfirmBoxDisplaySuccess()
    {
        return ConfirmResult.Displayed;
    }

    public void GetPromptBox()
    {
        PromptBoxButton.Click();
    }

    public void SendTextToPromptBox()
    {
        var alert = WebDriver.SwitchTo().Alert();
        alert.SendKeys(RandomString(10));
        alert.Accept();
    }

    public bool IsPromptBoxLabelDisplayed()
    {
        var label = WebDriver.FindElement(By.XPath("//span[@id='promptResult']"));

        if (label.Displayed)
            return true;

        return false;
    }

    public void SwitchToParentFrame()
    {
        NestedFramesButton.Click();

        WebDriver.SwitchTo().Frame(1);
    }

    public bool IsParentTextDisplayed()
    {
        if (FrameBody.Text.Contains("Parent frame")) 
            return true;

        return false;
    }

    public void SwitchToChildFrame()
    {
        WebDriver.SwitchTo().Frame(0);
    }

    public bool IsChildTextDisplayed()
    {
        if (FrameBody.Text.Contains("Child Iframe")) 
            return true;

        return false;
    }

    public bool TestFrames()
    {
        WebDriver.SwitchTo().DefaultContent();
        FramesButton.Click();
        var bigFrame = WebDriver.FindElement(By.Id("frame1"));
        WebDriver.SwitchTo().Frame(bigFrame);
        var bigFrameText = FrameHeader.Text;

        WebDriver.SwitchTo().DefaultContent();

        var smallFrame = WebDriver.FindElement(By.Id("frame2"));
        WebDriver.SwitchTo().Frame(smallFrame);
        var smallFrameText = FrameHeader.Text;

        if (bigFrameText == smallFrameText)
            return true;

        return false;
    }

    public void BrowserWindowsTest()
    {
        BrowserWindowsButton.Click();
        NewTabButton.Click();
    }

    public void SwitchToNewTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
    }

    public bool IsNewPageOpened()
    {
        const string expectedResult = "This is a sample page";
        var tabHeading = WebDriver.FindElement(By.XPath("//h1[@id='sampleHeading']"));
        if (tabHeading.Text == expectedResult)
            return true;

        return false;
    }

    public void CloseTab()
    {
        WebDriver.Close();
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
    }

    public void LinksPageOpen()
    {
        ElementsDropdown.Click();
        LinksButton.Click();
    }

    public void HomeButtonClick()
    {
        HomeButton.Click();
    }

    public bool MainPageOpen()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
        
        var homeBanner = WebDriver.FindElement(By.XPath("//div[@class='home-banner']"));

        if (homeBanner.Displayed)
            return true;

        return false;
    }

    public void SwitchToPreviousTab()
    {
        WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
    }
}