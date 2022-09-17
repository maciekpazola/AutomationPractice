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
    public class BasicAuthPage
    {
        readonly string BasicAuthPage_url = "http://the-internet.herokuapp.com/basic_auth";
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public BasicAuthPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='example']/button")]
        private IWebElement elem_AddElementButton;

        [FindsBy(How = How.XPath, Using = "//button[@class='added-manually']")]
        private IWebElement elem_Delete;
    }
}
