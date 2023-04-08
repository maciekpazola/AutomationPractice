using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects
{
    public class DynamicControlsPage
    {
        private ButtonElement RemoveOrAddButton() => new ButtonElement(Locator.GetButtonLocator("swapCheckbox"));

        private ButtonElement EnableOrDisableButton() => new ButtonElement(Locator.GetButtonLocator("swapInput"));

        private CheckboxElement Checkbox() => new CheckboxElement(Locator.GetCheckboxLocator());


        [FindsBy(How = How.CssSelector, Using = "input[type='text']")]
        private IWebElement formField;


        public void RemoveCheckbox()=> RemoveOrAddButton().Click();

        public void AssertIfCheckboxIsPresent(bool expectedResult)
        {
            bool state;
            if (!expectedResult)
            {
                try
                {
                    state = StateCheck.CheckIfItemIsLoaded(RemoveOrAddButton().Button, Checkbox().Checkbox);
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
                state = StateCheck.CheckIfItemIsLoaded(RemoveOrAddButton().Button, Checkbox().Checkbox);
                Assert.AreEqual(expectedResult, state);
            }
        }

        public void AddCheckbox() => RemoveOrAddButton().Click();

        public void ClickEnable() => EnableOrDisableButton().Click();

        public void AssertIfFormIsEnable(bool expectedResult) => Assert.AreEqual(expectedResult, StateCheck.CheckIfItemIsLoaded(EnableOrDisableButton().Button, formField));

        public void FillInFormField(string text) => formField.SendKeys(text);

        public void ClickDisable() => EnableOrDisableButton().Click();
    }
}