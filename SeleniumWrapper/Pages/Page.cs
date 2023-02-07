using SeleniumWrapper.Elements;
using SeleniumWrapper.Forms;

namespace SeleniumWrapper.Pages;

public abstract class Page : BaseForm
{

    private BaseElement UniqueElement { get; }

    public bool IsPageOpened()
    {
        return UniqueElement.IsDisplayed();
    }

    protected Page(BaseElement uniqueElement, string pageName) : base(uniqueElement, pageName)
    {
        UniqueElement = uniqueElement;
    }
}