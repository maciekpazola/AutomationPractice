using AutomationPractice.DriverFolder;
using OpenQA.Selenium;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public static class AfterHooks
    {
        [AfterTestRun]
        public static void CloseApp()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            driver.Quit();
        }
    }
}
