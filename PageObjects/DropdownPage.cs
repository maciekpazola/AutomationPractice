using AutomationPractice.AbstractionLayer.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class DropdownPage
    {
        [FindsBy(How = How.Id, Using = "dropdown")]
        private IWebElement elem_Dropdown;

        public void SelectAllElementsInDropdown()
        {
            DropdownElement dropdown = new DropdownElement(elem_Dropdown);
            dropdown.SelectAllElementsInDropdown();
        }

        public void AssertNumberOfElementsInDropdown(int numberOfOptions)
        {
            DropdownElement dropdown = new DropdownElement(elem_Dropdown);
            dropdown.GetNumberOfElementsInDropdown().Should().Be(numberOfOptions);
        }

    }
}
