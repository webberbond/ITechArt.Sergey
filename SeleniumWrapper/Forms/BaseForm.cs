using SeleniumWrapper.Elements;

namespace SeleniumWrapper.Forms;

public abstract class BaseForm
{
    protected BaseElement Element;
    protected string Name;

    protected BaseForm(BaseElement element, string name)
    {
        Element = element;
        Name = name;
    }

    public bool IsDisplayed()
    {
        return Element.IsDisplayed();
    }
}