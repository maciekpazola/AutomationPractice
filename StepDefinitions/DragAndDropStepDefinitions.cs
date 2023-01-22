using AutomationPractice.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DragAndDropStepDefinitions
    {
        [When(@"I will drag and drop element A to element B")]
        public void WhenIWillDragAndDropElementAToElementB()
        {
            Page.DragAndDrop.DragAndDropElementAtoElementB();
        }

        [Then(@"I will assert element position")]
        public void ThenIWillAssertElementPosition()
        {
            Page.DragAndDrop.AssertPositionOfElements();
        }
    }
}
