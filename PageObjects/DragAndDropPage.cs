using AutomationPractice.DriverFolder;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects
{
    public class DragAndDropPage
    {
        private readonly IWebDriver _driver = Driver.GetInstanceOfDriver().GetDriver();
        private readonly WebDriverWait _wait = new WebDriverWait(Driver.GetInstanceOfDriver().GetDriver(), TimeSpan.FromSeconds(10));

        [FindsBy(How = How.Id, Using = "column-a")]
        private IWebElement element_A;

        [FindsBy(How = How.Id, Using = "column-b")]
        private IWebElement element_B;


        public void DragAndDropElementAtoElementB()
        {
            var destinationCenterX = element_A.Location.X + element_A.Size.Width / 2;
            var destinationCenterY = element_A.Location.Y + element_A.Size.Height / 2;
            var action = new Actions(Driver.GetInstanceOfDriver().GetDriver()); action.MoveToElement(element_B).Build().Perform();
            action.ClickAndHold(element_B).MoveByOffset(10, 10).MoveByOffset(destinationCenterX, destinationCenterY).Build().Perform();
            element_A.Click(); action.Release().Perform();


            //Actions action = new Actions(_driver);
            //var locationA = element_A.Location;
            //var locationB = element_B.Location;
            //action.ClickAndHold(element_A).MoveToElement(element_B).Release().Build().Perform();
        }

        public void AssertPositionOfElements()
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(element_A, "B"));
        }
    }
}
