using System;
using AutomationPractice.DriverFolder;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            var page = new T();
            PageFactory.InitElements(driver, page);
            WebDriverWait _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            return page;
        }

        public static HomePage Home
        {
            get { return GetPage<HomePage>(); }
        }
        public static DropdownPage Dropdown
        {
            get { return GetPage<DropdownPage>(); }
        }

        public static ContextMenuPage ContextMenu
        {
            get { return GetPage<ContextMenuPage>(); }
        }
        public static BasicAuthPage BasicAuth
        {
            get { return GetPage<BasicAuthPage>(); }
        }
        public static AddRemoveElementsPage AddRemoveElements
        {
            get { return GetPage<AddRemoveElementsPage>(); }
        }
        public static CheckboxesPage Checkboxes
        {
            get { return GetPage<CheckboxesPage>(); }
        }
        public static DynamicControlsPage DynamicControls
        {
            get { return GetPage<DynamicControlsPage>(); }
        }
        public static FormAuthenticationPage FormAuthentication
        {
            get { return GetPage<FormAuthenticationPage>(); }
        }
        public static JavaScriptAlertsPage JavaScriptAlerts
        {
            get { return GetPage<JavaScriptAlertsPage>(); }
        }
    }
}
