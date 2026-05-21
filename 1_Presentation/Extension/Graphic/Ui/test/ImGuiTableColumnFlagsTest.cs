

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui table column flags test class
    /// </summary>
    public class ImGuiTableColumnFlagsTest
    {
        /// <summary>
        ///     Tests that is visible should be initialized correctly
        /// </summary>
        [Fact]
        public void IsVisible_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IsVisible;

            Assert.Equal(33554432, (int) flag);
        }

        /// <summary>
        ///     Tests that is sorted should be initialized correctly
        /// </summary>
        [Fact]
        public void IsSorted_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IsSorted;

            Assert.Equal(67108864, (int) flag);
        }

        /// <summary>
        ///     Tests that is hovered should be initialized correctly
        /// </summary>
        [Fact]
        public void IsHovered_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IsHovered;

            Assert.Equal(134217728, (int) flag);
        }

        /// <summary>
        ///     Tests that width mask should be initialized correctly
        /// </summary>
        [Fact]
        public void WidthMask_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.WidthMask;

            Assert.Equal(24, (int) flag);
        }

        /// <summary>
        ///     Tests that indent mask should be initialized correctly
        /// </summary>
        [Fact]
        public void IndentMask_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.IndentMask;

            Assert.Equal(196608, (int) flag);
        }

        /// <summary>
        ///     Tests that status mask should be initialized correctly
        /// </summary>
        [Fact]
        public void StatusMask_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.StatusMask;

            Assert.Equal(251658240, (int) flag);
        }

        /// <summary>
        ///     Tests that no direct resize should be initialized correctly
        /// </summary>
        [Fact]
        public void NoDirectResize_ShouldBeInitializedCorrectly()
        {
            ImGuiTableColumnFlags flag = ImGuiTableColumnFlags.NoDirectResize;

            Assert.Equal(1073741824, (int) flag);
        }
    }
}