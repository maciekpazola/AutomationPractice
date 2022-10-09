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
        private readonly string contextMenu_url = "http://the-internet.herokuapp.com/context_menu";
        private readonly string expectedTextInTheAlert = "You selected a context menu";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private static ContextMenuPage instanceOfPage;


        public ContextMenuPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "hot-spot")]
        private IWebElement elem_ContextMenu;

        public static ContextMenuPage GetContextMenuPage()
        {
            IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
            if (instanceOfPage == null)
            {
                instanceOfPage = new ContextMenuPage(driver);
            }
            return instanceOfPage;
        }

        public void RightClickOnContextMenu()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(elem_ContextMenu).ContextClick().Perform();
        }

        public IAlert GetAlertWindow()
        {
            var alert_win = driver.SwitchTo().Alert();
            return alert_win;
        }
        public void AssertTextInTheAlert()
        {
            var alert = GetAlertWindow();
            string textInTheAlert = alert.Text;
            Assert.AreEqual(expectedTextInTheAlert, textInTheAlert);
        }
        public void AcceptTheAllert()
        {
            var alert = GetAlertWindow();
            alert.Accept();
            //Will wait until alert dissapear
            wait.Until(ExpectedConditions.AlertState(false));
        }
    }
}
