using AutomationPractice.DriverFolder;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class ButtonElement
    {
        public readonly IWebElement Button;

        public ButtonElement(string locator)
        {
            Button = Driver.GetInstanceOfDriver().GetDriver().FindElement(By.CssSelector(locator));
        }
        public void Click() => Button.Click();
    }
}
