using AutomationPractice.AbstractionLayer.Elements;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class DropdownPage
    {
        private readonly string BasicAuthPage_url = "http://the-internet.herokuapp.com/basic_auth";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public DropdownPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

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
            dropdown.GetNumberOfElementsInDropdown().Should().Equals(numberOfOptions);
        }
    }
}
