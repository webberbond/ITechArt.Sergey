using SeleniumWrapper.Helpers;

namespace SeleniumWrapper.Forms;

public abstract class BaseForm
{
    protected BaseElement UniqueElement;

    protected BaseForm(BaseElement uniqueElement)
    {
        UniqueElement = uniqueElement;
    }
    
    private bool IsDisplayed()
    {
        return UniqueElement.IsDisplayed();
    }

    public void WaitForOpen()
    {
        WaitUtil.WaitUntil((IsDisplayed()));
    }
}