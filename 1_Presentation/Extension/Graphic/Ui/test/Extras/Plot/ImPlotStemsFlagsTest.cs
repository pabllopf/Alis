using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotStemsFlags"/>.
    /// </summary>
    public class ImPlotStemsFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotStemsFlags.None);
        }

        /// <summary>
        /// Verifies that horizontal mode uses a non-zero value.
        /// </summary>
        [Fact]
        public void Horizontal_ShouldBeNonZero()
        {
            Assert.True((int) ImPlotStemsFlags.Horizontal > 0);
        }
    }
}

