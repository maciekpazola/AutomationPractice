using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using AutomationPractice.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace AutomationPractice.AbstractionLayer.Elements
{
    public class AlertElement
    {
        public readonly IAlert Alert;
        public AlertElement()
        {
            try
            {
                Alert = Driver.GetDriver(TestScenarioContext.ScenarioContext.Get<string>("BrowserName")).SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                Logger.WriteInfoLog("Can't find alert element");
            }
        }

        public void AssertTextInTheAlert(string expectedText) => Assert.AreEqual(expectedText, Alert.Text);

        public void CheckIfAlertDissapeared()
        {
            try
            {
                Waits.GetWebDriverWait().Until(ExpectedConditions.AlertState(false));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Alert doesn't dissapear!");
            }
        }
    }
}
