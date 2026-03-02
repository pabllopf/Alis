using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotMouseTextFlags"/>.
    /// </summary>
    public class ImPlotMouseTextFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotMouseTextFlags.None);
        }

        /// <summary>
        /// Verifies that optional mouse text flags are distinct bits.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotMouseTextFlags.NoAuxAxes, (int) ImPlotMouseTextFlags.NoFormat);
            Assert.NotEqual((int) ImPlotMouseTextFlags.NoFormat, (int) ImPlotMouseTextFlags.ShowAlways);
        }
    }
}

