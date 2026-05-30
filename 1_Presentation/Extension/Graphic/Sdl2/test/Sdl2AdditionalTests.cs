// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Sdl2AdditionalTests.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Extension.Graphic.Sdl2.Sdl2Image;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Additional tests for Sdl2 module covering SdlImage, SdlTtf constants, and Sdl utility methods
    /// </summary>
    public class Sdl2AdditionalTests
    {
        #region SdlImage Tests

        /// <summary>
        ///     Tests that SdlImage.Version returns the expected hardcoded version
        /// </summary>
        [Fact]
        public void SdlImage_Version_ReturnsExpectedValue()
        {
            // Arrange & Act
            var version = SdlImage.Version();

            // Assert
            Assert.Equal(2, version.Major);
            Assert.Equal(0, version.Minor);
            Assert.Equal(6, version.Build);
        }

        #endregion

        #region SdlTtf Constants Tests

        /// <summary>
        ///     Tests that UnicodeBomNative has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_UnicodeBomNative_HasCorrectValue()
        {
            Assert.Equal(0xFEFF, SdlTtf.UnicodeBomNative);
        }

        /// <summary>
        ///     Tests that UnicodeBomSwapped has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_UnicodeBomSwapped_HasCorrectValue()
        {
            Assert.Equal(0xFFFE, SdlTtf.UnicodeBomSwapped);
        }

        /// <summary>
        ///     Tests that TtfStyleNormal has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfStyleNormal_HasCorrectValue()
        {
            Assert.Equal(0x00, SdlTtf.TtfStyleNormal);
        }

        /// <summary>
        ///     Tests that TtfStyleBold has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfStyleBold_HasCorrectValue()
        {
            Assert.Equal(0x01, SdlTtf.TtfStyleBold);
        }

        /// <summary>
        ///     Tests that TtfStyleItalic has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfStyleItalic_HasCorrectValue()
        {
            Assert.Equal(0x02, SdlTtf.TtfStyleItalic);
        }

        /// <summary>
        ///     Tests that TtfStyleUnderline has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfStyleUnderline_HasCorrectValue()
        {
            Assert.Equal(0x04, SdlTtf.TtfStyleUnderline);
        }

        /// <summary>
        ///     Tests that TtfStyleStrikethrough has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfStyleStrikethrough_HasCorrectValue()
        {
            Assert.Equal(0x08, SdlTtf.TtfStyleStrikethrough);
        }

        /// <summary>
        ///     Tests that TtfHintingNormal has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfHintingNormal_HasCorrectValue()
        {
            Assert.Equal(0, SdlTtf.TtfHintingNormal);
        }

        /// <summary>
        ///     Tests that TtfHintingLight has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfHintingLight_HasCorrectValue()
        {
            Assert.Equal(1, SdlTtf.TtfHintingLight);
        }

        /// <summary>
        ///     Tests that TtfHintingMono has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfHintingMono_HasCorrectValue()
        {
            Assert.Equal(2, SdlTtf.TtfHintingMono);
        }

        /// <summary>
        ///     Tests that TtfHintingNone has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfHintingNone_HasCorrectValue()
        {
            Assert.Equal(3, SdlTtf.TtfHintingNone);
        }

        /// <summary>
        ///     Tests that TtfHintingLightSubpixel has the correct value
        /// </summary>
        [Fact]
        public void SdlTtf_TtfHintingLightSubpixel_HasCorrectValue()
        {
            Assert.Equal(4, SdlTtf.TtfHintingLightSubpixel);
        }

        /// <summary>
        ///     Tests that all TTF style constants are distinct
        /// </summary>
        [Fact]
        public void SdlTtf_StyleConstants_AreDistinct()
        {
            Assert.NotEqual(SdlTtf.TtfStyleNormal, SdlTtf.TtfStyleBold);
            Assert.NotEqual(SdlTtf.TtfStyleNormal, SdlTtf.TtfStyleItalic);
            Assert.NotEqual(SdlTtf.TtfStyleNormal, SdlTtf.TtfStyleUnderline);
            Assert.NotEqual(SdlTtf.TtfStyleNormal, SdlTtf.TtfStyleStrikethrough);
            Assert.NotEqual(SdlTtf.TtfStyleBold, SdlTtf.TtfStyleItalic);
            Assert.NotEqual(SdlTtf.TtfStyleBold, SdlTtf.TtfStyleUnderline);
            Assert.NotEqual(SdlTtf.TtfStyleBold, SdlTtf.TtfStyleStrikethrough);
            Assert.NotEqual(SdlTtf.TtfStyleItalic, SdlTtf.TtfStyleUnderline);
            Assert.NotEqual(SdlTtf.TtfStyleItalic, SdlTtf.TtfStyleStrikethrough);
            Assert.NotEqual(SdlTtf.TtfStyleUnderline, SdlTtf.TtfStyleStrikethrough);
        }

        /// <summary>
        ///     Tests that TTF style constants form a bitmask pattern
        /// </summary>
        [Fact]
        public void SdlTtf_StyleConstants_FormBitmask()
        {
            // Each style is a power of 2, forming a bitmask
            Assert.Equal(0x01, SdlTtf.TtfStyleBold);
            Assert.Equal(0x02, SdlTtf.TtfStyleItalic);
            Assert.Equal(0x04, SdlTtf.TtfStyleUnderline);
            Assert.Equal(0x08, SdlTtf.TtfStyleStrikethrough);

            // Combined styles should work as bitmask
            int combined = SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic;
            Assert.Equal(0x03, combined);

            int full = SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic | SdlTtf.TtfStyleUnderline | SdlTtf.TtfStyleStrikethrough;
            Assert.Equal(0x0F, full);
        }

        #endregion

        #region Sdl Utility Method Tests

        /// <summary>
        ///     Tests that Sdl.Query has the correct value (-1)
        /// </summary>
        [Fact]
        public void Sdl_Query_HasCorrectValue()
        {
            Assert.Equal(-1, Sdl.Query);
        }

        /// <summary>
        ///     Tests that Sdl.Ignore has the correct value (0)
        /// </summary>
        [Fact]
        public void Sdl_Ignore_HasCorrectValue()
        {
            Assert.Equal(0, Sdl.Ignore);
        }

        /// <summary>
        ///     Tests that Sdl.Disable has the correct value (0)
        /// </summary>
        [Fact]
        public void Sdl_Disable_HasCorrectValue()
        {
            Assert.Equal(0, Sdl.Disable);
        }

        /// <summary>
        ///     Tests that Sdl.Enable has the correct value (1)
        /// </summary>
        [Fact]
        public void Sdl_Enable_HasCorrectValue()
        {
            Assert.Equal(1, Sdl.Enable);
        }

        /// <summary>
        ///     Tests that Sdl.TextEditingEventTextSize has the correct value (32)
        /// </summary>
        [Fact]
        public void Sdl_TextEditingEventTextSize_HasCorrectValue()
        {
            Assert.Equal(32, Sdl.TextEditingEventTextSize);
        }

        /// <summary>
        ///     Tests that Sdl.TextInputEventTextSize has the correct value (32)
        /// </summary>
        [Fact]
        public void Sdl_TextInputEventTextSize_HasCorrectValue()
        {
            Assert.Equal(32, Sdl.TextInputEventTextSize);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatUnknown has the correct value (0)
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatUnknown_HasCorrectValue()
        {
            Assert.Equal(0u, Sdl.PixelFormatUnknown);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatRgb888 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatRgb888_HasCorrectValue()
        {
            // RGB888 is 0x162D6240 (SDL_PIXELFORMAT_RGB888)
            Assert.NotEqual(0u, Sdl.PixelFormatRgb888);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatBgr888 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatBgr888_HasCorrectValue()
        {
            // BGR888 is 0x162C6240 (SDL_PIXELFORMAT_BGR888)
            Assert.NotEqual(0u, Sdl.PixelFormatBgr888);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatRgb565 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatRgb565_HasCorrectValue()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatRgb565);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatBgr565 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatBgr565_HasCorrectValue()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatBgr565);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatArgb4444 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatArgb4444_HasCorrectValue()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatArgb4444);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatRgba4444 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatRgba4444_HasCorrectValue()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatRgba4444);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatArgb1555 has the correct value
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatArgb1555_HasCorrectValue()
        {
            Assert.NotEqual(0u, Sdl.PixelFormatArgb1555);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatRgb565 and PixelFormatBgr565 are different
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatRgb565AndBgr565_AreDifferent()
        {
            Assert.NotEqual(Sdl.PixelFormatRgb565, Sdl.PixelFormatBgr565);
        }

        /// <summary>
        ///     Tests that Sdl.PixelFormatRgb888 and PixelFormatBgr888 are different
        /// </summary>
        [Fact]
        public void Sdl_PixelFormatRgb888AndBgr888_AreDifferent()
        {
            Assert.NotEqual(Sdl.PixelFormatRgb888, Sdl.PixelFormatBgr888);
        }

        #endregion

        #region Sdl Button Method Tests

        /// <summary>
        ///     Tests that Sdl.Button(1) returns 1 (left button mask)
        /// </summary>
        [Fact]
        public void Sdl_Button_One_ReturnsOne()
        {
            Assert.Equal(1u, Sdl.Button(1));
        }

        /// <summary>
        ///     Tests that Sdl.Button produces powers of 2 for valid inputs (1-8)
        /// </summary>
        [Theory]
        [InlineData(1u, 1u)]
        [InlineData(2u, 2u)]
        [InlineData(3u, 4u)]
        [InlineData(4u, 8u)]
        [InlineData(5u, 16u)]
        [InlineData(6u, 32u)]
        [InlineData(7u, 64u)]
        [InlineData(8u, 128u)]
        public void Sdl_Button_ProducesPowerOfTwo(uint input, uint expected)
        {
            Assert.Equal(expected, Sdl.Button(input));
        }

        /// <summary>
        ///     Tests that Sdl.Button(0) returns 0x80000000 due to shift-by-negative behavior
        /// </summary>
        [Fact]
        public void Sdl_Button_Zero_ReturnsMaxInt()
        {
            // Button(0) = 1 << (0-1) = 1 << -1, which wraps to 1 << 31 = 0x80000000
            Assert.Equal(0x80000000u, Sdl.Button(0));
        }

        #endregion

        #region Sdl Fourcc Method Tests

        /// <summary>
        ///     Tests that Sdl.Fourcc with 'SDL ' produces the correct value
        /// </summary>
        [Fact]
        public void Sdl_Fourcc_SDLSpace_ReturnsCorrectValue()
        {
            uint result = Sdl.Fourcc((byte) 'S', (byte) 'D', (byte) 'L', (byte) ' ');
            Assert.Equal(0x204C4453u, result);
        }

        /// <summary>
        ///     Tests that Sdl.Fourcc with 'IYUV' produces the correct value
        /// </summary>
        [Fact]
        public void Sdl_Fourcc_IYUV_ReturnsCorrectValue()
        {
            uint result = Sdl.Fourcc((byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V');
            Assert.Equal(0x56555949u, result);
        }

        /// <summary>
        ///     Tests that Sdl.Fourcc with all zeros produces zero
        /// </summary>
        [Fact]
        public void Sdl_Fourcc_AllZeros_ReturnsZero()
        {
            Assert.Equal(0u, Sdl.Fourcc(0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that Sdl.Fourcc with all 0xFF produces 0xFFFFFFFF
        /// </summary>
        [Fact]
        public void Sdl_Fourcc_AllFF_ReturnsFFFFFFFF()
        {
            Assert.Equal(0xFFFFFFFFu, Sdl.Fourcc(0xFF, 0xFF, 0xFF, 0xFF));
        }

        #endregion

        #region Sdl WindowPos Method Tests

        /// <summary>
        ///     Tests that Sdl.WindowPosUndefinedDisplay and WindowPosIsUndefined are consistent for non-negative values
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Sdl_WindowPosUndefinedDisplay_IsConsistent(int x)
        {
            int undefinedPos = Sdl.WindowPosUndefinedDisplay(x);
            Assert.True(Sdl.WindowPosIsUndefined(undefinedPos));
            Assert.False(Sdl.WindowPosIsUndefined(x));
        }

        /// <summary>
        ///     Tests that Sdl.WindowPosCenteredDisplay and WindowPosIsCentered are consistent for non-negative values
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Sdl_WindowPosCenteredDisplay_IsConsistent(int x)
        {
            int centeredPos = Sdl.WindowPosCenteredDisplay(x);
            Assert.True(Sdl.WindowPosIsCentered(centeredPos));
            Assert.False(Sdl.WindowPosIsCentered(x));
        }

        /// <summary>
        ///     Tests that WindowPosUndefined and WindowPosCentered are mutually exclusive
        /// </summary>
        [Fact]
        public void Sdl_WindowPosUndefinedAndCentered_AreMutuallyExclusive()
        {
            int undefinedPos = Sdl.WindowPosUndefinedDisplay(0);
            int centeredPos = Sdl.WindowPosCenteredDisplay(0);

            Assert.True(Sdl.WindowPosIsUndefined(undefinedPos));
            Assert.False(Sdl.WindowPosIsCentered(undefinedPos));

            Assert.True(Sdl.WindowPosIsCentered(centeredPos));
            Assert.False(Sdl.WindowPosIsUndefined(centeredPos));
        }

        #endregion

        #region Sdl GetVersion Tests

        /// <summary>
        ///     Tests that Sdl.GetVersion returns a valid version structure
        /// </summary>
        [Fact]
        public void Sdl_GetVersion_ReturnsValidStructure()
        {
            var version = Sdl.GetVersion();

            Assert.True(version.major >= 0);
            Assert.True(version.minor >= 0);
            Assert.True(version.patch >= 0);
        }

        /// <summary>
        ///     Tests that Sdl.GetGlCompiledVersion matches GetVersion major.minor
        /// </summary>
        [Fact]
        public void Sdl_GetGlCompiledVersion_MatchesGetVersion()
        {
            var version = Sdl.GetVersion();
            int compiledVersion = Sdl.GetGlCompiledVersion();

            // GetGlCompiledVersion returns major * 1000 + minor * 100 + patch
            int expected = version.major * 1000 + version.minor * 100 + version.patch;
            Assert.Equal(expected, compiledVersion);
        }

        #endregion
    }
}
