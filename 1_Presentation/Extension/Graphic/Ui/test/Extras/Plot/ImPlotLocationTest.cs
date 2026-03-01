using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotLocation"/> enum values.
    /// </summary>
    public class ImPlotLocationTest
    {
        /// <summary>
        /// Verifies that location values are defined.
        /// </summary>
        [Fact]
        public void Center_ShouldBeDefined()
        {
            ImPlotLocation location = ImPlotLocation.Center;
            Assert.Equal(0, (int)location);
        }

        /// <summary>
        /// Verifies that different locations have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotLocation center = ImPlotLocation.Center;
            ImPlotLocation north = ImPlotLocation.North;
            ImPlotLocation south = ImPlotLocation.South;

            Assert.NotEqual((int)center, (int)north);
            Assert.NotEqual((int)north, (int)south);
        }
    }
}

