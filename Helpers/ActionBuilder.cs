using AutomationPractice.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.Helpers
{
    public static class ActionsBuilder
    {
        private readonly static Actions _actions = new(Driver.GetInstanceOfDriver().GetDriver());

        public static IAction RightClickOnContextMenu(IWebElement contextMenu) =>
            _actions.MoveToElement(contextMenu).ContextClick().Build();
    }
}
