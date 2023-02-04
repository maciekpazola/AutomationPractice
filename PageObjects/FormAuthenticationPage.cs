using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                if (messageWhenLoggedIn.Enabled)
                    return true;
                else if (messageWhenNotLoggedIn.Enabled)
                    return false;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            return false;
        }
    }
}
