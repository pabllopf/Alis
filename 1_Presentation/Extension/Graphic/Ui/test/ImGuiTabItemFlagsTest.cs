using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiTabItemFlags"/> values.
    /// </summary>
    public class ImGuiTabItemFlagsTest
    {
        /// <summary>
        /// Verifies that leading and trailing tabs have distinct ordering values.
        /// </summary>
        [Fact]
        public void LeadingAndTrailing_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiTabItemFlags.Leading, (int) ImGuiTabItemFlags.Trailing);
            Assert.True((int) ImGuiTabItemFlags.Trailing > (int) ImGuiTabItemFlags.Leading);
        }
    }
}

