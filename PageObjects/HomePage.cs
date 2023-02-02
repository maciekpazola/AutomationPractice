using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using AutomationPractice.DriverFolder;

namespace AutomationPractice.PageObjects
{
    public class HomePage
    {
        private readonly string _homePageUrl = "http://the-internet.herokuapp.com/";
        private readonly IWebDriver _driver = Driver.GetInstanceOfDriver().GetDriver();

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            ExpectedConditions.UrlMatches(_homePageUrl);
        }

        public void OpenPage(string sectionName) => _driver.FindElement(By.LinkText(sectionName)).Click();
    }
}
