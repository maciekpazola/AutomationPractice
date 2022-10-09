using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using AutomationPractice.PageObjects;
using AutomationPractice.Drivers.Driver;

namespace AutomationPractice.PageObjects
{
    public class AddRemoveElementsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private static AddRemoveElementsPage instanceOfPage;

        public AddRemoveElementsPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='example']/button")]
        private IWebElement elem_AddElementButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='added-manually']")]
        private IWebElement elem_Delete;

        public static AddRemoveElementsPage GetAddRemoveElementsPage()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            if (instanceOfPage == null)
            {
                instanceOfPage = new AddRemoveElementsPage(driver);
            }
            return instanceOfPage;
        }

        public void ClickAddElementButton()=> elem_AddElementButton.Click();

        public void DeleteElement() => elem_Delete.Click();

        public bool CheckDeleteElement()
        {
            try
            {
                bool state = elem_Delete.Displayed;
                return state;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
