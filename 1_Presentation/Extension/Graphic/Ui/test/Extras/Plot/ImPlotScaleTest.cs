using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotScale"/> enum values.
    /// </summary>
    public class ImPlotScaleTest
    {
        /// <summary>
        /// Verifies that scale values are defined.
        /// </summary>
        [Fact]
        public void Linear_ShouldBeDefined()
        {
            ImPlotScale scale = ImPlotScale.Linear;
            Assert.Equal(0, (int)scale);
        }

        
        /// <summary>
        /// Verifies that different scale types have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotScale linear = ImPlotScale.Linear;
            ImPlotScale log10 = ImPlotScale.Log10;

            Assert.NotEqual((int)linear, (int)log10);
        }
    }
}

