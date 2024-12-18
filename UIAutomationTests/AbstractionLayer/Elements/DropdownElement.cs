using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UIAutomationTests.Drivers;

namespace UIAutomationTests.AbstractionLayer.Elements
{
    public class DropdownElement
    {
        public readonly IWebElement Dropdown;
        private readonly ScenarioContext _scenarioContext;
        private readonly SelectElement _dropdown;

        public DropdownElement(ScenarioContext scenarioContext, string cssSelector)
        {
            _scenarioContext = scenarioContext;
            Dropdown = Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector(cssSelector));
            _dropdown = new SelectElement(Dropdown);
        }

        public int GetNumberOfElementsInDropdown() => _dropdown.Options.Count;

        public void SelectElementInDropdown(string value)
        {
            _dropdown.SelectByValue(value);
        }

        public void SelectAllElementsInDropdown()
        {
            int numberOfElements = GetNumberOfElementsInDropdown();
            for (int i = 1; i < numberOfElements; i++)
            {
                _dropdown.SelectByIndex(i);
                _dropdown.SelectedOption.Selected.Should().BeTrue();
            }
        }
    }
}
