using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotItemFlags"/>.
    /// </summary>
    public class ImPlotItemFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotItemFlags.None);
        }

        /// <summary>
        /// Verifies that item flags are distinct bits.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotItemFlags.NoLegend, (int) ImPlotItemFlags.NoFit);
        }
    }
}

