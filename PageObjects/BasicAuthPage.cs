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
        private readonly string BasicAuthPage_url = "http://the-internet.herokuapp.com/basic_auth";
        private readonly string BasicAuthPage_url_withCorrectCredentails = "http://admin:admin@the-internet.herokuapp.com/basic_auth";
        private readonly string BasicAuthPage_url_withInCorrectCredentails = "http://notAdmin:notAdmin@the-internet.herokuapp.com/basic_auth";
        private readonly string OutputMessage = @"Basic Auth\n\nCongratulations! You must have the proper credentials.";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public BasicAuthPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "example")]
        private IWebElement elem_Message;

        [FindsBy(How = How.XPath, Using = "//button[@class='added-manually']")]
        private IWebElement elem_Delete;

        public void GoToAuthPage(string loginName)
        {
            switch (loginName)
            {
                case "admin":
                    {
                        driver.Navigate().GoToUrl(BasicAuthPage_url_withCorrectCredentails);
                        ExpectedConditions.UrlMatches(BasicAuthPage_url_withCorrectCredentails);
                        return;
                    }
                case "notAdmin":
                    {
                        driver.Navigate().GoToUrl(BasicAuthPage_url_withInCorrectCredentails);
                        ExpectedConditions.UrlMatches(BasicAuthPage_url_withInCorrectCredentails);
                        return;
                    }
            }
        }
        public bool CheckThatYouAreLoggedIn()
        {
            bool state = false;
            var output = elem_Message.GetAttribute("innerText");
            if (output == OutputMessage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
