using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects
{
    public class BasicAuthPage
    {
        private readonly string _basicAuthPageUrlWithCorrectCredentails = "http://admin:admin@the-internet.herokuapp.com/basic_auth";
        private readonly string _basicAuthPageUrlWithInCorrectCredentails = "http://notAdmin:notAdmin@the-internet.herokuapp.com/basic_auth";
        private readonly IWebDriver _driver = Driver.GetInstanceOfDriver().GetDriver();

        [FindsBy(How = How.ClassName, Using = "example")]
        private IWebElement message;

        public void GoToAuthPage(string loginName)
        {
            switch (loginName)
            {
                case "admin":
                    {
                        _driver.Navigate().GoToUrl(_basicAuthPageUrlWithCorrectCredentails);
                        ExpectedConditions.UrlMatches(_basicAuthPageUrlWithCorrectCredentails);
                        return;
                    }
                case "notAdmin":
                    {
                        _driver.Navigate().GoToUrl(_basicAuthPageUrlWithInCorrectCredentails);
                        ExpectedConditions.UrlMatches(_basicAuthPageUrlWithInCorrectCredentails);
                        return;
                    }
            }
        }

        public void AssertThatYouAreloggedIn()
        {
            bool visibilityOfMessage = StateCheck.CheckIfYouAreLoggedInByMessage(message);
            if (!visibilityOfMessage)
            {
                throw new Exception("Test is failed, can't find the message after authorization");
            }
        }
        public void AssertThatYouAreNotloggedIn()
        {
            bool visibilityOfMessage = StateCheck.CheckIfYouAreLoggedInByMessage(message);
            if (visibilityOfMessage)
            {
                throw new Exception("Test is failed, message was found");
            }
        }
    }
}
