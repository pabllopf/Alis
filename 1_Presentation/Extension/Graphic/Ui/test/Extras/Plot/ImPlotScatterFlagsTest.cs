using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotScatterFlags"/>.
    /// </summary>
    public class ImPlotScatterFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotScatterFlags.None);
        }

        /// <summary>
        /// Verifies that no-clip mode uses a non-zero value.
        /// </summary>
        [Fact]
        public void NoClip_ShouldBeNonZero()
        {
            Assert.True((int) ImPlotScatterFlags.NoClip > 0);
        }
    }
}

