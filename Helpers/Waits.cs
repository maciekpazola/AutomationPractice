﻿using AutomationPractice.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.Helpers
{
    public static class Waits
    {
        public static DefaultWait<IWebDriver> GetWebDriverWait(int timeoutInSeconds = 5)
        {
            DefaultWait<IWebDriver> wait = new(Driver.GetInstanceOfDriver().GetDriver());
            wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);

            return wait;
        }
        public static DefaultWait<IWebDriver> GetFluentWait(int timeoutInSeconds = 3, int pollingIntervalInMilliseconds = 100)
        {
            DefaultWait<IWebDriver> fluentWait = new(Driver.GetInstanceOfDriver().GetDriver());
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMilliseconds);

            return fluentWait;
        }
    }
}