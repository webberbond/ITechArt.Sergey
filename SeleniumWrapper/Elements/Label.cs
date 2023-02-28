namespace SeleniumWrapper.Elements;

public class Label : BaseElement
{
    public Label(By locator, string name) : base(locator, name)
    {
    }

    public string GetValue()
    {
        return FindElement().GetAttribute("value");
    }

    public new string GetText()
    {
        return FindElement().Text;
    }

    public string GetInnerHtml()
    {
        return FindElement().GetAttribute("innerHTML");
    }
}