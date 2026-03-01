using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiSortDirection"/> enum values.
    /// </summary>
    public class ImGuiSortDirectionTest
    {
        /// <summary>
        /// Verifies that sort direction values are defined.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            ImGuiSortDirection direction = ImGuiSortDirection.None;
            Assert.Equal(0, (int)direction);
        }

        /// <summary>
        /// Verifies that different sort directions have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiSortDirection ascending = ImGuiSortDirection.Ascending;
            ImGuiSortDirection descending = ImGuiSortDirection.Descending;

            Assert.NotEqual((int)ascending, (int)descending);
        }
    }
}

