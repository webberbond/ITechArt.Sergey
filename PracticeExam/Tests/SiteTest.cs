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

        MainPage.PickDate(-365); 
        
        MainPage.PickDate(-101000);
        
        MainPage.PickDate(+10); 
        
        MainPage.PickDate(+700);

        MainPage.PickDate(+600); 
        
        MainPage.PickDate(-666); 
        
        MainPage.PickDate(+66);
        
        MainPage.PickDate(-366); 
        
        MainPage.PickDate(-363); 
        
        MainPage.PickDate(-333); 
        
        MainPage.PickDate(+4); 
        
        MainPage.PickDate(+100000);
        
        MainPage.PickDate(+1000000);
        
        MainPage.PickDate(-100000);

        MainPage.PickDate(-10000);

        MainPage.PickDate(-1000);
    }
}