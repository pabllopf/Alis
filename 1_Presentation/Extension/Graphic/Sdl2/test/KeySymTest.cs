using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Mapping;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The key sym test class
    /// </summary>
    public class KeySymTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            KeySym sym = new KeySym();
            Assert.Equal(0u, sym.unicode);
        }

        /// <summary>
        /// Tests that should assign and retrieve fields
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveFields()
        {
            KeySym sym = new KeySym
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
