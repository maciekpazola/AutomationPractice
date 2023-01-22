using AutomationPractice.DriverFolder;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.Helper
{
    public static class Waits
    {
        public static DefaultWait<IWebDriver> GetWebDriverWait()
        {
            return new DefaultWait<IWebDriver>(Driver.GetInstanceOfDriver().GetDriver());
        }
    }
}
