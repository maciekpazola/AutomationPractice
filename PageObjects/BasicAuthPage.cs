using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using AutomationPractice.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects
{
    public class BasicAuthPage
    {
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
            var driver = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName"));
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

        public void AssertThatYouAreloggedIn()
        {
            By _messageLocator = By.ClassName("example");
            bool visibilityOfMessage = _stateChecker.CheckIfItemIsEnabled(_messageLocator);
            if (!visibilityOfMessage )
            {
                throw new Exception("Test is failed, can't find the message after authorization");
            }
        }
        public void AssertThatYouAreNotloggedIn()
        {
            By _messageLocator = By.ClassName("example");
            bool visibilityOfMessage = _stateChecker.CheckIfItemIsEnabled(_messageLocator);
            if (visibilityOfMessage)
            {
                throw new Exception("Test is failed, can't find the message after authorization");
            }
        }
    }
}
