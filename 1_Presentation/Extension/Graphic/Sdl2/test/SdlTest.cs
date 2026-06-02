using Xunit;
using Alis.Extension.Graphic.Sdl2;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class SdlTest
    {
        [Fact]
        public void ShouldHaveCorrectConstantValues()
        {
            Assert.Equal(32, Sdl.TextEditingEventTextSize);
            Assert.Equal(32, Sdl.TextInputEventTextSize);
            Assert.Equal(-1, Sdl.Query);
            Assert.Equal(0, Sdl.Ignore);
            Assert.Equal(0, Sdl.Disable);
            Assert.Equal(1, Sdl.Enable);
            Assert.Equal(1 << 30, Sdl.KScancodeMask);
            Assert.Equal(1u, Sdl.ButtonLeft);
            Assert.Equal(2u, Sdl.ButtonMiddle);
            Assert.Equal(3u, Sdl.ButtonRight);
            Assert.Equal(4u, Sdl.ButtonX1);
            Assert.Equal(5u, Sdl.ButtonX2);
            Assert.Equal((ushort)0xFF, Sdl.AudioMaskBitSize);
            Assert.Equal((ushort)(1 << 8), Sdl.AudioMaskDatatype);
            Assert.Equal((ushort)(1 << 12), Sdl.AudioMaskEndian);
            Assert.Equal((ushort)(1 << 15), Sdl.AudioMaskSigned);
        }
    }
}
