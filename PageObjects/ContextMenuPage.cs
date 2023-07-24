using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class ContextMenuPage
    {
        [FindsBy(How = How.Id, Using = "hot-spot")]
        private readonly IWebElement _contextMenu;

        private readonly AlertElement _alert = new();


        public void RightClickOnContextMenu()=> ActionsBuilder.RightClickOnContextMenu(_contextMenu).Perform();

        public void AcceptTheAllert() => _alert.Alert.Accept();

        public void AssertTextInTheAlert(string textInAlert) => _alert.AssertTextInTheAlert(textInAlert);

        public void AssertIfAllertDissapeared() => _alert.CheckIfAlertDissapeared();
    }
}
