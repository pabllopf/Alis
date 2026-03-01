using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotColormap"/> enum values.
    /// </summary>
    public class ImPlotColormapTest
    {
        /// <summary>
        /// Verifies that colormap values are defined.
        /// </summary>
        [Fact]
        public void Deep_ShouldBeDefined()
        {
            ImPlotColormap colormap = ImPlotColormap.Deep;
            Assert.Equal(0, (int)colormap);
        }

        /// <summary>
        /// Verifies that different colormaps have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotColormap deep = ImPlotColormap.Deep;
            ImPlotColormap dark = ImPlotColormap.Dark;
            ImPlotColormap pastel = ImPlotColormap.Pastel;

            Assert.NotEqual((int)deep, (int)dark);
            Assert.NotEqual((int)dark, (int)pastel);
        }
    }
}

