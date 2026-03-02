using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiSelectableFlags"/> values.
    /// </summary>
    public class ImGuiSelectableFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiSelectableFlags.None);
        }

        /// <summary>
        /// Verifies that selectable flags are distinct values.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiSelectableFlags.DontClosePopups, (int) ImGuiSelectableFlags.SpanAllColumns);
            Assert.NotEqual((int) ImGuiSelectableFlags.AllowDoubleClick, (int) ImGuiSelectableFlags.Disabled);
        }
    }
}

