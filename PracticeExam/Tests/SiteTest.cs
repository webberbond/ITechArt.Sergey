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

        MainPage.PickDate(-365); //10.03.2022
        
        MainPage.PickDate(+10); //10.03.2023
        
        MainPage.PickDate(+700); //7.02.2025
        
        MainPage.PickDate(+600); //30.10.2024
        
        MainPage.PickDate(-666); //13.05.2021
        
        MainPage.PickDate(+66); //15.05.2023
        
        MainPage.PickDate(-366); //09.03.2022
        
        MainPage.PickDate(-363); //12.03.2022
        
        MainPage.PickDate(-333); //11.04.2022
        
        MainPage.PickDate(+4); //14.03.2023
        
        MainPage.PickDate(+1000000); //04.02.4761

        MainPage.PickDate(+800);
        
        MainPage.PickDate(-200);
        
        MainPage.PickDate(-1000); //13.06.2020
    }
}