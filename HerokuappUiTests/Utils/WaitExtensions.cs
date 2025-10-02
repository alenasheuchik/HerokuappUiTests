using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HerokuappUiTests.Utils
{
    public static class WaitExtensions
    {
        public static IWebElement WaitVisible(this WebDriverWait wait, By by)
            => wait.Until(ExpectedConditions.ElementIsVisible(by));

        public static IWebElement WaitClickable(this WebDriverWait wait, By by)
            => wait.Until(ExpectedConditions.ElementToBeClickable(by));

        public static bool WaitInvisibility(this WebDriverWait wait, By by)
            => wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
    }
}
