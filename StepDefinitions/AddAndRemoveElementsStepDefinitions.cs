using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;
using AutomationPractice.Drivers.Driver;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class AddAndRemoveElementsStepDefinitions
    {
        readonly IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
        [When(@"I will go to '([^']*)' section")]
        public void WhenIWillGoToSection(string sectionName)
        {
            HomePage page = new(driver);
            page.OpenPage(sectionName);
        }

        [When(@"I will add element")]
        public void WhenIWillAddElement()
        {
            AddRemoveElementsPage page = new(driver);
            page.ClickAddElementButton();
        }

        [When(@"I will remove all the elements")]
        public void WhenIWillRemoveAllTheElements()
        {
            AddRemoveElementsPage page = new(driver);
                while (true)
            {
                bool isDeleteButtonEnabled = page.CheckDeleteElement();
                if (isDeleteButtonEnabled == true)
                {
                    page.DeleteElement();
                }
                if (isDeleteButtonEnabled == false)
                {
                    return;
                }
            }
        }
    }
}
