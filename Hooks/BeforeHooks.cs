using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPractice.Drivers.Driver;
using AutomationPractice.PageObjects;
using BoDi;
using OpenQA.Selenium;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public static class BeforeHooks
    {
        [BeforeTestRun]
        public static void Setup()
        {
            IWebDriver driver = Driver.Driver.GetInstanceOfDriver().GetDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            IWebDriver driver = Driver.Driver.GetInstanceOfDriver().GetDriver();
            HomePage page = new HomePage(driver);
            page.GoToHomePage();
        }
    }
}
