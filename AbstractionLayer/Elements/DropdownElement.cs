﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class DropdownElement
    {
        private readonly SelectElement _dropdown;
        public DropdownElement(IWebElement dropdownElement)=> _dropdown = new SelectElement(dropdownElement);
        public int GetNumberOfElementsInDropdown() => _dropdown.Options.Count;
        public void SelectElementInDropdown(string value)
        {
            _dropdown.SelectByValue(value);

            //Assertion will check if the element is selected
            var selectedElement = _dropdown.SelectedOption;
            ExpectedConditions.ElementToBeSelected(selectedElement);
        }
        public void SelectAllElementsInDropdown()
        {
            int numberOfElements = GetNumberOfElementsInDropdown();
            for (int i = 0; i < numberOfElements; i++)
            {
                _dropdown.SelectByIndex(i);
                //Assertion will check if the element is selected
                _dropdown.SelectedOption.Selected.Should().BeTrue();
            }
        }
    }
}
