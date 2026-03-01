using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotLegendFlags"/> values.
    /// </summary>
    public class ImPlotLegendFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotLegendFlags.None);
        }

        /// <summary>
        /// Verifies that representative legend flags are distinct bit values.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotLegendFlags.NoButtons, (int) ImPlotLegendFlags.Outside);
            Assert.NotEqual((int) ImPlotLegendFlags.NoMenus, (int) ImPlotLegendFlags.Horizontal);
            Assert.NotEqual((int) ImPlotLegendFlags.Sort, (int) ImPlotLegendFlags.NoHighlightAxis);
        }
    }
}

