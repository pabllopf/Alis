

using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot point test class
    /// </summary>
    public class ImPlotPointTest
    {
        /// <summary>
        ///     Tests that x should be initialized
        /// </summary>
        [Fact]
        public void X_ShouldBeInitialized()
        {
            ImPlotPoint point = new ImPlotPoint();
            Assert.Equal(default(double), point.X);
        }

        /// <summary>
        ///     Tests that y should be initialized
        /// </summary>
        [Fact]
        public void Y_ShouldBeInitialized()
        {
            ImPlotPoint point = new ImPlotPoint();
            Assert.Equal(default(double), point.Y);
        }

        /// <summary>
        ///     Tests that x should set and get correctly
        /// </summary>
        [Fact]
        public void X_Should_SetAndGetCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint();
            double value = 10.0;
            point.X = value;
            Assert.Equal(value, point.X);
        }

        /// <summary>
        ///     Tests that y should set and get correctly
        /// </summary>
        [Fact]
        public void Y_Should_SetAndGetCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint();
            double value = 20.0;
            point.Y = value;
            Assert.Equal(value, point.Y);
        }
    }
}