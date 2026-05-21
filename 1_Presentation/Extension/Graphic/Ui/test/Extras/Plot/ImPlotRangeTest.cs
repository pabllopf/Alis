

using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot range test class
    /// </summary>
    public class ImPlotRangeTest
    {
        /// <summary>
        ///     Tests that min should be initialized
        /// </summary>
        [Fact]
        public void Min_ShouldBeInitialized()
        {
            ImPlotRange range = new ImPlotRange();
            Assert.Equal(default(double), range.Min);
        }

        /// <summary>
        ///     Tests that max should be initialized
        /// </summary>
        [Fact]
        public void Max_ShouldBeInitialized()
        {
            ImPlotRange range = new ImPlotRange();
            Assert.Equal(default(double), range.Max);
        }

        /// <summary>
        ///     Tests that min should set and get correctly
        /// </summary>
        [Fact]
        public void Min_Should_SetAndGetCorrectly()
        {
            ImPlotRange range = new ImPlotRange();
            double value = 10.0;
            range.Min = value;
            Assert.Equal(value, range.Min);
        }

        /// <summary>
        ///     Tests that max should set and get correctly
        /// </summary>
        [Fact]
        public void Max_Should_SetAndGetCorrectly()
        {
            ImPlotRange range = new ImPlotRange();
            double value = 20.0;
            range.Max = value;
            Assert.Equal(value, range.Max);
        }
    }
}