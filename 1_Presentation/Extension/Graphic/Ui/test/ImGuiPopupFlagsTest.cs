using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiPopupFlags"/> values and aliases.
    /// </summary>
    public class ImGuiPopupFlagsTest
    {
        /// <summary>
        /// Verifies that none and left mouse button alias use value zero.
        /// </summary>
        [Fact]
        public void NoneAndLeftAlias_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiPopupFlags.None);
            Assert.Equal((int) ImGuiPopupFlags.None, (int) ImGuiPopupFlags.MouseButtonLeft);
        }

        /// <summary>
        /// Verifies that any-popup alias combines id and level flags.
        /// </summary>
        [Fact]
        public void AnyPopup_ShouldMatchComposition()
        {
            ImGuiPopupFlags expected = ImGuiPopupFlags.AnyPopupId | ImGuiPopupFlags.AnyPopupLevel;

            Assert.Equal(expected, ImGuiPopupFlags.AnyPopup);
        }
    }
}

