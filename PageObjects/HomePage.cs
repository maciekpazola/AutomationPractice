using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestUtilities.UITesting.Drivers;

namespace AutomationPractice.PageObjects
{
    public class HomePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _homePageUrl = "http://the-internet.herokuapp.com/";

        public HomePage(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        public void GoToHomePage()
        {
            IWebDriver _driver = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")); 
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            ExpectedConditions.UrlMatches(_homePageUrl);
        }

        public void OpenPage(string sectionName) => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.LinkText(sectionName)).Click();
    }
}
