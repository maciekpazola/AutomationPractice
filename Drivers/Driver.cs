using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationPractice.Drivers
{
    public class Driver
    {
        private static Driver instanceOfDriverClass;
        private readonly WebDriver _driver;
        private Driver()
        {
            Uri gridUrl = new Uri("http://localhost:4444/wd/hub");
            var options = new ChromeOptions();
            options.BrowserVersion = "115.0";
            options.AddArgument("no-sandbox");


            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new RemoteWebDriver(gridUrl, options.ToCapabilities());
        }

        public static Driver GetInstanceOfDriver()
        {
            if (instanceOfDriverClass == null)
            {
                instanceOfDriverClass = new Driver();
            }
            return instanceOfDriverClass;
        }

        public WebDriver GetDriver() => _driver;
    }
}
