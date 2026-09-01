// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlPureLogicTests.cs
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
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for the pure, side-effect-free logic members of the sdl wrapper class.
    ///     These tests do not require a native SDL2 runtime and always run.
    /// </summary>
    public class SdlPureLogicTests
    {
        /// <summary>
        ///     Tests that the compiled gl version returns the expected hard coded value
        /// </summary>
        [Fact]
        public void GetGlCompiledVersion_ReturnsHardCodedValue()
        {
            int result = Sdl.GetGlCompiledVersion();
            Assert.Equal(2 * 1000 + 0 * 100 + 18, result);
        }

        /// <summary>
        ///     Tests that get version returns the expected hard coded version
        /// </summary>
        [Fact]
        public void GetVersion_ReturnsHardCodedVersion()
        {
            Version version = Sdl.GetVersion();
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(18, version.patch);
        }

        /// <summary>
        ///     Tests that window pos undefined display combines the undefined mask with the display index
        /// </summary>
        [Fact]
        public void WindowPosUndefinedDisplay_CombinesMaskAndDisplay()
        {
            int pos = Sdl.WindowPosUndefinedDisplay(3);
            Assert.True((pos & 0xFFFF0000) == (long) WindowPos.WindowPosUndefinedMask);
            Assert.Equal(3, pos & 0xFFFF);
        }

        /// <summary>
        ///     Tests that window pos is undefined returns true for undefined positions and false otherwise
        /// </summary>
        [Fact]
        public void WindowPosIsUndefined_ReturnsTrueOnlyForUndefined()
        {
            int pos = Sdl.WindowPosUndefinedDisplay(1);
            Assert.True(Sdl.WindowPosIsUndefined(pos));
            Assert.False(Sdl.WindowPosIsUndefined(0));
            Assert.False(Sdl.WindowPosIsUndefined(100));
        }

        /// <summary>
        ///     Tests that window pos centered display combines the centered mask with the display index
        /// </summary>
        [Fact]
        public void WindowPosCenteredDisplay_CombinesMaskAndDisplay()
        {
            int pos = Sdl.WindowPosCenteredDisplay(2);
            Assert.True((pos & 0xFFFF0000) == (long) WindowPos.WindowPosCenteredMask);
            Assert.Equal(2, pos & 0xFFFF);
        }

        /// <summary>
        ///     Tests that window pos is centered returns true for centered positions and false otherwise
        /// </summary>
        [Fact]
        public void WindowPosIsCentered_ReturnsTrueOnlyForCentered()
        {
            int pos = Sdl.WindowPosCenteredDisplay(1);
            Assert.True(Sdl.WindowPosIsCentered(pos));
            Assert.False(Sdl.WindowPosIsCentered(0));
            Assert.False(Sdl.WindowPosIsCentered(200));
        }

        /// <summary>
        ///     Tests that a window position is never both undefined and centered
        /// </summary>
        [Fact]
        public void WindowPos_IsNotBothUndefinedAndCentered()
        {
            int undefined = Sdl.WindowPosUndefinedDisplay(0);
            int centered = Sdl.WindowPosCenteredDisplay(0);
            Assert.False(Sdl.WindowPosIsCentered(undefined));
            Assert.False(Sdl.WindowPosIsUndefined(centered));
        }

        /// <summary>
        ///     Tests that fourcc packs all four bytes into a single value
        /// </summary>
        [Fact]
        public void Fourcc_PacksAllBytes()
        {
            uint result = Sdl.Fourcc(0x01, 0x02, 0x03, 0x04);
            Assert.Equal(0x04030201u, result);
        }

        /// <summary>
        ///     Tests that fourcc is symmetric with byte values
        /// </summary>
        [Fact]
        public void Fourcc_WithZeroBytes_ReturnsZero()
        {
            Assert.Equal(0u, Sdl.Fourcc(0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that sdl define pixel fourcc delegates to fourcc
        /// </summary>
        [Fact]
        public void SdlDefinePixelFourcc_MatchesFourcc()
        {
            uint expected = Sdl.Fourcc((byte) 'A', (byte) 'B', (byte) 'C', (byte) 'D');
            Assert.Equal(expected, Sdl.SdlDefinePixelFourcc((byte) 'A', (byte) 'B', (byte) 'C', (byte) 'D'));
        }

        /// <summary>
        ///     Tests that scan code to key code applies the scancode mask
        /// </summary>
        [Fact]
        public void ScanCodeToKeyCode_AppliesScancodeMask()
        {
            KeyCodes result = Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeA);
            KeyCodes expected = (KeyCodes) ((int) SdlScancode.SdlScancodeA | Sdl.KScancodeMask);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that scan code to key code for unknown produces a distinct masked value
        /// </summary>
        [Fact]
        public void ScanCodeToKeyCode_Unknown_IsMasked()
        {
            KeyCodes result = Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeUnknown);
            KeyCodes expected = (KeyCodes) (0 | Sdl.KScancodeMask);
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that scan code to key code produces distinct values for distinct scancodes
        /// </summary>
        [Fact]
        public void ScanCodeToKeyCode_DistinctScancodes_ProduceDistinctKeys()
        {
            Assert.NotEqual(
                Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeA),
                Sdl.ScanCodeToKeyCode(SdlScancode.SdlScancodeB)
            );
        }

        /// <summary>
        ///     Tests that button returns a single bit set
        /// </summary>
        [Fact]
        public void Button_ReturnsSingleBit()
        {
            Assert.Equal(1u, Sdl.Button(1));
            Assert.Equal(2u, Sdl.Button(2));
            Assert.Equal(4u, Sdl.Button(3));
            Assert.Equal(8u, Sdl.Button(4));
            Assert.Equal(16u, Sdl.Button(5));
        }

        /// <summary>
        ///     Tests that button masks match single bit results
        /// </summary>
        [Fact]
        public void ButtonMasks_MatchButtonResults()
        {
            Assert.Equal(Sdl.Button(Sdl.ButtonLeft), Sdl.GlButtonLMask);
            Assert.Equal(Sdl.Button(Sdl.ButtonMiddle), Sdl.GlButtonMMask);
            Assert.Equal(Sdl.Button(Sdl.ButtonRight), Sdl.GlButtonRMask);
            Assert.Equal(Sdl.Button(Sdl.ButtonX1), Sdl.GlButtonX1Mask);
            Assert.Equal(Sdl.Button(Sdl.ButtonX2), Sdl.GlButtonX2Mask);
        }

        /// <summary>
        ///     Tests that sdl audio bit size extracts the low byte
        /// </summary>
        [Fact]
        public void SdlAudioBitSize_ExtractsLowByte()
        {
            Assert.Equal((ushort) 0xFF, Sdl.SdlAudioBitSize(0x01FF));
            Assert.Equal((ushort) 0x08, Sdl.SdlAudioBitSize(0x0108));
            Assert.Equal((ushort) 0x00, Sdl.SdlAudioBitSize(0x0000));
            Assert.Equal((ushort) 0x10, Sdl.SdlAudioBitSize(0x0210));
        }

        /// <summary>
        ///     Tests that sdl audio is float detects the datatype mask
        /// </summary>
        [Fact]
        public void SdlAudioIsFloat_DetectsDatatypeMask()
        {
            Assert.True(Sdl.SdlAudioIsFloat(0x0100));
            Assert.False(Sdl.SdlAudioIsFloat(0x0000));
        }

        /// <summary>
        ///     Tests that sdl audio is big endian detects the endian mask
        /// </summary>
        [Fact]
        public void SdlAudioIsBigEndian_DetectsEndianMask()
        {
            Assert.True(Sdl.SdlAudioIsBigEndian(0x1000));
            Assert.False(Sdl.SdlAudioIsBigEndian(0x0000));
        }

        /// <summary>
        ///     Tests that sdl audio is signed detects the signed mask
        /// </summary>
        [Fact]
        public void SdlAudioIsSigned_DetectsSignedMask()
        {
            Assert.True(Sdl.SdlAudioIsSigned(0x8000));
            Assert.False(Sdl.SdlAudioIsSigned(0x0000));
        }

        /// <summary>
        ///     Tests that sdl audio is int returns true when the datatype is not float
        /// </summary>
        [Fact]
        public void SdlAudioIsInt_IsInverseOfFloat()
        {
            Assert.True(Sdl.SdlAudioIsInt(0x0000));
            Assert.False(Sdl.SdlAudioIsInt(0x0100));
        }

        /// <summary>
        ///     Tests that sdl audio is little endian returns true when not big endian
        /// </summary>
        [Fact]
        public void SdlAudioIsLittleEndian_IsInverseOfBigEndian()
        {
            Assert.True(Sdl.SdlAudioIsLittleEndian(0x0000));
            Assert.False(Sdl.SdlAudioIsLittleEndian(0x1000));
        }

        /// <summary>
        ///     Tests that sdl audio is unsigned returns true when not signed
        /// </summary>
        [Fact]
        public void SdlAudioIsUnsigned_IsInverseOfSigned()
        {
            Assert.True(Sdl.SdlAudioIsUnsigned(0x0000));
            Assert.False(Sdl.SdlAudioIsUnsigned(0x8000));
        }

        /// <summary>
        ///     Tests that the audio format constants have distinct high nibbles
        /// </summary>
        [Fact]
        public void AudioFormatConstants_AreDistinct()
        {
            Assert.NotEqual(Sdl.AudioU8, Sdl.AudioS8);
            Assert.NotEqual(Sdl.AudioU16Lsb, Sdl.AudioU16Msb);
            Assert.NotEqual(Sdl.AudioS16Lsb, Sdl.AudioS16Msb);
            Assert.NotEqual(Sdl.AudioS32Lsb, Sdl.AudioS32Msb);
            Assert.NotEqual(Sdl.AudioF32Lsb, Sdl.AudioF32Msb);
        }

        /// <summary>
        ///     Tests that the audio alias constants match their lsb equivalents
        /// </summary>
        [Fact]
        public void AudioAliases_MatchLsbEquivalents()
        {
            Assert.Equal(Sdl.AudioU16Lsb, Sdl.AudioU16);
            Assert.Equal(Sdl.AudioS16Lsb, Sdl.AudioS16);
            Assert.Equal(Sdl.AudioS32Lsb, Sdl.AudioS32);
            Assert.Equal(Sdl.AudioF32Lsb, Sdl.AudioF32);
        }

        /// <summary>
        ///     Tests that the audio system constants respect the host endianness
        /// </summary>
        [Fact]
        public void AudioSystemConstants_RespectEndianness()
        {
            ushort expectedU16 = BitConverter.IsLittleEndian ? Sdl.AudioU16Lsb : Sdl.AudioU16Msb;
            ushort expectedS16 = BitConverter.IsLittleEndian ? Sdl.AudioS16Lsb : Sdl.AudioS16Msb;
            ushort expectedS32 = BitConverter.IsLittleEndian ? Sdl.AudioS32Lsb : Sdl.AudioS32Msb;
            ushort expectedF32 = BitConverter.IsLittleEndian ? Sdl.AudioF32Lsb : Sdl.AudioF32Msb;
            Assert.Equal(expectedU16, Sdl.GlAudioU16Sys);
            Assert.Equal(expectedS16, Sdl.GlAudioS16Sys);
            Assert.Equal(expectedS32, Sdl.GlAudioS32Sys);
            Assert.Equal(expectedF32, Sdl.GlAudioF32Sys);
        }

        /// <summary>
        ///     Tests that the pixel format alias constants match their gl format counterparts
        /// </summary>
        [Fact]
        public void PixelFormatAliases_MatchGlFormats()
        {
            Assert.Equal(Sdl.GlFormatXRgb444, Sdl.PixelFormatRgb444);
            Assert.Equal(Sdl.GlFormatXBgr444, Sdl.PixelFormatBgr444);
            Assert.Equal(Sdl.GlFormatXRgb1555, Sdl.PixelFormatRgb555);
            Assert.Equal(Sdl.GlFormatXBgr1555, Sdl.PixelFormatBgr555);
            Assert.Equal(Sdl.GlFormatXRgb888, Sdl.PixelFormatRgb888);
            Assert.Equal(Sdl.GlFormatXBgr888, Sdl.PixelFormatBgr888);
        }

        /// <summary>
        ///     Tests that the packed 8888 pixel formats are mutually distinct
        /// </summary>
        [Fact]
        public void Packed8888Formats_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatArgb8888, Sdl.PixelFormatRgba8888);
            Assert.NotEqual(Sdl.PixelFormatArgb8888, Sdl.PixelFormatABgr8888);
            Assert.NotEqual(Sdl.PixelFormatArgb8888, Sdl.PixelFormatB8888);
            Assert.NotEqual(Sdl.PixelFormatRgbX8888, Sdl.PixelFormatArgb8888);
            Assert.NotEqual(Sdl.PixelFormatBGrx8888, Sdl.PixelFormatRgbX8888);
        }

        /// <summary>
        ///     Tests that the packed 4444 pixel formats are mutually distinct
        /// </summary>
        [Fact]
        public void Packed4444Formats_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatArgb4444, Sdl.PixelFormatRgba4444);
            Assert.NotEqual(Sdl.PixelFormatArgb4444, Sdl.PixelFormatABgr4444);
            Assert.NotEqual(Sdl.PixelFormatArgb4444, Sdl.PixelFormatBGra4444);
        }

        /// <summary>
        ///     Tests that the packed 1555 pixel formats are mutually distinct
        /// </summary>
        [Fact]
        public void Packed1555Formats_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatArgb1555, Sdl.PixelFormatRgba5551);
            Assert.NotEqual(Sdl.PixelFormatArgb1555, Sdl.PixelFormatABgr1555);
            Assert.NotEqual(Sdl.PixelFormatArgb1555, Sdl.PixelFormatBGra5551);
        }

        /// <summary>
        ///     Tests that rgb and bgr pixel formats are distinct
        /// </summary>
        [Fact]
        public void RgbAndBgrFormats_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatRgb24, Sdl.PixelFormatBgr24);
            Assert.NotEqual(Sdl.PixelFormatRgb565, Sdl.PixelFormatBgr565);
            Assert.NotEqual(Sdl.PixelFormatRgb888, Sdl.PixelFormatBgr888);
        }

        /// <summary>
        ///     Tests that the indexed and packed pixel format families are mutually distinct
        /// </summary>
        [Fact]
        public void PixelFormatFamilies_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatIndex1Lsb, Sdl.PixelFormatIndex1Msb);
            Assert.NotEqual(Sdl.PixelFormatIndex4Lsb, Sdl.PixelFormatIndex4Msb);
            Assert.NotEqual(Sdl.PixelFormatIndex1Lsb, Sdl.PixelFormatIndex4Lsb);
            Assert.NotEqual(Sdl.PixelFormatIndex8, Sdl.PixelFormatRgb332);
        }

        /// <summary>
        ///     Tests that the yv12 and iy fourcc pixel formats are distinct
        /// </summary>
        [Fact]
        public void Yv12AndIyFormats_AreDistinct()
        {
            Assert.NotEqual(Sdl.PixelFormatYv12, Sdl.PixelFormatIy);
        }

        /// <summary>
        ///     Tests that the yv12 pixel format matches the fourcc for YV12
        /// </summary>
        [Fact]
        public void Yv12_MatchesFourcc()
        {
            uint expected = Sdl.Fourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2');
            Assert.Equal(expected, Sdl.PixelFormatYv12);
        }

        /// <summary>
        ///     Tests that the indexed pixel formats define the expected leading type bits
        /// </summary>
        [Fact]
        public void IndexedFormats_HaveExpectedTypeBits()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatIndex1Lsb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex1Msb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex4Lsb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex4Msb);
            Assert.NotEqual(0u, Sdl.PixelFormatIndex8);
        }
    }
}
