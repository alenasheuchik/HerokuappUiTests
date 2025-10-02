using HerokuappUiTests.Mappings;
using HerokuappUiTests.Utils;
using NUnit.Framework;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class NotificationMessagesTests : BaseTest
    {
        [Test]
        public void Click_and_verify_notification_text()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/notification_message_rendered");
            Driver.FindElement(NotificationMessagesPage.ClickHere).Click();

            var flash = Wait.WaitVisible(NotificationMessagesPage.Flash);

            // убираем крестик и пробелы/переводы строк
            var text = flash.Text.Replace("×", "").Trim();

            Assert.That(text,
                Does.Contain("Action successful")
                    .Or.Contain("Action unsuccesful, please try again")
                    .Or.Contain("Action Unsuccessful"),
                $"Неожиданное сообщение нотификации: \"{text}\"");
        }
    }
}
