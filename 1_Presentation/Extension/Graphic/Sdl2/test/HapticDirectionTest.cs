using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class HapticDirectionTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            HapticDirection dir = new HapticDirection();
            Assert.Equal(0, dir.type);
            Assert.Null(dir.dir);
        }
    }
}
