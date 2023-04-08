using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class AlertElement
    {
        public readonly IAlert Alert;
        public AlertElement()
        {
            try
            {
                Alert = Driver.GetInstanceOfDriver().GetDriver().SwitchTo().Alert();
            }
            catch (NoAlertPresentException ex)
            {
                logger.Logger.WriteInfoLog("Can't find alert element");
            }
        }

        public void AssertTextInTheAlert(string expectedText)
        {
            string textInTheAlert = Alert.Text;
            Assert.AreEqual(expectedText, textInTheAlert);
        }

        public void CheckIfAlertDissapeared()
        {
            try
            {
                Waits.GetWebDriverWait().Until(ExpectedConditions.AlertState(false));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("Alert doesn't dissapear!");
            }
        }
    }
}
