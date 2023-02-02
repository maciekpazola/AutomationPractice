using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class CheckboxElement
    {
        private readonly IWebElement _checkboxElement;
        public CheckboxElement(IWebElement checkboxElement) => _checkboxElement = checkboxElement;

        public bool GetCheckedState(IWebElement checkbox)=> Convert.ToBoolean(checkbox.GetDomProperty(Properties.Checked));

        public void AssertIfChecked(bool expectedResult)
        {
                bool isChecked = GetCheckedState(_checkboxElement);
                Assert.AreEqual(expectedResult, isChecked);
        }
    }
}
