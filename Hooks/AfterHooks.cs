using AutomationPractice.Drivers.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public static class AfterHooks
    {
        [AfterTestRun]
        public static void CloseApp()
        {
            IWebDriver driver = Driver.Driver.GetInstanceOfDriver().GetDriver();
            driver.Quit();
        }
    }
}
