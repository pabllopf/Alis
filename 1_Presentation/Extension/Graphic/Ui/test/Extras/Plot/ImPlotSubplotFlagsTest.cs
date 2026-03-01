using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotSubplotFlags"/> values.
    /// </summary>
    public class ImPlotSubplotFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotSubplotFlags.None);
        }

        /// <summary>
        /// Verifies that link-all values are distinct and ordered.
        /// </summary>
        [Fact]
        public void LinkAllFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotSubplotFlags.LinkAllX, (int) ImPlotSubplotFlags.LinkAllY);
            Assert.True((int) ImPlotSubplotFlags.LinkAllY > (int) ImPlotSubplotFlags.LinkAllX);
        }

        /// <summary>
        /// Verifies that representative subplot flags do not overlap in value.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImPlotSubplotFlags.NoResize, (int) ImPlotSubplotFlags.NoAlign);
            Assert.NotEqual((int) ImPlotSubplotFlags.ShareItems, (int) ImPlotSubplotFlags.ColMajor);
        }
    }
}

