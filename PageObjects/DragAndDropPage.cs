using AutomationPractice.Drivers.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class DragAndDropPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private static DropdownPage instanceOfPage;

        public DragAndDropPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "dropdown")]
        private IWebElement elem_Dropdown;

        public static DropdownPage GetDropdownPage()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            if (instanceOfPage == null)
            {
                instanceOfPage = new DropdownPage(driver);
            }
            return instanceOfPage;
        }
    }
}
