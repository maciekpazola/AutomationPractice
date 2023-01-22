using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class AddRemoveElementsPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='example']/button")]
        private IWebElement elem_AddElementButton;

        [FindsBy(How = How.CssSelector, Using = "button.added-manually[onclick='deleteElement()']")]
        private IList<IWebElement> elem_Delete;

        public void ClickAddElementButton()=> elem_AddElementButton.Click();

        public void RemoveAllTheElements()
        {
            foreach (IWebElement element in elem_Delete)
                element.Click();
        }
    }
}
