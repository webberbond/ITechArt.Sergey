namespace SeleniumWrapper.Elements;

public class TextField : BaseElement
{
    public TextField(By locator, string name) : base(locator, name)
    {
    }

    public void SendText(string text)
    {
        FindElement().Clear();
        FindElement().SendKeys(text);
    }
}