using AutomationPractice.AbstractionLayer.Elements;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class DropdownPage
    {
        private DropdownElement Dropdown() => new DropdownElement("#dropdown");

        public void SelectAllElementsInDropdown() => Dropdown().SelectAllElementsInDropdown();

        public void AssertNumberOfElementsInDropdown(int numberOfOptions) => Dropdown().GetNumberOfElementsInDropdown()
                                                                                          .Should().Be(numberOfOptions);
    }
}
