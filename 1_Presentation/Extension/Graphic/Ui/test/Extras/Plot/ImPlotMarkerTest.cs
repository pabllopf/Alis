using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotMarker"/> enum values.
    /// </summary>
    public class ImPlotMarkerTest
    {
        /// <summary>
        /// Verifies that marker types are defined.
        /// </summary>
        [Fact]
        public void Circle_ShouldBeDefined()
        {
            ImPlotMarker marker = ImPlotMarker.Circle;
            Assert.Equal(0, (int)marker);
        }

        /// <summary>
        /// Verifies that different marker types have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotMarker circle = ImPlotMarker.Circle;
            ImPlotMarker square = ImPlotMarker.Square;
            ImPlotMarker diamond = ImPlotMarker.Diamond;

            Assert.NotEqual((int)circle, (int)square);
            Assert.NotEqual((int)square, (int)diamond);
        }
    }
}

