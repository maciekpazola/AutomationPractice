﻿using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using OpenQA.Selenium;


namespace AutomationPractice.AbstractionLayer.Elements
{
    public class ButtonElement
    {
        public readonly IWebElement Button;

        public ButtonElement(string locator) => 
            Button = Driver.GetDriver(TestScenarioContext.ScenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector(locator));

        public void Click() => Button.Click();
    }
}
