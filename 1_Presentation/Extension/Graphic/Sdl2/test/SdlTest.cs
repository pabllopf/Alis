using Xunit;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Structs;

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

        [Fact]
        public void ShouldComputeFourcc()
        {
            uint result = Sdl.Fourcc((byte)'Y', (byte)'V', (byte)'1', (byte)'2');
            uint expected = (uint)('Y' | ('V' << 8) | ('1' << 16) | ('2' << 24));
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldReturnGlCompiledVersion()
        {
            int version = Sdl.GetGlCompiledVersion();
            Assert.Equal(2 * 1000 + 0 * 100 + 18, version);
        }

        [Fact]
        public void ShouldReturnGetVersion()
        {
            var version = Sdl.GetVersion();
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(18, version.patch);
        }

        [Fact]
        public void ShouldComputeWindowPosUndefinedDisplay()
        {
            int pos = Sdl.WindowPosUndefinedDisplay(1);
            Assert.True((pos & unchecked((int)0xFFFF0000)) != 0);
        }

        [Fact]
        public void ShouldDetectWindowPosIsUndefined()
        {
            int pos = Sdl.WindowPosUndefinedDisplay(2);
            Assert.True(Sdl.WindowPosIsUndefined(pos));
            Assert.False(Sdl.WindowPosIsUndefined(100));
        }

        [Fact]
        public void ShouldComputeWindowPosCenteredDisplay()
        {
            int pos = Sdl.WindowPosCenteredDisplay(1);
            Assert.True((pos & unchecked((int)0xFFFF0000)) != 0);
        }

        [Fact]
        public void ShouldDetectWindowPosIsCentered()
        {
            int pos = Sdl.WindowPosCenteredDisplay(3);
            Assert.True(Sdl.WindowPosIsCentered(pos));
            Assert.False(Sdl.WindowPosIsCentered(200));
        }
        [Fact]
        public void ShouldComputeAudioBitSize()
        {
            Assert.Equal((ushort)0xFF, Sdl.SdlAudioBitSize(0x01FF));
            Assert.Equal((ushort)0x08, Sdl.SdlAudioBitSize(0x0108));
        }

        [Fact]
        public void ShouldDetectAudioIsFloat()
        {
            Assert.True(Sdl.SdlAudioIsFloat(0x0100));
            Assert.False(Sdl.SdlAudioIsFloat(0x0000));
        }

        [Fact]
        public void ShouldDetectAudioIsBigEndian()
        {
            Assert.True(Sdl.SdlAudioIsBigEndian(0x1000));
            Assert.False(Sdl.SdlAudioIsBigEndian(0x0000));
        }

        [Fact]
        public void ShouldDetectAudioIsSigned()
        {
            Assert.True(Sdl.SdlAudioIsSigned(0x8000));
            Assert.False(Sdl.SdlAudioIsSigned(0x0000));
        }

        [Fact]
        public void ShouldDetectAudioIsInt()
        {
            Assert.True(Sdl.SdlAudioIsInt(0x0000));
            Assert.False(Sdl.SdlAudioIsInt(0x0100));
        }

        [Fact]
        public void ShouldDetectAudioIsLittleEndian()
        {
            Assert.True(Sdl.SdlAudioIsLittleEndian(0x0000));
            Assert.False(Sdl.SdlAudioIsLittleEndian(0x1000));
        }

        [Fact]
        public void ShouldDetectAudioIsUnsigned()
        {
            Assert.True(Sdl.SdlAudioIsUnsigned(0x0000));
            Assert.False(Sdl.SdlAudioIsUnsigned(0x8000));
        }

        [Fact]
        public void ShouldDefinePixelFourcc()
        {
            uint result = Sdl.SdlDefinePixelFourcc((byte)'Y', (byte)'V', (byte)'1', (byte)'2');
            Assert.Equal(Sdl.Fourcc((byte)'Y', (byte)'V', (byte)'1', (byte)'2'), result);
        }
    }
}
