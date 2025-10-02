using FluentAssertions;
using HerokuappUiTests.Mappings;
using NUnit.Framework;

namespace HerokuappUiTests.Tests
{
    [TestFixture]
    public class SortableDataTablesTests : BaseTest
    {
        [Test]
        public void Verify_several_cells_by_xpath()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/tables");

            // Таблица #1
            Driver.FindElement(SortableDataTablesPage.Cell(1, 1, 1)).Text.Should().NotBeNullOrWhiteSpace(); 
            Driver.FindElement(SortableDataTablesPage.Cell(1, 1, 3)).Text.Should().Contain("@");            
            Driver.FindElement(SortableDataTablesPage.Cell(1, 2, 3)).Text.Should().Contain("@");           
            // Таблица #2
            Driver.FindElement(SortableDataTablesPage.Cell(2, 3, 4)).Text.Should().MatchRegex(@"^\$\d+(\.\d{2})?$");
            Driver.FindElement(SortableDataTablesPage.Cell(2, 4, 1)).Text.Should().NotBeNullOrWhiteSpace();
        }
    }
}
