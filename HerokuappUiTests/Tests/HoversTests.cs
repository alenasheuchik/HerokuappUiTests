using FluentAssertions;
using HerokuappUiTests.Mappings;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class HoversTests : BaseTest
    {
        [Test]
        public void Hover_each_profile_and_open_profile_links_navigate()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/hovers");

            var figures = Driver.FindElements(HoversPage.Figures);
            figures.Count.Should().BeGreaterThanOrEqualTo(3);

            for (int i = 0; i < figures.Count; i++)
            {
                new Actions(Driver).MoveToElement(figures[i]).Perform();

                var caption = figures[i].FindElement(HoversPage.CaptionTitle);
                caption.Displayed.Should().BeTrue();
                caption.Text.Should().Match("name: user*");

                var link = figures[i].FindElement(HoversPage.ViewProfile);
                var expectedHref = link.GetAttribute("href");

                link.Click();

                Driver.Url.Should().Be(expectedHref);
                Driver.FindElement(HoversPage.Body).Text.Should().NotBeNullOrWhiteSpace();

                Driver.Navigate().Back();
            }
        }
    }
}
