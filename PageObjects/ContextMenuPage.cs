using AutomationPractice.AbstractionLayer.Components;
using FluentAssertions;
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
    public class ContextMenuPage
    {
        private readonly string BasicAuthPage_url = "http://the-internet.herokuapp.com/basic_auth";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ContextMenuPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "hot-spot")]
        private IWebElement elem_ContextMenu;
    }
}
