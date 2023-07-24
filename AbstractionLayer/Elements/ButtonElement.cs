using AutomationPractice.Drivers;
using OpenQA.Selenium;


namespace AutomationPractice.AbstractionLayer.Elements
{
    public class ButtonElement
    {
        public readonly IWebElement Button;

        public ButtonElement(string locator) => 
            Button = Driver.GetInstanceOfDriver().GetDriver().FindElement(By.CssSelector(locator));

        public void Click() => Button.Click();
    }
}
