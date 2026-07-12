// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Xunit;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;

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

        /// <summary>
        /// Tests that GlAudioU16Sys matches endianness
        /// </summary>
        [Fact]
        public void ShouldHaveGlAudioU16Sys()
        {
            ushort expected = BitConverter.IsLittleEndian ? Sdl.AudioU16Lsb : Sdl.AudioU16Msb;
            Assert.Equal(expected, Sdl.GlAudioU16Sys);
        }

        /// <summary>
        /// Tests that GlAudioS16Sys matches endianness
        /// </summary>
        [Fact]
        public void ShouldHaveGlAudioS16Sys()
        {
            ushort expected = BitConverter.IsLittleEndian ? Sdl.AudioS16Lsb : Sdl.AudioS16Msb;
            Assert.Equal(expected, Sdl.GlAudioS16Sys);
        }

        /// <summary>
        /// Tests that GlAudioS32Sys matches endianness
        /// </summary>
        [Fact]
        public void ShouldHaveGlAudioS32Sys()
        {
            ushort expected = BitConverter.IsLittleEndian ? Sdl.AudioS32Lsb : Sdl.AudioS32Msb;
            Assert.Equal(expected, Sdl.GlAudioS32Sys);
        }

        /// <summary>
        /// Tests that GlAudioF32Sys matches endianness
        /// </summary>
        [Fact]
        public void ShouldHaveGlAudioF32Sys()
        {
            ushort expected = BitConverter.IsLittleEndian ? Sdl.AudioF32Lsb : Sdl.AudioF32Msb;
            Assert.Equal(expected, Sdl.GlAudioF32Sys);
        }

        /// <summary>
        /// Tests that AudioU8 constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioU8Constant()
        {
            Assert.Equal((ushort)0x0008, Sdl.AudioU8);
        }

        /// <summary>
        /// Tests that AudioS8 constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS8Constant()
        {
            Assert.Equal((ushort)0x8008, Sdl.AudioS8);
        }

        /// <summary>
        /// Tests that AudioU16Lsb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioU16LsbConstant()
        {
            Assert.Equal((ushort)0x0010, Sdl.AudioU16Lsb);
        }

        /// <summary>
        /// Tests that AudioS16Lsb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS16LsbConstant()
        {
            Assert.Equal((ushort)0x8010, Sdl.AudioS16Lsb);
        }

        /// <summary>
        /// Tests that AudioU16Msb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioU16MsbConstant()
        {
            Assert.Equal((ushort)0x1010, Sdl.AudioU16Msb);
        }

        /// <summary>
        /// Tests that AudioS16Msb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS16MsbConstant()
        {
            Assert.Equal((ushort)0x9010, Sdl.AudioS16Msb);
        }

        /// <summary>
        /// Tests that AudioU16 alias matches AudioU16Lsb
        /// </summary>
        [Fact]
        public void ShouldHaveAudioU16Alias()
        {
            Assert.Equal(Sdl.AudioU16Lsb, Sdl.AudioU16);
        }

        /// <summary>
        /// Tests that AudioS16 alias matches AudioS16Lsb
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS16Alias()
        {
            Assert.Equal(Sdl.AudioS16Lsb, Sdl.AudioS16);
        }

        /// <summary>
        /// Tests that AudioS32Lsb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS32LsbConstant()
        {
            Assert.Equal((ushort)0x8020, Sdl.AudioS32Lsb);
        }

        /// <summary>
        /// Tests that AudioS32Msb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS32MsbConstant()
        {
            Assert.Equal((ushort)0x9020, Sdl.AudioS32Msb);
        }

        /// <summary>
        /// Tests that AudioS32 alias matches AudioS32Lsb
        /// </summary>
        [Fact]
        public void ShouldHaveAudioS32Alias()
        {
            Assert.Equal(Sdl.AudioS32Lsb, Sdl.AudioS32);
        }

        /// <summary>
        /// Tests that AudioF32Lsb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioF32LsbConstant()
        {
            Assert.Equal((ushort)0x8120, Sdl.AudioF32Lsb);
        }

        /// <summary>
        /// Tests that AudioF32Msb constant has correct value
        /// </summary>
        [Fact]
        public void ShouldHaveAudioF32MsbConstant()
        {
            Assert.Equal((ushort)0x9120, Sdl.AudioF32Msb);
        }

        /// <summary>
        /// Tests that AudioF32 alias matches AudioF32Lsb
        /// </summary>
        [Fact]
        public void ShouldHaveAudioF32Alias()
        {
            Assert.Equal(Sdl.AudioF32Lsb, Sdl.AudioF32);
        }
    }
}
