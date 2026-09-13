// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:SdlManagedCoverageTests.cs
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

using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for the fully managed members of <see cref="Sdl" /> that
    ///     execute without any native SDL2 dependency.
    /// </summary>
    public class SdlManagedCoverageTests
    {
        /// <summary>Tests the TextEditingEventTextSize constant.</summary>
        [Fact]
        public void TextEditingEventTextSize_Is32()
        {
            Assert.Equal(32, Sdl.TextEditingEventTextSize);
        }

        /// <summary>Tests the TextInputEventTextSize constant.</summary>
        [Fact]
        public void TextInputEventTextSize_Is32()
        {
            Assert.Equal(32, Sdl.TextInputEventTextSize);
        }

        /// <summary>Tests the Query constant.</summary>
        [Fact]
        public void Query_IsMinusOne()
        {
            Assert.Equal(-1, Sdl.Query);
        }

        /// <summary>Tests the Ignore constant.</summary>
        [Fact]
        public void Ignore_IsZero()
        {
            Assert.Equal(0, Sdl.Ignore);
        }

        /// <summary>Tests the Disable constant.</summary>
        [Fact]
        public void Disable_IsZero()
        {
            Assert.Equal(0, Sdl.Disable);
        }

        /// <summary>Tests the Enable constant.</summary>
        [Fact]
        public void Enable_IsOne()
        {
            Assert.Equal(1, Sdl.Enable);
        }

        /// <summary>Tests the KScancodeMask constant.</summary>
        [Fact]
        public void KScancodeMask_IsCorrect()
        {
            Assert.Equal(1 << 30, Sdl.KScancodeMask);
        }

        /// <summary>Tests the audio format constants.</summary>
        [Fact]
        public void AudioFormatConstants_AreCorrect()
        {
            Assert.Equal((ushort) 0xFF, Sdl.AudioMaskBitSize);
            Assert.Equal((ushort) 0x0100, Sdl.AudioMaskDatatype);
            Assert.Equal((ushort) 0x1000, Sdl.AudioMaskEndian);
            Assert.Equal((ushort) 0x8000, Sdl.AudioMaskSigned);
            Assert.Equal((ushort) 0x0008, Sdl.AudioU8);
            Assert.Equal((ushort) 0x8008, Sdl.AudioS8);
            Assert.Equal((ushort) 0x0010, Sdl.AudioU16Lsb);
            Assert.Equal((ushort) 0x8010, Sdl.AudioS16Lsb);
            Assert.Equal((ushort) 0x1010, Sdl.AudioU16Msb);
            Assert.Equal((ushort) 0x9010, Sdl.AudioS16Msb);
            Assert.Equal((ushort) 0x8020, Sdl.AudioS32Lsb);
            Assert.Equal((ushort) 0x9020, Sdl.AudioS32Msb);
            Assert.Equal((ushort) 0x8120, Sdl.AudioF32Lsb);
            Assert.Equal((ushort) 0x9120, Sdl.AudioF32Msb);
            Assert.Equal(Sdl.AudioU16Lsb, Sdl.AudioU16);
            Assert.Equal(Sdl.AudioS16Lsb, Sdl.AudioS16);
            Assert.Equal(Sdl.AudioS32Lsb, Sdl.AudioS32);
            Assert.Equal(Sdl.AudioF32Lsb, Sdl.AudioF32);
        }

        /// <summary>Tests the MixMaxVolume constant.</summary>
        [Fact]
        public void MixMaxVolume_Is128()
        {
            Assert.Equal(128, Sdl.MixMaxVolume);
        }

        /// <summary>Tests the Android external storage constants.</summary>
        [Fact]
        public void AndroidExternalStorage_AreCorrect()
        {
            Assert.Equal(0x01, Sdl.AndroidExternalStorageRead);
            Assert.Equal(0x02, Sdl.AndroidExternalStorageWrite);
        }

        /// <summary>Tests the pixel format static readonly values.</summary>
        [Fact]
        public void IndexPixelFormats_AreCorrect()
        {
            Assert.Equal(0u, Sdl.PixelFormatUnknown);
            Assert.Equal(0x11100100u, Sdl.PixelFormatIndex1Lsb);
            Assert.Equal(0x11200100u, Sdl.PixelFormatIndex1Msb);
            Assert.Equal(0x12100400u, Sdl.PixelFormatIndex4Lsb);
            Assert.Equal(0x12200400u, Sdl.PixelFormatIndex4Msb);
            Assert.Equal(0x13000801u, Sdl.PixelFormatIndex8);
        }

        /// <summary>Tests the 16 bit packed pixel format values.</summary>
        [Fact]
        public void Packed16PixelFormats_AreCorrect()
        {
            Assert.Equal(0x14110801u, Sdl.PixelFormatRgb332);
            Assert.Equal(0x15120C02u, Sdl.PixelFormatRgb444);
            Assert.Equal(0x15520C02u, Sdl.PixelFormatBgr444);
            Assert.Equal(0x15130F02u, Sdl.PixelFormatRgb555);
            Assert.Equal(0x11130F02u, Sdl.PixelFormatBgr555);
            Assert.Equal(0x15321002u, Sdl.PixelFormatArgb4444);
            Assert.Equal(0x15421002u, Sdl.PixelFormatRgba4444);
            Assert.Equal(0x15721002u, Sdl.PixelFormatABgr4444);
            Assert.Equal(0x15821002u, Sdl.PixelFormatBGra4444);
            Assert.Equal(0x15331002u, Sdl.PixelFormatArgb1555);
            Assert.Equal(0x15441002u, Sdl.PixelFormatRgba5551);
            Assert.Equal(0x15731002u, Sdl.PixelFormatABgr1555);
            Assert.Equal(0x15841002u, Sdl.PixelFormatBGra5551);
            Assert.Equal(0x15151002u, Sdl.PixelFormatRgb565);
            Assert.Equal(0x15551002u, Sdl.PixelFormatBgr565);
            Assert.Equal(0x16161804u, Sdl.PixelFormatRgb888);
            Assert.Equal(0x16261804u, Sdl.PixelFormatRgbX8888);
            Assert.Equal(0x16561804u, Sdl.PixelFormatBgr888);
            Assert.Equal(0x16661804u, Sdl.PixelFormatBGrx8888);
            Assert.Equal(0x16362004u, Sdl.PixelFormatArgb8888);
            Assert.Equal(0x16462004u, Sdl.PixelFormatRgba8888);
            Assert.Equal(0x16762004u, Sdl.PixelFormatABgr8888);
            Assert.Equal(0x16862004u, Sdl.PixelFormatB8888);
            Assert.Equal(0x16372004u, Sdl.PixelFormatArgb2101010);
        }

        /// <summary>Tests the 24 bit array pixel format values.</summary>
        [Fact]
        public void Array24PixelFormats_AreCorrect()
        {
            Assert.Equal(0x17101803u, Sdl.PixelFormatRgb24);
            Assert.Equal(0x17401803u, Sdl.PixelFormatBgr24);
        }

        /// <summary>Tests the fourcc pixel format values.</summary>
        [Fact]
        public void FourccPixelFormats_AreCorrect()
        {
            Assert.Equal(0x32315659u, Sdl.PixelFormatYv12);
            Assert.Equal(0x56555949u, Sdl.PixelFormatIy);
        }

        /// <summary>Tests the GL button mask values.</summary>
        [Fact]
        public void GlButtonMasks_AreCorrect()
        {
            Assert.Equal(1u, Sdl.GlButtonLMask);
            Assert.Equal(2u, Sdl.GlButtonMMask);
            Assert.Equal(4u, Sdl.GlButtonRMask);
            Assert.Equal(8u, Sdl.GlButtonX1Mask);
            Assert.Equal(16u, Sdl.GlButtonX2Mask);
        }

        /// <summary>Tests the system audio format values.</summary>
        [Fact]
        public void GlAudioSysFormats_MatchPlatform()
        {
            if (System.BitConverter.IsLittleEndian)
            {
                Assert.Equal((ushort) 0x0010, Sdl.GlAudioU16Sys);
                Assert.Equal((ushort) 0x8010, Sdl.GlAudioS16Sys);
                Assert.Equal((ushort) 0x8020, Sdl.GlAudioS32Sys);
                Assert.Equal((ushort) 0x8120, Sdl.GlAudioF32Sys);
            }
            else
            {
                Assert.Equal((ushort) 0x1010, Sdl.GlAudioU16Sys);
                Assert.Equal((ushort) 0x9010, Sdl.GlAudioS16Sys);
                Assert.Equal((ushort) 0x9020, Sdl.GlAudioS32Sys);
                Assert.Equal((ushort) 0x9120, Sdl.GlAudioF32Sys);
            }
        }

        /// <summary>Tests the GetVersion pure method.</summary>
        [Fact]
        public void GetVersion_Returns2018()
        {
            Version version = Sdl.GetVersion();

            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(18, version.patch);
        }

        /// <summary>Tests the GetGlCompiledVersion pure method.</summary>
        [Fact]
        public void GetGlCompiledVersion_Returns2018()
        {
            Assert.Equal(2018, Sdl.GetGlCompiledVersion());
        }

        /// <summary>Tests the Fourcc pure method.</summary>
        [Fact]
        public void Fourcc_EncodesLittleEndian()
        {
            Assert.Equal(0x44434241u, Sdl.Fourcc((byte) 'A', (byte) 'B', (byte) 'C', (byte) 'D'));
        }

        /// <summary>Tests the SdlDefinePixelFourcc public wrapper.</summary>
        [Fact]
        public void SdlDefinePixelFourcc_MatchesFourcc()
        {
            Assert.Equal(Sdl.Fourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'), Sdl.SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'));
        }

        /// <summary>Tests the Button pure method.</summary>
        [Fact]
        public void Button_PowersOfTwo()
        {
            Assert.Equal(1u, Sdl.Button(1));
            Assert.Equal(2u, Sdl.Button(2));
            Assert.Equal(4u, Sdl.Button(3));
            Assert.Equal(8u, Sdl.Button(4));
            Assert.Equal(16u, Sdl.Button(5));
        }

        /// <summary>Tests the window position helper methods.</summary>
        [Fact]
        public void WindowPosHelpers_Work()
        {
            Assert.Equal(0x1FFF0000 | 5, Sdl.WindowPosUndefinedDisplay(5));
            Assert.True(Sdl.WindowPosIsUndefined(0x1FFF0000));
            Assert.False(Sdl.WindowPosIsUndefined(100));
            Assert.Equal(0x2FFF0000 | 7, Sdl.WindowPosCenteredDisplay(7));
            Assert.True(Sdl.WindowPosIsCentered(0x2FFF0000));
            Assert.False(Sdl.WindowPosIsCentered(100));
        }

        /// <summary>Tests the ScanCodeToKeyCode pure method.</summary>
        [Fact]
        public void ScanCodeToKeyCode_OrsWithMask()
        {
            Assert.Equal((KeyCodes) 1073741828u, Sdl.ScanCodeToKeyCode((SdlScancode) 4));
        }

        /// <summary>Tests the audio pure helper methods.</summary>
        [Fact]
        public void SdlAudioHelpers_Work()
        {
            Assert.Equal((ushort) 0x10, Sdl.SdlAudioBitSize(0x8010));
            Assert.True(Sdl.SdlAudioIsFloat(0x8120));
            Assert.False(Sdl.SdlAudioIsFloat(0x0010));
            Assert.True(Sdl.SdlAudioIsBigEndian(0x9010));
            Assert.False(Sdl.SdlAudioIsBigEndian(0x8010));
            Assert.True(Sdl.SdlAudioIsSigned(0x8010));
            Assert.False(Sdl.SdlAudioIsSigned(0x0010));
            Assert.True(Sdl.SdlAudioIsInt(0x0010));
            Assert.False(Sdl.SdlAudioIsInt(0x8120));
            Assert.True(Sdl.SdlAudioIsLittleEndian(0x0010));
            Assert.False(Sdl.SdlAudioIsLittleEndian(0x1010));
            Assert.True(Sdl.SdlAudioIsUnsigned(0x0010));
            Assert.False(Sdl.SdlAudioIsUnsigned(0x8010));
        }
    }
}
