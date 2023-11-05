using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Drivers;
using AutomationPractice.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class FormAuthenticationPage
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly StateChecker _stateChecker;
        private IWebElement UsernameField() => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector("input[type='text']#username"));
        private IWebElement PasswordField() => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector("input[type='password']#password"));
        private IWebElement LoginButton() => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector(".radius[type='submit']"));
        private readonly By MessageWhenLoggedInLocator = By.CssSelector("#flash[class='flash success']");
        private readonly By MessageWhenNotLoggedInLocator = By.CssSelector("#flash[class='flash error']");

        public FormAuthenticationPage(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _stateChecker = new(_featureContext, _scenarioContext);
        }

        public void Login(string username, string password)
        {
            UsernameField().SendKeys(username);
            PasswordField().SendKeys(password);
        }

        public void ClickLoginButton() => LoginButton().Click();

        public bool CheckIfUserIsLoggedIn()
        {
            if (_stateChecker.CheckIfItemIsEnabled(MessageWhenLoggedInLocator))
                return true;

            else if (_stateChecker.CheckIfItemIsEnabled(MessageWhenNotLoggedInLocator))
                return false;

            throw new Exception("Can't find message!");
        }
    }
}
