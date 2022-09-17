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
        IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
        [When(@"I will go to '([^']*)' section")]
        public void WhenIWillGoToSection(string sectionName)
        {
            HomePage page = new HomePage(driver);
            switch (sectionName)
            {
                case "Add/Remove Elements":
                    {
                        page.OpenAddRemoveElementsLink();
                        return;
                    }
                case "BasicAuth":
                    {
                        page.OpenBasicAuthLink();
                        return;
                    }
            }
        }

        [When(@"I will add element")]
        public void WhenIWillAddElement()
        {
            AddRemoveElementsPage page = new AddRemoveElementsPage(driver);
            page.ClickAddElementButton();
        }

        [When(@"I will remove elements")]
        public void WhenIWillRemoveElements()
        {
            AddRemoveElementsPage page = new AddRemoveElementsPage(driver);
            bool isDeleteButtonEnabled = page.CheckDeleteElement();
                while (true)
            {
                if (isDeleteButtonEnabled == true)
                {
                    page.DeleteElement();
                }
                if (isDeleteButtonEnabled == false)
                {
                    return;
                }
            }
            Thread.Sleep(2000);
        }
    }
}
