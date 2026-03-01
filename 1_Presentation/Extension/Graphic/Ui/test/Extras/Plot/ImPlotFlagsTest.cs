using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotFlags"/> values and compositions.
    /// </summary>
    public class ImPlotFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotFlags.None);
        }

        /// <summary>
        /// Verifies that canvas-only is the expected combination of interaction-disabling flags.
        /// </summary>
        [Fact]
        public void CanvasOnly_ShouldMatchExpectedComposition()
        {
            ImPlotFlags expected = ImPlotFlags.NoTitle
                                   | ImPlotFlags.NoLegend
                                   | ImPlotFlags.NoMouseText
                                   | ImPlotFlags.NoMenus
                                   | ImPlotFlags.NoBoxSelect;

            Assert.Equal(expected, ImPlotFlags.CanvasOnly);
        }

        /// <summary>
        /// Verifies that selected standalone flags use distinct values.
        /// </summary>
        [Fact]
        public void StandaloneFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotFlags.NoFrame, (int) ImPlotFlags.Crosshairs);
            Assert.NotEqual((int) ImPlotFlags.NoInputs, (int) ImPlotFlags.Equal);
        }
    }
}
