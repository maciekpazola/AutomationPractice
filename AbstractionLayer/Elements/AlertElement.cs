using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestUtilities.UITesting.Drivers;
using TestUtilities.UITesting.Helpers;
using TestUtilities.Logs;


namespace TestUtilities.UITesting.AbstractionLayer.Elements
{
    public class AlertElement
    {
        public readonly IAlert Alert;
        private readonly Waits _waits;
        private readonly Logger _logger;

        public AlertElement(ScenarioContext scenarioContext)
        {
            _waits = new(scenarioContext);
            _logger = new(scenarioContext.ScenarioInfo.Title);
            try
            {
                Alert = Driver.GetDriver(scenarioContext.Get<string>("BrowserName")).SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                _logger.WriteInfoLog("Can't find alert element");
                throw;
            }
        }

        public void AssertTextInTheAlert(string expectedText) => Assert.AreEqual(expectedText, Alert.Text);

        public void CheckIfAlertDissapeared()
        {
            try
            {
                _waits.GetWebDriverWait().Until(ExpectedConditions.AlertState(false));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Alert doesn't dissapear!");
            }
        }
    }
}
