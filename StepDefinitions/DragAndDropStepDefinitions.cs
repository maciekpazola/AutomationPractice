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
            throw new PendingStepException();
        }

        [Then(@"I will assert element position")]
        public void ThenIWillAssertElementPosition()
        {
            throw new PendingStepException();
        }
    }
}
