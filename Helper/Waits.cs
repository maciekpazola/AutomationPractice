using AutomationPractice.Drivers.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.Helper
{
    public static class Waits
    {
        public static void FluentWait()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        }
    }
}
