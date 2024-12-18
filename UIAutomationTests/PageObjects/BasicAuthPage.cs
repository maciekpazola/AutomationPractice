using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using UIAutomationTests.Helpers;
using UIAutomationTests.Drivers;

namespace UIAutomationTests.PageObjects
{
    public class BasicAuthPage
    {
        private IWebElement Message => Driver.GetDriver(_scenarioContext).FindElement(By.ClassName("example"));

        private readonly ScenarioContext _scenarioContext;
        private readonly StateChecker _stateChecker;
        private readonly string _basicAuthPageUrlWithCorrectCredentails = "http://admin:admin@the-internet.herokuapp.com/basic_auth";
        private readonly string _basicAuthPageUrlWithInCorrectCredentails = "http://notAdmin:notAdmin@the-internet.herokuapp.com/basic_auth";

        public BasicAuthPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stateChecker = new(_scenarioContext);
        }

        public void GoToAuthPage(string loginName)
        {
            var driver = Driver.GetDriver(_scenarioContext);
            switch (loginName)
            {
                case "admin":
                    {
                        driver.Navigate().GoToUrl(_basicAuthPageUrlWithCorrectCredentails);
                        ExpectedConditions.UrlMatches(_basicAuthPageUrlWithCorrectCredentails);
                        return;
                    }
                case "notAdmin":
                    {
                        driver.Navigate().GoToUrl(_basicAuthPageUrlWithInCorrectCredentails);
                        ExpectedConditions.UrlMatches(_basicAuthPageUrlWithInCorrectCredentails);
                        return;
                    }
            }
        }

        public bool IsUserLoggedIn() => _stateChecker.IsElementDisplayed(() => Message);
    }
}
