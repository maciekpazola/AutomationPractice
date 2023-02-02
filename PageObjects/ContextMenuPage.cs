using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
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
            return _driver.SwitchTo().Alert();
        }

        public void RightClickOnContextMenu()=> ActionsBuilder.RightClickOnContextMenu(contextMenu).Perform();

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
