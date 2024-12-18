using OpenQA.Selenium;
using UIAutomationTests.Drivers;
using UIAutomationTests.Helpers;

namespace AutomationPractice.PageObjects
{
    public class FormAuthenticationPage
    {
        private IWebElement UsernameField => Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector("input[type='text']#username"));
        private IWebElement PasswordField => Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector("input[type='password']#password"));
        private IWebElement LoginButton => Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector(".radius[type='submit']"));
        private IWebElement MessageWhenLoggedIn => Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector("#flash[class='flash success']"));
        private IWebElement MessageWhenNotLoggedIn => Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector("#flash[class='flash error']"));

        private readonly ScenarioContext _scenarioContext;
        private readonly StateChecker _stateChecker;

        public FormAuthenticationPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stateChecker = new(_scenarioContext);
        }

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton() => LoginButton.Click();

        public bool IsUserLoggedIn()
        {
            if (_stateChecker.IsElementDisplayed(() => MessageWhenLoggedIn))
                return true;

            else if (_stateChecker.IsElementDisplayed(() => MessageWhenNotLoggedIn))
                return false;

            throw new Exception("Can't find message!");
        }
    }
}
