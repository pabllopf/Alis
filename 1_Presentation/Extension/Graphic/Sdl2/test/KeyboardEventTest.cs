using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Mapping;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The keyboard event test class
    /// </summary>
    public class KeyboardEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            KeyboardEvent evt = new KeyboardEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.repeat);
        }

        /// <summary>
        /// Tests that should assign keysym
        /// </summary>
        [Fact]
        public void ShouldAssignKeysym()
        {
            KeyboardEvent evt = new KeyboardEvent();
            evt.KeySym = new KeySym { unicode = 65u, scancode = SdlScancode.SdlScancodeA, sym = KeyCodes.A };
            Assert.Equal(65u, evt.KeySym.unicode);
            Assert.Equal(SdlScancode.SdlScancodeA, evt.KeySym.scancode);
            Assert.Equal(KeyCodes.A, evt.KeySym.sym);
        }
    }
}
