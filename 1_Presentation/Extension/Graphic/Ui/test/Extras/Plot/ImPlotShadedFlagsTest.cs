using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotShadedFlags"/>.
    /// </summary>
    public class ImPlotShadedFlagsTest
    {
        /// <summary>
        /// Verifies that shaded flags currently expose only the none value.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotShadedFlags.None);
        }
    }
}

