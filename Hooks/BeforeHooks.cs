using AutomationPractice.Drivers;
using AutomationPractice.PageObjects;
using AutomationPractice.Helpers;
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
            Logger.ClearLogFile();
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Logger.WriteToLog(string.Empty);
            Logger.WriteToLog($"{ScenarioContext.Current.ScenarioInfo.Title}:");

            Page.Home.GoToHomePage();
        }
    }
}
