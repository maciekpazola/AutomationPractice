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
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly Waits _waits;
        private readonly Logger _logger;

        public AlertElement(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _waits = new(_scenarioContext);
            _logger = new(_featureContext, _scenarioContext);
            try
            {
                Alert = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                _logger.WriteInfoLog("Can't find alert element");
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
