using OpenQA.Selenium;

namespace HerokuappUiTests.Mappings
{
    public static class SortableDataTablesPage
    {
        // (//table)[N] -> tbody -> tr[row] -> td[col]
        public static By Cell(int tableIndex, int rowIndex, int colIndex)
            => By.XPath($"(//table)[{tableIndex}]//tbody//tr[{rowIndex}]//td[{colIndex}]");
    }
}
