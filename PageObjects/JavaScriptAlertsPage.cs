﻿using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;

namespace AutomationPractice.PageObjects
{
    public class JavaScriptAlertsPage
    {
        private readonly ScenarioContext _scenarioContext;
        public JavaScriptAlertsPage(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        private ButtonElement JavaScriptButton(string onClickValue) => new(_scenarioContext, Locator.GetButtonLocator(onClickValue));
        private AlertElement Alert() => new(_scenarioContext);

        public void ClickJavaScriptButton(string onClickValue) => JavaScriptButton(onClickValue).Click();

        public void TypeMessageToPrompt(string textMessage) => Alert().Alert.SendKeys(textMessage);

    }
}
