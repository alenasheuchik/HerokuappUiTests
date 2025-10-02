using OpenQA.Selenium;

namespace HerokuappUiTests.Mappings
{
    public static class HoversPage
    {
        public static readonly By Figures = By.CssSelector(".figure");
        public static readonly By CaptionTitle = By.CssSelector(".figcaption h5");
        public static readonly By ViewProfile = By.LinkText("View profile");
        public static readonly By Body = By.TagName("body");
    }
}
