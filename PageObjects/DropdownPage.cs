using AutomationPractice.AbstractionLayer.Elements;

namespace AutomationPractice.PageObjects
{
    public class DropdownPage
    {
        private readonly DropdownElement _dropdown = new("#dropdown");

        public void SelectAllElementsInDropdown() => _dropdown.SelectAllElementsInDropdown();

        public void AssertNumberOfElementsInDropdown(int numberOfOptions) =>
            _dropdown.GetNumberOfElementsInDropdown().Should().Be(numberOfOptions);
    }
}
