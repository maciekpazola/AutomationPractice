using AutomationPractice.DriverFolder;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public static class BeforeHooks
    {
        [BeforeTestRun]
        public static void Setup()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [BeforeScenario]
        public static void BeforeScenario() => Page.Home.GoToHomePage();
    }
}
