using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Helper
{
    public static class Locator
    {
        public static string GetButtonLocator(string onClickValue)
        {
            return $"button[onclick='{onClickValue}()']";
        }

        public static string GetCheckboxLocator()
        {
            return "input[type='checkbox']";
        }
    }
}
