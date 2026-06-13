using Alis.Extension.Graphic.Sdl2.Mapping;
using Xunit;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The sdl test class
    /// </summary>
    public class SdlTest
    {
        /// <summary>
        /// Tests that should have correct constant values
        /// </summary>
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

        /// <summary>
        /// Tests that should compute fourcc
        /// </summary>
        [Fact]
        public void ShouldComputeFourcc()
        {
            uint result = Sdl.Fourcc((byte)'Y', (byte)'V', (byte)'1', (byte)'2');
            uint expected = (uint)('Y' | ('V' << 8) | ('1' << 16) | ('2' << 24));
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that should return gl compiled version
        /// </summary>
        [Fact]
        public void ShouldReturnGlCompiledVersion()
        {
            int version = Sdl.GetGlCompiledVersion();
            Assert.Equal(2 * 1000 + 0 * 100 + 18, version);
        }

        /// <summary>
        /// Tests that should return get version
        /// </summary>
        [Fact]
        public void ShouldReturnGetVersion()
        {
            Version version = Sdl.GetVersion();
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(18, version.patch);
        }

        /// <summary>
        /// Tests that should compute window pos undefined display
        /// </summary>
        [Fact]
        public void ShouldComputeWindowPosUndefinedDisplay()
        {
            int pos = Sdl.WindowPosUndefinedDisplay(1);
            Assert.True((pos & unchecked((int)0xFFFF0000)) != 0);
        }

        /// <summary>
        /// Tests that should detect window pos is undefined
        /// </summary>
        [Fact]
        public void ShouldDetectWindowPosIsUndefined()
        {
            int pos = Sdl.WindowPosUndefinedDisplay(2);
            Assert.True(Sdl.WindowPosIsUndefined(pos));
            Assert.False(Sdl.WindowPosIsUndefined(100));
        }

        /// <summary>
        /// Tests that should compute window pos centered display
        /// </summary>
        [Fact]
        public void ShouldComputeWindowPosCenteredDisplay()
        {
            int pos = Sdl.WindowPosCenteredDisplay(1);
            Assert.True((pos & unchecked((int)0xFFFF0000)) != 0);
        }

        /// <summary>
        /// Tests that should detect window pos is centered
        /// </summary>
        [Fact]
        public void ShouldDetectWindowPosIsCentered()
        {
            int pos = Sdl.WindowPosCenteredDisplay(3);
            Assert.True(Sdl.WindowPosIsCentered(pos));
            Assert.False(Sdl.WindowPosIsCentered(200));
        }
        /// <summary>
        /// Tests that should compute audio bit size
        /// </summary>
        [Fact]
        public void ShouldComputeAudioBitSize()
        {
            Assert.Equal((ushort)0xFF, Sdl.SdlAudioBitSize(0x01FF));
            Assert.Equal((ushort)0x08, Sdl.SdlAudioBitSize(0x0108));
        }

        /// <summary>
        /// Tests that should detect audio is float
        /// </summary>
        [Fact]
        public void ShouldDetectAudioIsFloat()
        {
            Assert.True(Sdl.SdlAudioIsFloat(0x0100));
            Assert.False(Sdl.SdlAudioIsFloat(0x0000));
        }

        /// <summary>
        /// Tests that should detect audio is big endian
        /// </summary>
        [Fact]
        public void ShouldDetectAudioIsBigEndian()
        {
            Assert.True(Sdl.SdlAudioIsBigEndian(0x1000));
            Assert.False(Sdl.SdlAudioIsBigEndian(0x0000));
        }

        /// <summary>
        /// Tests that should detect audio is signed
        /// </summary>
        [Fact]
        public void ShouldDetectAudioIsSigned()
        {
            Assert.True(Sdl.SdlAudioIsSigned(0x8000));
            Assert.False(Sdl.SdlAudioIsSigned(0x0000));
        }

        /// <summary>
        /// Tests that should detect audio is int
        /// </summary>
        [Fact]
        public void ShouldDetectAudioIsInt()
        {
            Assert.True(Sdl.SdlAudioIsInt(0x0000));
            Assert.False(Sdl.SdlAudioIsInt(0x0100));
        }

        /// <summary>
        /// Tests that should detect audio is little endian
        /// </summary>
        [Fact]
        public void ShouldDetectAudioIsLittleEndian()
        {
            Assert.True(Sdl.SdlAudioIsLittleEndian(0x0000));
            Assert.False(Sdl.SdlAudioIsLittleEndian(0x1000));
        }

        /// <summary>
        /// Tests that should detect audio is unsigned
        /// </summary>
        [Fact]
        public void ShouldDetectAudioIsUnsigned()
        {
            Assert.True(Sdl.SdlAudioIsUnsigned(0x0000));
            Assert.False(Sdl.SdlAudioIsUnsigned(0x8000));
        }

        /// <summary>
        /// Tests that should define pixel fourcc
        /// </summary>
        [Fact]
        public void ShouldDefinePixelFourcc()
        {
            uint result = Sdl.SdlDefinePixelFourcc((byte)'Y', (byte)'V', (byte)'1', (byte)'2');
            Assert.Equal(Sdl.Fourcc((byte)'Y', (byte)'V', (byte)'1', (byte)'2'), result);
        }

        /// <summary>
        /// Tests that ScanCodeToKeyCode maps SDL scancode to keycode with mask applied
        /// </summary>
        [Fact]
        public void ShouldMapScanCodeToKeyCode()
        {
            KeyCodes result = Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeA);
            KeyCodes expected = (KeyCodes)((int)SdlScancode.SdlScancodeA | Sdl.KScancodeMask);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that ScanCodeToKeyCode returns unknown for unknown scancode
        /// </summary>
        [Fact]
        public void ShouldMapScanCodeToKeyCodeUnknown()
        {
            KeyCodes result = Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeUnknown);
            KeyCodes expected = (KeyCodes)((int)SdlScancode.SdlScancodeUnknown | Sdl.KScancodeMask);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that ScanCodeToKeyCode produces distinct values for different scancodes
        /// </summary>
        [Fact]
        public void ShouldMapScanCodeToKeyCodeDistinct()
        {
            KeyCodes resultA = Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeA);
            KeyCodes resultB = Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeB);
            Assert.NotEqual(resultA, resultB);
        }

        /// <summary>
        /// Tests that MixMaxVolume constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveMixMaxVolumeConstant()
        {
            Assert.Equal(128, Sdl.MixMaxVolume);
        }

        /// <summary>
        /// Tests that AndroidExternalStorageRead constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAndroidExternalStorageReadConstant()
        {
            Assert.Equal(0x01, Sdl.AndroidExternalStorageRead);
        }

        /// <summary>
        /// Tests that AndroidExternalStorageWrite constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAndroidExternalStorageWriteConstant()
        {
            Assert.Equal(0x02, Sdl.AndroidExternalStorageWrite);
        }

        /// <summary>
        /// Tests that GlButtonLMask equals Button(ButtonLeft)
        /// </summary>
        [Fact]
        public void ShouldHaveGlButtonLMask()
        {
            Assert.Equal(Sdl.Button(Sdl.ButtonLeft), Sdl.GlButtonLMask);
        }

        /// <summary>
        /// Tests that GlButtonMMask equals Button(ButtonMiddle)
        /// </summary>
        [Fact]
        public void ShouldHaveGlButtonMMask()
        {
            Assert.Equal(Sdl.Button(Sdl.ButtonMiddle), Sdl.GlButtonMMask);
        }

        /// <summary>
        /// Tests that GlButtonRMask equals Button(ButtonRight)
        /// </summary>
        [Fact]
        public void ShouldHaveGlButtonRMask()
        {
            Assert.Equal(Sdl.Button(Sdl.ButtonRight), Sdl.GlButtonRMask);
        }

        /// <summary>
        /// Tests that GlButtonX1Mask equals Button(ButtonX1)
        /// </summary>
        [Fact]
        public void ShouldHaveGlButtonX1Mask()
        {
            Assert.Equal(Sdl.Button(Sdl.ButtonX1), Sdl.GlButtonX1Mask);
        }

        /// <summary>
        /// Tests that GlButtonX2Mask equals Button(ButtonX2)
        /// </summary>
        [Fact]
        public void ShouldHaveGlButtonX2Mask()
        {
            Assert.Equal(Sdl.Button(Sdl.ButtonX2), Sdl.GlButtonX2Mask);
        }
    }
}
