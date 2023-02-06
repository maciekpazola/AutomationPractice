using AutomationPractice.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class FormAuthenticationPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='text']#username")]
        private IWebElement usernameField;

        [FindsBy(How = How.CssSelector, Using = "input[type='password']#password")]
        private IWebElement passwordField;

        [FindsBy(How = How.CssSelector, Using = ".radius[type='submit']")]
        private IWebElement loginButton;

        [FindsBy(How = How.CssSelector, Using = "#flash[class='flash success']")]
        private IWebElement messageWhenLoggedIn;

        [FindsBy(How = How.CssSelector, Using = "#flash[class='flash error']")]
        private IWebElement messageWhenNotLoggedIn;


        public void Login(string username, string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
        }

        public void ClickLoginButton() => loginButton.Click();

        public bool CheckIfUserIsLoggedIn()
        {
            if (StateCheck.CheckIfItemIsEnabled(messageWhenLoggedIn))
                return true;

            else if (StateCheck.CheckIfItemIsEnabled(messageWhenNotLoggedIn))
                return false;

            throw new Exception("Can't find message!");
        }
    }
}
