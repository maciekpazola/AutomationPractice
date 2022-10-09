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
using AutomationPractice.Drivers.Driver;

namespace AutomationPractice.PageObjects
{
    public class HomePage
    {
        private readonly string _homePageUrl = "http://the-internet.herokuapp.com/";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private static HomePage instanceOfPage;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Add/Remove Elements")]
        private IWebElement elem_AddRemoveElements;

        [FindsBy(How = How.LinkText, Using = "Basic Auth")]
        private IWebElement elem_BasicAuth;

            public static HomePage GetHomePage()
            {
                IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
                if (instanceOfPage == null)
                {
                instanceOfPage = new HomePage(driver);
                }
                return instanceOfPage;
            }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl(_homePageUrl);
            ExpectedConditions.UrlMatches(_homePageUrl);
        }

        public void OpenPage(string sectionName) => _driver.FindElement(By.LinkText(sectionName)).Click();
    }
}
