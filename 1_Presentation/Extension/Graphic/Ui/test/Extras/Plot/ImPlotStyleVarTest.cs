using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotStyleVar"/> ordinal values.
    /// </summary>
    public class ImPlotStyleVarTest
    {
        /// <summary>
        /// Verifies first and last sentinel values remain stable.
        /// </summary>
        [Fact]
        public void Boundaries_ShouldMatchExpectedOrdinals()
        {
            Assert.Equal(0, (int) ImPlotStyleVar.LineWeight);
            Assert.Equal(27, (int) ImPlotStyleVar.Count);
        }

        /// <summary>
        /// Verifies selected style variables stay in ascending order.
        /// </summary>
        [Fact]
        public void RepresentativeValues_ShouldBeAscending()
        {
            Assert.True((int) ImPlotStyleVar.Marker > (int) ImPlotStyleVar.LineWeight);
            Assert.True((int) ImPlotStyleVar.PlotPadding > (int) ImPlotStyleVar.MinorGridSize);
            Assert.True((int) ImPlotStyleVar.PlotMinSize > (int) ImPlotStyleVar.PlotDefaultSize);
        }
    }
}

