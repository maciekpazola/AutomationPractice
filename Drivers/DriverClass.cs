using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationPractice.Drivers.Driver
{
    public class DriverClass
    {
        private static DriverClass instanceOfDriverClass = null;

        private readonly WebDriver driver;

        private DriverClass()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public static DriverClass GetInstanceOfDriver()
        {
            if (instanceOfDriverClass == null)
            {
                instanceOfDriverClass = new DriverClass();
            }
            return instanceOfDriverClass;
        }
        public WebDriver GetDriver()
        {
            return driver;
        }
    }
}
