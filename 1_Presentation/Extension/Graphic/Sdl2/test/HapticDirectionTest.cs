using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The haptic direction test class
    /// </summary>
    public class HapticDirectionTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            HapticDirection dir = new HapticDirection();
            Assert.Equal(0, dir.type);
            Assert.Null(dir.dir);
        }
    }
}
