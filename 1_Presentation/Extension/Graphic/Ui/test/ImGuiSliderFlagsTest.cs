using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiSliderFlags"/> values.
    /// </summary>
    public class ImGuiSliderFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiSliderFlags.None);
        }

        /// <summary>
        /// Verifies that invalid mask keeps a large non-zero reserved value.
        /// </summary>
        [Fact]
        public void InvalidMask_ShouldBeLargeNonZeroValue()
        {
            Assert.True((int) ImGuiSliderFlags.InvalidMask > 1000000);
        }
    }
}

