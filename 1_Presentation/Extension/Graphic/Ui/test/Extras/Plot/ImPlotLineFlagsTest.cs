using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotLineFlags"/> values.
    /// </summary>
    public class ImPlotLineFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotLineFlags.None);
        }

        /// <summary>
        /// Verifies selected flags remain distinct.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotLineFlags.Segments, (int) ImPlotLineFlags.Loop);
            Assert.NotEqual((int) ImPlotLineFlags.SkipNaN, (int) ImPlotLineFlags.NoClip);
            Assert.NotEqual((int) ImPlotLineFlags.Shaded, (int) ImPlotLineFlags.NoClip);
        }
    }
}

