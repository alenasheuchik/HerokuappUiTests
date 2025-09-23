using FluentAssertions;
using HerokuappUiTests.Mappings;
using HerokuappUiTests.Utils;
using NUnit.Framework;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class AddRemoveElementsTests : BaseTest
    {
        [Test]
        public void Add_two_then_delete_one_and_verify_count()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/add_remove_elements/");
            Wait.WaitClickable(AddRemoveElementsPage.AddButton).Click();
            Wait.WaitClickable(AddRemoveElementsPage.AddButton).Click();

            Wait.WaitClickable(AddRemoveElementsPage.DeleteButton).Click();

            Driver.FindElements(AddRemoveElementsPage.DeleteButton).Count
                .Should().Be(1, "после удаления одного элемента должна остаться одна кнопка Delete");
        }
    }
}



