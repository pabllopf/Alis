

using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot rect test class
    /// </summary>
    public class ImPlotRectTest
    {
        /// <summary>
        ///     Tests that x should be initialized
        /// </summary>
        [Fact]
        public void X_ShouldBeInitialized()
        {
            ImPlotRect rect = new ImPlotRect();
            Assert.Equal(default(ImPlotRange), rect.X);
        }

        /// <summary>
        ///     Tests that y should be initialized
        /// </summary>
        [Fact]
        public void Y_ShouldBeInitialized()
        {
            ImPlotRect rect = new ImPlotRect();
            Assert.Equal(default(ImPlotRange), rect.Y);
        }

        /// <summary>
        ///     Tests that x should set and get correctly
        /// </summary>
        [Fact]
        public void X_Should_SetAndGetCorrectly()
        {
            ImPlotRect rect = new ImPlotRect();
            ImPlotRange range = new ImPlotRange();
            rect.X = range;
            Assert.Equal(range, rect.X);
        }

        /// <summary>
        ///     Tests that y should set and get correctly
        /// </summary>
        [Fact]
        public void Y_Should_SetAndGetCorrectly()
        {
            ImPlotRect rect = new ImPlotRect();
            ImPlotRange range = new ImPlotRange();
            rect.Y = range;
            Assert.Equal(range, rect.Y);
        }
    }
}