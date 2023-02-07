using OpenQA.Selenium;

namespace AutomationPractice.Helper
{
    public static class StateCheck
    {
        public static bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public static bool CheckIfItemIsLoaded(IWebElement clickedButton, IWebElement itemToCheck)
        {
            var wait = Waits.GetWebDriverWait();
            wait.Until(driver => clickedButton.Enabled);
            return CheckIfItemIsEnabled(itemToCheck);
        }

        public static bool CheckIfItemIsEnabled(IWebElement element)
        {
            {
                try
                {
                    return element.Enabled;
                }
                catch (NoSuchElementException ex)
                {
                    return false;
                }
            }
        }
    }
}
