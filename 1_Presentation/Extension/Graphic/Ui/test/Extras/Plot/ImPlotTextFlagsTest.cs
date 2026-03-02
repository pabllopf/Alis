using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotTextFlags"/>.
    /// </summary>
    public class ImPlotTextFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotTextFlags.None);
        }

        /// <summary>
        /// Verifies that vertical mode uses a non-zero value.
        /// </summary>
        [Fact]
        public void Vertical_ShouldBeNonZero()
        {
            Assert.True((int) ImPlotTextFlags.Vertical > 0);
        }
    }
}

