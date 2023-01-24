using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace AutomationPractice.PageObjects
{
    public class ContextMenuPage
    {
        private readonly string _expectedTextInTheAlert = "You selected a context menu";
        private readonly IWebDriver _driver = Driver.GetInstanceOfDriver().GetDriver();
        [FindsBy(How = How.Id, Using = "hot-spot")]
        private IWebElement contextMenu;

        private IAlert GetAlertWindow()
        {
            IAlert alert_win = _driver.SwitchTo().Alert();
            return alert_win;
        }

        public void RightClickOnContextMenu()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(contextMenu).ContextClick().Perform();
        }

        public void AssertTextInTheAlert()
        {
            IAlert alert = GetAlertWindow();
            string textInTheAlert = alert.Text;
            Assert.AreEqual(_expectedTextInTheAlert, textInTheAlert);
        }

        public void AcceptTheAllert()
        {
            IAlert alert = GetAlertWindow();
            alert.Accept();
            //Will wait until alert dissapear
            Waits.GetWebDriverWait().Until(ExpectedConditions.AlertState(false));
        }
    }
}
