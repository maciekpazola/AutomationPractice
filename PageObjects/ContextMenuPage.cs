using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Drivers.Driver;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private readonly string _expectedTextInTheAlert = "You selected a context menu";
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private static ContextMenuPage instanceOfPage;


        public ContextMenuPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "hot-spot")]
        private IWebElement elem_ContextMenu;

        public static ContextMenuPage GetContextMenuPage()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            if (instanceOfPage == null)
            {
                instanceOfPage = new ContextMenuPage(driver);
            }
            return instanceOfPage;
        }

        private IAlert GetAlertWindow()
        {
            var alert_win = _driver.SwitchTo().Alert();
            return alert_win;
        }

        public void RightClickOnContextMenu()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(elem_ContextMenu).ContextClick().Perform();
        }

        public void AssertTextInTheAlert()
        {
            var alert = GetAlertWindow();
            string textInTheAlert = alert.Text;
            Assert.AreEqual(_expectedTextInTheAlert, textInTheAlert);
        }

        public void AcceptTheAllert()
        {
            var alert = GetAlertWindow();
            alert.Accept();
            //Will wait until alert dissapear
            _wait.Until(ExpectedConditions.AlertState(false));
        }
    }
}
