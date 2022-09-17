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
using AutomationPractice.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class AddRemoveElementsPage
    {
        string AddRemoveElementPage_url = "http://the-internet.herokuapp.com/";
        private IWebDriver driver;
        private WebDriverWait wait;

        public AddRemoveElementsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='example']/button")]
        private IWebElement elem_AddElementButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='added-manually']")]
        private IWebElement elem_Delete;

        public void ClickAddElementButton()
        {
            elem_AddElementButton.Click();
        }
        public void DeleteElement()
        {
            elem_Delete.Click();
        }
        public bool CheckDeleteElement()
        {
            try
            {
                bool state = elem_Delete.Displayed;
                return state;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
