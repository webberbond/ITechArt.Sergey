namespace SeleniumWrapper.Elements;

public class Image : BaseElement
{
    public Image(By locator, string name) : base(locator, name)
    {
    }

    public string GetSrc()
    {
        return FindElement().GetAttribute("src");
    }
}