using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Mapping;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class KeyboardEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new KeyboardEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.repeat);
        }

        [Fact]
        public void ShouldAssignKeysym()
        {
            var evt = new KeyboardEvent();
            evt.KeySym = new KeySym { unicode = 65u, scancode = SdlScancode.SdlScancodeA, sym = KeyCodes.A };
            Assert.Equal(65u, evt.KeySym.unicode);
            Assert.Equal(SdlScancode.SdlScancodeA, evt.KeySym.scancode);
            Assert.Equal(KeyCodes.A, evt.KeySym.sym);
        }
    }
}
