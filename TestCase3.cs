namespace Selenium
{
    public class TestCase3 : Base
    { 
        [Test]
        [Description("TestCase for steam workshop, comparing elements")]
        public void WorkshopTest()
        {
            //Defining "community" and "workshop" buttons
            var target = driver.FindElement(By.XPath("//a[normalize-space()='COMMUNITY']"));
            var workshop = driver.FindElement(By.CssSelector("div[class='responsive_page_content'] div[class='submenu_community'] a:nth-child(4)"));

            //Handling community submenu
            Actions s = new Actions(driver);
            s.MoveToElement(target);
            s.Click(workshop);
            s.Build().Perform();

            //Finding button "Show advanced options...", selector of the game and Dota2 option
            driver.FindElement(By.CssSelector(".market_search_advanced_button")).Click();
            driver.FindElement(By.CssSelector(".market_app_selector")).Click();
            driver.FindElement(By.CssSelector("#app_option_570")).Click();

            //Handling dropdown with the hero name
            var dropdown = driver.FindElement(By.CssSelector("select[name='category_570_Hero[]']"));
            SelectElement hero = new SelectElement(dropdown);
            hero.SelectByText("Lifestealer");
            
            //Finding rarirt of the item, sending keys to the searchBox and button "Search"
            driver.FindElement(By.CssSelector("#tag_570_Rarity_Rarity_Immortal")).Click();
            driver.FindElement(By.CssSelector("#advancedSearchBox")).SendKeys("golden");
            driver.FindElement(By.XPath("//div[@class='btn_medium btn_green_white_innerfade']")).Click();

            //Handling first five positions in the list and prove they contain the word "Golden"
            IList<IWebElement> actualResult = driver.FindElements(By.XPath("(//*[contains(text(), 'Golden')])[position() < 6]"));
            String[] alltext = new string[actualResult.Count];
            int i = 0;
            foreach (IWebElement element in actualResult)
            {
                alltext[i++] = element.Text;
                TestContext.WriteLine(element.Text);
            }
            
            //Finding selected filters "Immortal" and "golden"
            driver.FindElement(By.XPath("//a[normalize-space()='Immortal']")).Click();
            driver.FindElement(By.XPath("//a[normalize-space()='\"golden\"']")).Click();

            //Picking actual name from the list and then comparing it with the name displayed after clicking on the item
            var name = driver.FindElement(By.XPath("//span[@id='result_0_name']")).Text;
            driver.FindElement(By.XPath("//div[@id='searchResultsRows']//a[position() = 1]")).Click();
            var compareName = driver.FindElement(By.XPath("//h1[@id='largeiteminfo_item_name']")).Text;
            Assert.IsTrue(name == compareName);
        }
    }
}