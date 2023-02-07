namespace SeleniumWrapper.Elements;

public class Checkbox : BaseElement
{
    public Checkbox(By locator, string name) : base(locator, name)
    {
    }

    public bool IsChecked()
    {
        return FindElement().Enabled;
    }
}