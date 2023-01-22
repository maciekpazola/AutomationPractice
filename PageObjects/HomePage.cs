using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using AutomationPractice.DriverFolder;

namespace AutomationPractice.PageObjects
{
    public class HomePage
    {
        private readonly string _homePageUrl = "http://the-internet.herokuapp.com/";
        private readonly IWebDriver _driver = Driver.GetInstanceOfDriver().GetDriver();


        [FindsBy(How = How.LinkText, Using = "Add/Remove Elements")]
        private IWebElement elem_AddRemoveElements;

        [FindsBy(How = How.LinkText, Using = "Basic Auth")]
        private IWebElement elem_BasicAuth;

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
            ExpectedConditions.UrlMatches(_homePageUrl);
        }

        public void OpenPage(string sectionName) => _driver.FindElement(By.LinkText(sectionName)).Click();
    }
}
