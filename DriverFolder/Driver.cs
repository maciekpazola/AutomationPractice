using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationPractice.DriverFolder
{
    public class Driver
    {
        private static Driver instanceOfDriverClass;
        private readonly WebDriver _driver;

        private Driver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
        }

        public static Driver GetInstanceOfDriver()
        {
            if (instanceOfDriverClass == null)
            {
                instanceOfDriverClass = new Driver();
            }
            return instanceOfDriverClass;
        }

        public WebDriver GetDriver()
        {
            return _driver;
        }
    }
}
