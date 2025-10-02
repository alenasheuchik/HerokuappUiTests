using FluentAssertions;
using HerokuappUiTests.Mappings;
using NUnit.Framework;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class CheckboxesTests : BaseTest
    {
        [Test]
        public void Toggle_both_checkboxes_and_verify_states()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/checkboxes");
            var elems = Driver.FindElements(CheckboxesPage.Checkboxes);
            elems.Count.Should().BeGreaterThanOrEqualTo(2);

            elems[0].Selected.Should().BeFalse();
            elems[0].Click();
            elems[0].Selected.Should().BeTrue();

            elems[1].Selected.Should().BeTrue();
            elems[1].Click();
            elems[1].Selected.Should().BeFalse();
        }
    }
}