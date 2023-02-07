using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class DynamicControlsPage
    {
        [FindsBy(How = How.CssSelector, Using = "button[onclick='swapCheckbox()']")]
        private IWebElement removeOrAddButton;

        [FindsBy(How = How.CssSelector, Using = "button[onclick='swapInput()']")]
        private IWebElement enableOrDisableButton;

        [FindsBy(How = How.Id, Using = "checkbox")]
        private IWebElement checkbox;

        [FindsBy(How = How.CssSelector, Using = "input[type='text']")]
        private IWebElement formField;


        public void RemoveCheckbox()=> removeOrAddButton.Click();

        public void AssertIfCheckboxIsPresent(bool expectedResult)=> Assert.AreEqual(expectedResult, StateCheck.CheckIfItemIsLoaded(removeOrAddButton, checkbox));

        public void AddCheckbox() => removeOrAddButton.Click();

        public void ClickEnable() => enableOrDisableButton.Click();

        public void AssertIfFormIsEnable(bool expectedResult) => Assert.AreEqual(expectedResult, StateCheck.CheckIfItemIsLoaded(enableOrDisableButton, formField));

        public void FillInFormField(string text) => formField.SendKeys(text);

        public void ClickDisable() => enableOrDisableButton.Click();
    }
}