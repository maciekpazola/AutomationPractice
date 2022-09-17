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



namespace AutomationPractice.PageObjects
{
    public class HomePage : BasePage
    {
        string homePage_url = "http://the-internet.herokuapp.com/";
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Add/Remove Elements")]
        private IWebElement elem_AddRemoveElements;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Basic Auth')]")]
        private IWebElement elem_BasicAuth;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Basic A123uth')]")]
        [CacheLookup]
        private IWebElement elem_wrongelement;

        // Go to the designated page
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(homePage_url);
            ExpectedConditions.UrlMatches(homePage_url);
        }

        public void OpenAddRemoveElementsLink()
        {
            elem_AddRemoveElements.Click();
        }
        public void OpenBasicAuthLink()
        {
            elem_BasicAuth.Click();
        }
    }
}
