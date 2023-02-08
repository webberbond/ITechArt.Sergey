namespace SeleniumWrapper.Pages;

public abstract class Page : BaseForm
{
   
    
    public Browser Browser => BrowserService.Browser;
    
    public bool IsPageOpened()
    {
        return UniqueElement.IsDisplayed();
    }


    protected Page(BaseElement uniqueElement) : base(uniqueElement)
    {
    }
}