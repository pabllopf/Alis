

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui table column sort specs test class
    /// </summary>
    public class ImGuiTableColumnSortSpecsTest
    {
        /// <summary>
        ///     Tests that column user id should be initialized
        /// </summary>
        [Fact]
        public void ColumnUserId_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal(0u, specs.ColumnUserId);
        }

        /// <summary>
        ///     Tests that column index should be initialized
        /// </summary>
        [Fact]
        public void ColumnIndex_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal((short) 0, specs.ColumnIndex);
        }

        /// <summary>
        ///     Tests that sort order should be initialized
        /// </summary>
        [Fact]
        public void SortOrder_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal((short) 0, specs.SortOrder);
        }

        /// <summary>
        ///     Tests that sort direction should be initialized
        /// </summary>
        [Fact]
        public void SortDirection_ShouldBeInitialized()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            Assert.Equal(default(ImGuiSortDirection), specs.SortDirection);
        }

        /// <summary>
        ///     Tests that column user id should set and get correctly
        /// </summary>
        [Fact]
        public void ColumnUserId_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.ColumnUserId = 123u;
            Assert.Equal(123u, specs.ColumnUserId);
        }

        /// <summary>
        ///     Tests that column index should set and get correctly
        /// </summary>
        [Fact]
        public void ColumnIndex_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.ColumnIndex = 1;
            Assert.Equal((short) 1, specs.ColumnIndex);
        }

        /// <summary>
        ///     Tests that sort order should set and get correctly
        /// </summary>
        [Fact]
        public void SortOrder_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.SortOrder = 2;
            Assert.Equal((short) 2, specs.SortOrder);
        }

        /// <summary>
        ///     Tests that sort direction should set and get correctly
        /// </summary>
        [Fact]
        public void SortDirection_Should_SetAndGetCorrectly()
        {
            ImGuiTableColumnSortSpecs specs = new ImGuiTableColumnSortSpecs();
            specs.SortDirection = ImGuiSortDirection.Ascending;
            Assert.Equal(ImGuiSortDirection.Ascending, specs.SortDirection);
        }
    }
}