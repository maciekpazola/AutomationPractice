using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.AbstractionLayer.Components
{
    public class DropdownElement
    {
        private SelectElement dropdown;
         public DropdownElement(IWebElement dropdownElement)
        {
            dropdown = new SelectElement(dropdownElement);
        }
        public void SelectElementInDropdown(string value)
        {
            dropdown.SelectByValue(value);

            //Assertion will check if the element is selected
            var selectedElement = dropdown.SelectedOption;
            ExpectedConditions.ElementToBeSelected(selectedElement);
        }
        public void SelectAllElementsInDropdown()
        {
            int numberOfElements = dropdown.Options.Count;
            for (int i = 0; i < numberOfElements; i++)
            {
                dropdown.SelectByIndex(i);
                //Assertion will check if the element is selected
                dropdown.SelectedOption.Selected.Should().BeTrue();
            }
        }
        public int GetNumberOfElementsInDropdown()
        {
            return dropdown.Options.Count;
        }
    }
}
