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
        private readonly string _basicAuthPageUrlWithCorrectCredentails = "http://admin:admin@the-internet.herokuapp.com/basic_auth";
        private readonly string _basicAuthPageUrlWithInCorrectCredentails = "http://notAdmin:notAdmin@the-internet.herokuapp.com/basic_auth";
        [FindsBy(How = How.ClassName, Using = "example")]
        private readonly IWebElement _message;

        public void GoToAuthPage(string loginName)
        {
            var driver = Driver.GetDriver(TestScenarioContext.ScenarioContext.Get<string>("BrowserName"));
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
            bool visibilityOfMessage = StateChecker.CheckIfItemIsEnabled(_message);
            if (!visibilityOfMessage )
            {
                throw new Exception("Test is failed, can't find the message after authorization");
            }
        }
        public void AssertThatYouAreNotloggedIn()
        {
            bool visibilityOfMessage = StateChecker.CheckIfItemIsEnabled(_message);
            if (visibilityOfMessage)
            {
                throw new Exception("Test is failed, message was found");
            }
        }
    }
}
