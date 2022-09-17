using AutomationPractice.Drivers.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class BasePage
    {
        IWebDriver driver;

        public void GoToPage(string test_url)
        {
            driver.Navigate().GoToUrl(test_url);
        }
    }
}
