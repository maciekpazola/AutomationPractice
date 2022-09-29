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
    public class BeforeHooks
    {
        [BeforeTestRun]
        public static void Setup()
        {
            IObjectContainer container = new ObjectContainer();
            IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }
        [BeforeScenario]
        public static void BeforeScenario()
        {
            IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
            HomePage page = new HomePage(driver);
            page.GoToHomePage();
        }
    }
}
