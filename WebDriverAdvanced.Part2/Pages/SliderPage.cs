namespace WebDriverBasics.Pages;

public class SliderPage : BasePage
{
    private IWebDriver driver;

    public SliderPage(IWebDriver webDriver) : base(webDriver)
    {
        PageFactory.InitElements(webDriver, this);
    }

    protected override string UrlPath => "/horizontal_slider";


    protected override By? UniqueWebLocator => By.XPath("//h3[normalize-space()='Horizontal Slider']");

    [FindsBy(How = How.XPath, Using = "//input")]
    private IWebElement _slider;

    [FindsBy(How = How.XPath, Using = "//span[@id='range'][normalize-space()='3.5']")]
    private IWebElement _sliderValue;

    public void MoveSlider()
    {
        var action = new Actions(WebDriver);
        action.DragAndDropToOffset(_slider, 20, 0)
            .Perform();
    }

    public bool IfValueEquals()
    {
        var expectedValue = "3.5";
        if (_sliderValue.Text == expectedValue)
            return true;

        return false;
    }
}