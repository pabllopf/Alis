using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Mapping;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class KeySymTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var sym = new KeySym();
            Assert.Equal(0u, sym.unicode);
        }
    }
}
