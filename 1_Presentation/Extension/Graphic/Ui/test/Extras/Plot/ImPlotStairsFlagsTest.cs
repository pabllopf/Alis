using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotStairsFlags"/>.
    /// </summary>
    public class ImPlotStairsFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotStairsFlags.None);
        }

        /// <summary>
        /// Verifies that stairs modes use distinct values.
        /// </summary>
        [Fact]
        public void Modes_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotStairsFlags.PreStep, (int) ImPlotStairsFlags.Shaded);
        }
    }
}

