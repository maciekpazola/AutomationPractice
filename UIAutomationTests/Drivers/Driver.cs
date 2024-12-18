using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace UIAutomationTests.Drivers
{
    public class Driver
    {
        private static readonly ThreadLocal<IWebDriver> _threadLocalDriver = new();

        public static IWebDriver GetDriver(ScenarioContext scenarioContext)
        {
            var browserName = scenarioContext.Get<string>("BrowserName");
            if (!_threadLocalDriver.IsValueCreated || _threadLocalDriver.Value == null)
            {
                dynamic options = GetBrowserOptions(browserName);
                _threadLocalDriver.Value = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
            }
            else
            {
                string? currentBrowser = GetDriverCapabilities()?.GetCapability("browserName").ToString();
                if (currentBrowser != browserName && !String.IsNullOrEmpty(currentBrowser))
                {
                    dynamic options = GetBrowserOptions(browserName);
                    _threadLocalDriver.Value = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
                }
            }
            return _threadLocalDriver.Value;
        }

        public static void Quit()
        {
            if (_threadLocalDriver.IsValueCreated && _threadLocalDriver.Value != null)
            {
                _threadLocalDriver.Value.Quit();
                _threadLocalDriver.Value.Dispose();
            }
        }

        private static ICapabilities? GetDriverCapabilities()
        {
            if (_threadLocalDriver.Value == null)
            {
                return null;
            }

            return ((RemoteWebDriver)_threadLocalDriver.Value).Capabilities;
        }
        private static dynamic GetBrowserOptions(string browserName)
        {
            switch (browserName.ToLower())
            {

                case "chrome":
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BrowserVersion = "115.0";
                        chromeOptions.AddArgument("no-sandbox");

                        return chromeOptions;
                    }

                case "firefox":
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.BrowserVersion = "116.0";
                        firefoxOptions.AddArgument("no-sandbox");

                        return firefoxOptions;
                    }

                case "msedge":
                    {
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.BrowserVersion = "115.0";
                        edgeOptions.AddArgument("no-sandbox");

                        return edgeOptions;
                    }
            }
            throw new Exception("Wrong name of browser");
        }
    }
}
