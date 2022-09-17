using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPractice.Drivers.Driver;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class BeforeHooks
    {
        [BeforeFeature]
        public static void Setup()
        {
            IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
            HomePage page = new HomePage(driver);
            page.GoToHomePage();
        }
    }
}
