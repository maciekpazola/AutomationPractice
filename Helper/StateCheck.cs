using AutomationPractice.DriverFolder;
using OpenQA.Selenium;

namespace AutomationPractice.Helper
{
    public static class StateCheck
    {
        public static bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public static int GetNumberOfElements(By by) => Driver.GetInstanceOfDriver().GetDriver().FindElements(by).Count;

        public static bool CheckIfItemIsLoaded(IWebElement clickedButton, IWebElement itemToCheck)
        {
            var wait = Waits.GetWebDriverWait();
            wait.Until(driver => clickedButton.Enabled);
            logger.Logger.WriteInfoLog("Clicked element enable state: " + clickedButton.Enabled);
            return CheckIfItemIsEnabled(itemToCheck);
        }

        public static bool CheckIfItemIsEnabled(IWebElement element)
        {
            try
            {
                var wait = Waits.GetWebDriverWait();
                wait.Until(driver => element.Enabled);
                logger.Logger.WriteInfoLog("Clicked element enable state: " + element.Enabled);
                return element.Enabled;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is StaleElementReferenceException ||
                    ex is WebDriverTimeoutException)
                {
                    logger.Logger.WriteInfoLog("Clicked element enable state: False" +"\n" + 
                        "Exception occurred: " + ex.Message);
                    return false;
                }
                throw;
            }
        }
    }
}
