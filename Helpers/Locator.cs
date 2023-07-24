namespace AutomationPractice.Helpers
{
    public static class Locator
    {
        public static string GetButtonLocator(string onClickValue) => $"Button[onclick='{onClickValue}()']";

        public static string GetCheckboxLocator() => "Input[type='checkbox']";
    }
}
