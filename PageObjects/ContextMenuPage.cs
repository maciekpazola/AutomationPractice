using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace AutomationPractice.PageObjects
{
    public class ContextMenuPage
    {
        [FindsBy(How = How.Id, Using = "hot-spot")]
        private IWebElement contextMenu;

        [FindsBy(How = How.Id, Using = "page-footer")]
        private IWebElement element;

        private AlertElement Alert() => new AlertElement();


        public void RightClickOnContextMenu()=> ActionsBuilder.RightClickOnContextMenu(contextMenu).Perform();

        public void AcceptTheAllert()
        {
            Alert().Alert.Accept();
        }

        public void AssertTextInTheAlert(string textInAlert) => Alert().AssertTextInTheAlert(textInAlert);

        public void AssertIfAllertDissapeared() => Alert().CheckIfAlertDissapeared();
    }
}
