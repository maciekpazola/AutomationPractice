using AutomationPractice.Drivers.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class BasicAuthPage
    {
        private readonly string _basicAuthPageUrlWithCorrectCredentails = "http://admin:admin@the-internet.herokuapp.com/basic_auth";
        private readonly string _basicAuthPageUrlWithInCorrectCredentails = "http://notAdmin:notAdmin@the-internet.herokuapp.com/basic_auth";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private static BasicAuthPage instanceOfPage;


        public BasicAuthPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "example")]
        private IWebElement elem_Message;

        [FindsBy(How = How.XPath, Using = "//button[@class='added-manually']")]
        private IWebElement elem_Delete;

        public static BasicAuthPage GetBasicAuthPage()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            if (instanceOfPage == null)
            {
                instanceOfPage = new BasicAuthPage(driver);
            }
            return instanceOfPage;
        }

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

        public bool CheckThatYouAreLoggedIn()
        {
            try
            {
                var MessageInnerText = elem_Message.GetAttribute("innerText");
                return MessageInnerText != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
