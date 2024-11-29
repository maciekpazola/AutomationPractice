using NUnit.Framework;
using OpenQA.Selenium;
using TestUtilities.UITesting.AbstractionLayer.Elements;
using TestUtilities.UITesting.Drivers;
using TestUtilities.UITesting.Helpers;

namespace AutomationPractice.PageObjects
{
    public class DynamicControlsPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly StateChecker _stateChecker;
        private readonly Waits _waits;
        public DynamicControlsPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stateChecker = new(_scenarioContext);
            _waits = new(_scenarioContext);
        }
        private ButtonElement RemoveOrAddButton() => new(_scenarioContext, Locator.GetButtonLocator("swapCheckbox"));
        private ButtonElement EnableOrDisableButton() => new(_scenarioContext, Locator.GetButtonLocator("swapInput"));
        private CheckboxElement Checkbox() => new(_scenarioContext, Locator.GetCheckboxLocator());
        private IWebElement FormField() => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector("input[type='text']"));


        public void RemoveCheckbox()=> RemoveOrAddButton().Click();

        public void AssertIfCheckboxIsPresent(bool expectedResult)
        {
            bool state;
            if (!expectedResult)
            {
                try
                {
                    state = _stateChecker.CheckIfItemIsLoaded(RemoveOrAddButton().Button, Checkbox().Checkbox);
                }
                catch (Exception ex)
                {
                    if (ex is WebDriverTimeoutException || ex is NullReferenceException)
                        state = false;
                    else throw new Exception("Unexpected exception occured");
                }
                Assert.That(state, Is.EqualTo(expectedResult));
            }
            if(expectedResult)
            {
                var wait = _waits.GetFluentWait(timeoutInSeconds:5);
                wait.Until(driver => Checkbox().Checkbox);
                state = _stateChecker.CheckIfItemIsLoaded(RemoveOrAddButton().Button, Checkbox().Checkbox);
                Assert.That(state, Is.EqualTo(expectedResult));
            }
        }

        public void AddCheckbox() => RemoveOrAddButton().Click();

        public void ClickEnable() => EnableOrDisableButton().Click();

        public void AssertIfFormIsEnable(bool expectedResult) => Assert.That(_stateChecker.CheckIfItemIsLoaded(EnableOrDisableButton().Button, FormField()), Is.EqualTo(expectedResult));

        public void FillInFormField(string text) => FormField().SendKeys(text);

        public void ClickDisable() => EnableOrDisableButton().Click();
    }
}