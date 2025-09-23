using NUnit.Framework;
using HerokuappUiTests.Mappings;
using System.Linq;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class TyposTests : BaseTest
    {
        [Test]
        public void Paragraph_spelling_is_correct()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/typos");

            // Берём именно текст параграфа, который начинается с "Sometimes"
            var text = Driver.FindElements(TyposPage.Paragraph)
                             .Select(p => p.Text.Trim())
                             .FirstOrDefault(t => t.StartsWith("Sometimes"));

            Assert.That(text, Is.Not.Null, "Не нашли целевой параграф на странице");

            var expected1 = "Sometimes you'll see a typo, other times you won't.";
            var expected2 = "Sometimes you’ll see a typo, other times you won’t.";

            Assert.That(text, Is.AnyOf(expected1, expected2),
                $"Ожидали корректную фразу. Фактически: \"{text}\"");
        }
    }
}
