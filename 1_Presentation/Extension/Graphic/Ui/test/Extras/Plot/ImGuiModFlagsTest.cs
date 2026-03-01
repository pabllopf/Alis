using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for plot-specific <see cref="ImGuiModFlags"/> values.
    /// </summary>
    public class ImGuiModFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiModFlags.None);
        }

        /// <summary>
        /// Verifies that modifier values are distinct bit flags.
        /// </summary>
        [Fact]
        public void Modifiers_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiModFlags.Ctrl, (int) ImGuiModFlags.Shift);
            Assert.NotEqual((int) ImGuiModFlags.Alt, (int) ImGuiModFlags.Super);
        }

        /// <summary>
        /// Verifies that combining modifiers with OR preserves both bits.
        /// </summary>
        [Fact]
        public void CombinedModifiers_ShouldContainBothBits()
        {
            ImGuiModFlags combo = ImGuiModFlags.Ctrl | ImGuiModFlags.Shift;

            Assert.True((combo & ImGuiModFlags.Ctrl) != 0);
            Assert.True((combo & ImGuiModFlags.Shift) != 0);
        }
    }
}

