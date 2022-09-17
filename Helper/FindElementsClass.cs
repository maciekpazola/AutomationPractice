using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPractice.Drivers.Driver;
using OpenQA.Selenium;

namespace AutomationPractice.Helper.FindElements
{
    public class FindElementsClass
    {
        //public IWebDriver driver = DriverClass.getInstanceOfDriver().getDriver();
        public static IWebElement FindElements(By by, string selector)
        {
            IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();

            IWebElement element = driver.FindElement(by);
            return element;
        }
    }
}
