using AutomationPractice.Drivers;
using OpenQA.Selenium;

namespace AutomationPractice.Helpers
{
    public static class StateChecker
    {
        public static bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public static int GetNumberOfElements(By by) => Driver.GetInstanceOfDriver().GetDriver().FindElements(by).Count;

        public static bool CheckIfItemIsLoaded(IWebElement clickedButton, IWebElement itemToCheck)
        {
            var wait = Waits.GetWebDriverWait();
            wait.Until(_ => clickedButton.Enabled);

            Logger.WriteInfoLog($"Clicked element enable state: {clickedButton.Enabled}");
            return CheckIfItemIsEnabled(itemToCheck);
        }

        public static bool CheckIfItemIsEnabled(IWebElement element)
        {
            try
            {
                var wait = Waits.GetWebDriverWait();
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
