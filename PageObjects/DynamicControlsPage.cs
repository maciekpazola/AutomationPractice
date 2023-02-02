using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class DynamicControlsPage
    {
        [FindsBy(How = How.CssSelector, Using = "button[onclick='swapCheckbox()']")]
        private IWebElement removeOrAddButton;

        [FindsBy(How = How.CssSelector, Using = "button[onclick='swapInput()']")]
        private IWebElement enableOrDisableButton;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement messageText;

        [FindsBy(How = How.Id, Using = "checkbox")]
        private IWebElement checkbox;

        public void RemoveCheckbox()=> removeOrAddButton.Click();

        private bool CheckIfCheckboxIsGone()
        {
            var wait = Waits.GetWebDriverWait();
            wait.Until(driver => removeOrAddButton.Enabled);
            try
            {
                checkbox.Enabled.Should().BeTrue();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void AssertIfCheckboxIsPresent(bool expectedResult)=> Assert.AreEqual(expectedResult, CheckIfCheckboxIsGone());

        public void AddCheckbox() => removeOrAddButton.Click();
    }
}
