using AutomationPractice.DriverFolder;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Helper
{
    public static class ActionsBuilder
    {
        public static Actions GetInstanceOfActions()
        {
            return new Actions(Driver.GetInstanceOfDriver().GetDriver());
        }

        public static IAction RightClickOnContextMenu(IWebElement contextMenu)
        {
            return GetInstanceOfActions().MoveToElement(contextMenu).ContextClick().Build();
        }
    }
}
