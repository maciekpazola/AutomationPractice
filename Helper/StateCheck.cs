using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Helper
{
    public static class StateCheck
    {
        public static bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public static bool CheckIfYouAreLoggedInByMessage(IWebElement element)
        {
            try
            {
                bool messageInnerText = GetPropertyState(element, Properties.InnerText);
                return messageInnerText != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

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
