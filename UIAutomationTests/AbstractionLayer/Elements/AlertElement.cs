using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestUtilities.Logs;
using UIAutomationTests.Drivers;
using UIAutomationTests.Helpers;


namespace UIAutomationTests.AbstractionLayer.Elements
{
    public class AlertElement
    {
        private readonly IAlert Alert;
        private readonly Waits _waits;
        private readonly Logger _logger;

        public AlertElement(ScenarioContext scenarioContext)
        {
            _waits = new(scenarioContext);
            _logger = new(scenarioContext.ScenarioInfo.Title);

            try
            {
                Alert = Driver.GetDriver(scenarioContext).SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                _logger.WriteInfoLog("Can't find alert element");
            }
        }

        public void Accept() => Alert.Accept();

        public void SendKeys(string value) => Alert.SendKeys(value);

        public void AssertTextInTheAlert(string expectedText) => Assert.That(Alert.Text, Is.EqualTo(expectedText));

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
