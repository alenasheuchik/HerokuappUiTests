using OpenQA.Selenium;

namespace HerokuappUiTests.Mappings
{
    public static class AddRemoveElementsPage
    {
        public static readonly By AddButton = By.XPath("//button[text()='Add Element']");
        public static readonly By DeleteButton = By.XPath("//button[text()='Delete']");
    }
}