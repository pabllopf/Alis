using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiTableFlags"/> values and aliases.
    /// </summary>
    public class ImGuiTableFlagsTest
    {
        /// <summary>
        /// Verifies that border aliases match their component compositions.
        /// </summary>
        [Fact]
        public void BorderAliases_ShouldMatchComposition()
        {
            Assert.Equal(ImGuiTableFlags.BordersInnerH | ImGuiTableFlags.BordersOuterH, ImGuiTableFlags.BordersH);
            Assert.Equal(ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.BordersOuterV, ImGuiTableFlags.BordersV);
            Assert.Equal(ImGuiTableFlags.BordersH | ImGuiTableFlags.BordersV, ImGuiTableFlags.Borders);
        }

        /// <summary>
        /// Verifies that sizing mask includes all sizing-related options.
        /// </summary>
        [Fact]
        public void SizingMask_ShouldContainSizingModes()
        {
            ImGuiTableFlags sizingModes = ImGuiTableFlags.SizingFixedFit
                                          | ImGuiTableFlags.SizingFixedSame
                                          | ImGuiTableFlags.SizingStretchProp
                                          | ImGuiTableFlags.SizingStretchSame;

            Assert.Equal(sizingModes, ImGuiTableFlags.SizingMask);
        }
    }
}

