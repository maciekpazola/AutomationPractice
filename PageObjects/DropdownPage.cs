using AutomationPractice.AbstractionLayer.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class DropdownPage
    {
        [FindsBy(How = How.Id, Using = "dropdown")]
        private IWebElement dropdown;

        public void SelectAllElementsInDropdown()
        {
            DropdownElement dropdownElement = new DropdownElement(dropdown);
            dropdownElement.SelectAllElementsInDropdown();
        }

        public void AssertNumberOfElementsInDropdown(int numberOfOptions)
        {
            DropdownElement dropdownElement = new DropdownElement(dropdown);
            dropdownElement.GetNumberOfElementsInDropdown().Should().Be(numberOfOptions);
        }

    }
}
