﻿using System;
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
        private readonly string homePage_url = "http://the-internet.herokuapp.com/";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Add/Remove Elements")]
        private IWebElement elem_AddRemoveElements;

        [FindsBy(How = How.LinkText, Using = "Basic Auth")]
        private IWebElement elem_BasicAuth;

        // Go to the designated page
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(homePage_url);
            ExpectedConditions.UrlMatches(homePage_url);
        }

        public void OpenPage(string sectionName)
        {
            driver.FindElement(By.LinkText(sectionName)).Click();
        }
    }
}
