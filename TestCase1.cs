namespace Selenium
{
    public class TestCase1 : Base
    {
        [Test]
        public void ClickAndCompare()
        {
            driver.FindElement(By.XPath("//a[contains(text(), 'ABOUT')]")).Click();

            var onlinePlayers = driver.FindElement(By.XPath("//*[@class='online_stats']//*[@class='online_stat_label gamers_online']/.."));

            var ingamePlayers = driver.FindElement(By.XPath("//*[@class='online_stats']//*[@class='online_stat_label gamers_in_game']/.."));

            int.TryParse(string.Join("", (onlinePlayers.Text).Where(char.IsDigit)), out var onlinePlayersValue);
            int.TryParse(string.Join("", (ingamePlayers.Text).Where(char.IsDigit)), out var ingamePlayersValue);
            
            Assert.IsTrue(onlinePlayersValue > ingamePlayersValue);
            
            driver.FindElement(By.XPath("//a[normalize-space()='STORE']")).Click();
        }
    }
}