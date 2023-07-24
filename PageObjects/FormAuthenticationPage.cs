using AutomationPractice.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class FormAuthenticationPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='text']#username")]
        private readonly IWebElement _usernameField;

        [FindsBy(How = How.CssSelector, Using = "input[type='password']#password")]
        private readonly IWebElement _passwordField;

        [FindsBy(How = How.CssSelector, Using = ".radius[type='submit']")]
        private readonly IWebElement _loginButton;

        [FindsBy(How = How.CssSelector, Using = "#flash[class='flash success']")]
        private readonly IWebElement _messageWhenLoggedIn;

        [FindsBy(How = How.CssSelector, Using = "#flash[class='flash error']")]
        private readonly IWebElement _messageWhenNotLoggedIn;


        public void Login(string username, string password)
        {
            _usernameField.SendKeys(username);
            _passwordField.SendKeys(password);
        }

        public void ClickLoginButton() => _loginButton.Click();

        public bool CheckIfUserIsLoggedIn()
        {
            if (StateChecker.CheckIfItemIsEnabled(_messageWhenLoggedIn))
                return true;

            else if (StateChecker.CheckIfItemIsEnabled(_messageWhenNotLoggedIn))
                return false;

            throw new Exception("Can't find message!");
        }
    }
}
