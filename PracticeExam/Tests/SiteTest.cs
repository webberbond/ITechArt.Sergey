namespace PracticeExam.Tests;

public class SiteTest : BaseTest
{
    [Test]
    public void ScrollingWebsite()
    {
        MainPage.OpenPage();
        Assert.That(MainPage.IsPageOpened, Is.True, "MainPage should be opened");
        
        MainPage.MoveToSection();
        Assert.True(MainPage.TestTaskSection.Displayed);
        
        MainPage.DeselectDates();
        
  
       MainPage.PeekDate2(+365);
       
       MainPage.PeekDate2(-10);
    }
}