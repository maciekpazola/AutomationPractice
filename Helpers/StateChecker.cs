using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using OpenQA.Selenium;

namespace AutomationPractice.Helpers
{
    public class StateChecker
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Waits _waits;
        public StateChecker(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _waits = new(_scenarioContext);
        }
        public bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public int GetNumberOfElements(By by) => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElements(by).Count;

        public bool CheckIfItemIsLoaded(By clickedButtonLocator, By itemToCheckLocator)
        {
            IWebElement clickedButton = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(clickedButtonLocator);
            var wait = _waits.GetWebDriverWait();
            wait.Until(_ => clickedButton.Enabled);

            Logger.WriteInfoLog($"Clicked element enable state: {clickedButton.Enabled}");
            return CheckIfItemIsEnabled(itemToCheckLocator);
        }
        public bool CheckIfItemIsLoaded(IWebElement clickedButton, IWebElement itemToCheck)
        {
            var wait = _waits.GetWebDriverWait();
            wait.Until(_ => clickedButton.Enabled);

            Logger.WriteInfoLog($"Clicked element enable state: {clickedButton.Enabled}");
            return CheckIfItemIsEnabled(itemToCheck);
        }

        public bool CheckIfItemIsEnabled(By locator)
        {
            try
            {
                IWebElement element = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(locator);
                var wait = _waits.GetWebDriverWait();
                wait.Until(_ => element.Enabled);

                Logger.WriteInfoLog($"Clicked element enable state: {element.Enabled}");
                return element.Enabled;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException
                    || ex is StaleElementReferenceException
                    || ex is WebDriverTimeoutException)
                {
                    Logger.WriteInfoLog($"Clicked element enable state: False\nException occurred: {ex.Message}");
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

                Logger.WriteInfoLog($"Clicked element enable state: {element.Enabled}");
                return element.Enabled;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException
                    || ex is StaleElementReferenceException
                    || ex is WebDriverTimeoutException)
                {
                    Logger.WriteInfoLog($"Clicked element enable state: False\nException occurred: {ex.Message}");
                    return false;
                }
                throw;
            }
        }
    }
}
