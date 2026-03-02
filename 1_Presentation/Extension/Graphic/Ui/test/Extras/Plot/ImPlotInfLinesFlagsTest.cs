using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotInfLinesFlags"/>.
    /// </summary>
    public class ImPlotInfLinesFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotInfLinesFlags.None);
        }

        /// <summary>
        /// Verifies that horizontal mode uses a non-zero dedicated bit.
        /// </summary>
        [Fact]
        public void Horizontal_ShouldBeNonZero()
        {
            Assert.True((int) ImPlotInfLinesFlags.Horizontal > 0);
        }
    }
}

