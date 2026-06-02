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

        [Fact]
        public void ShouldAssignAndRetrieveFields()
        {
            var sym = new KeySym
            {
                scancode = SdlScancode.SdlScancodeA,
                sym = KeyCodes.Return,
                unicode = 65u
            };
            Assert.Equal(SdlScancode.SdlScancodeA, sym.scancode);
            Assert.Equal(KeyCodes.Return, sym.sym);
            Assert.Equal(65u, sym.unicode);
        }
    }
}
