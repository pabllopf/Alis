using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    /// Provides unit coverage for <see cref="Mode"/> enum values.
    /// </summary>
    public class ModeTest
    {
        /// <summary>
        /// Verifies that local mode uses value 0.
        /// </summary>
        [Fact]
        public void Local_ShouldBeZero()
        {
            Assert.Equal(0, (int)Mode.Local);
        }

        /// <summary>
        /// Verifies that world mode uses value 1.
        /// </summary>
        [Fact]
        public void World_ShouldBeOne()
        {
            Assert.Equal(1, (int)Mode.World);
        }
    }
}

