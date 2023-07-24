using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class DynamicControlsPage
    {
        private readonly ButtonElement _removeOrAddButton = new(Locator.GetButtonLocator("swapCheckbox"));

        private readonly ButtonElement _enableOrDisableButton = new(Locator.GetButtonLocator("swapInput"));
        private CheckboxElement Checkbox() => new CheckboxElement(Locator.GetCheckboxLocator());


        [FindsBy(How = How.CssSelector, Using = "input[type='text']")]
        private readonly IWebElement _formField;


        public void RemoveCheckbox()=> _removeOrAddButton.Click();

        public void AssertIfCheckboxIsPresent(bool expectedResult)
        {
            bool state;
            if (!expectedResult)
            {
                try
                {
                    state = StateChecker.CheckIfItemIsLoaded(_removeOrAddButton.Button, Checkbox().Checkbox);
                }
                catch (Exception ex)
                {
                    if (ex is WebDriverTimeoutException || ex is NullReferenceException)
                        state = false;
                    else throw new Exception("Unexpected exception occured");
                }
                Assert.AreEqual(expectedResult, state);
            }
            if(expectedResult)
            {
                var wait = Waits.GetFluentWait(timeoutInSeconds:5);
                wait.Until(driver => Checkbox().Checkbox);
                state = StateChecker.CheckIfItemIsLoaded(_removeOrAddButton.Button, Checkbox().Checkbox);
                Assert.AreEqual(expectedResult, state);
            }
        }

        public void AddCheckbox() => _removeOrAddButton.Click();

        public void ClickEnable() => _enableOrDisableButton.Click();

        public void AssertIfFormIsEnable(bool expectedResult) => Assert.AreEqual(expectedResult, StateChecker.CheckIfItemIsLoaded(_enableOrDisableButton.Button, _formField));

        public void FillInFormField(string text) => _formField.SendKeys(text);

        public void ClickDisable() => _enableOrDisableButton.Click();
    }
}