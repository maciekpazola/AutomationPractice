﻿using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using OpenQA.Selenium;

namespace AutomationPractice.Helpers
{
    public class StateChecker
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly Waits _waits;
        private readonly Logger _logger;

        public StateChecker(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _waits = new(_scenarioContext);
            _logger = new(_featureContext, _scenarioContext);
        }
        public static bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public int GetNumberOfElements(By by) => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElements(by).Count;

        public bool CheckIfItemIsLoaded(IWebElement clickedButton, IWebElement itemToCheck)
        {
            var wait = _waits.GetWebDriverWait();
            wait.Until(_ => clickedButton.Enabled);

            _logger.WriteInfoLog($"Clicked element enable state: {clickedButton.Enabled}");
            return CheckIfItemIsEnabled(itemToCheck);
        }

        public bool CheckIfItemIsEnabled(By locator)
        {
            try
            {
                IWebElement element = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(locator);
                var wait = _waits.GetWebDriverWait();
                wait.Until(_ => element.Enabled);

                _logger.WriteInfoLog($"Clicked element enable state: {element.Enabled}");
                return element.Enabled;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException
                    || ex is StaleElementReferenceException
                    || ex is WebDriverTimeoutException)
                {
                    _logger.WriteInfoLog($"Clicked element enable state: False\nException occurred: {ex.Message}");
                    return false;
                }
                throw;
            }
        }
        public bool CheckIfItemIsEnabled(IWebElement element)
        {
            try
            {
                var wait = _waits.GetWebDriverWait();
                wait.Until(_ => element.Enabled);

                _logger.WriteInfoLog($"Clicked element enable state: {element.Enabled}");
                return element.Enabled;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException
                    || ex is StaleElementReferenceException
                    || ex is WebDriverTimeoutException)
                {
                    _logger.WriteInfoLog($"Clicked element enable state: False\nException occurred: {ex.Message}");
                    return false;
                }
                throw;
            }
        }
    }
}
