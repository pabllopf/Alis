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

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the Sdl static class and constants.
    /// </summary>
    public class SdlTest
    {
        /// <summary>
        ///     Tests that constant TextEditingEventTextSize has correct value.
        /// </summary>
        [Fact]
        public void TextEditingEventTextSize_HasCorrectValue()
        {
            // Assert
            Assert.Equal(32, Sdl.TextEditingEventTextSize);
        }

        /// <summary>
        ///     Tests that constant TextInputEventTextSize has correct value.
        /// </summary>
        [Fact]
        public void TextInputEventTextSize_HasCorrectValue()
        {
            // Assert
            Assert.Equal(32, Sdl.TextInputEventTextSize);
        }

        /// <summary>
        ///     Tests that Query constant has correct value.
        /// </summary>
        [Fact]
        public void Query_HasCorrectValue()
        {
            // Assert
            Assert.Equal(-1, Sdl.Query);
        }

        /// <summary>
        ///     Tests that Ignore constant has correct value.
        /// </summary>
        [Fact]
        public void Ignore_HasCorrectValue()
        {
            // Assert
            Assert.Equal(0, Sdl.Ignore);
        }

        /// <summary>
        ///     Tests that Disable constant has correct value.
        /// </summary>
        [Fact]
        public void Disable_HasCorrectValue()
        {
            // Assert
            Assert.Equal(0, Sdl.Disable);
        }

        /// <summary>
        ///     Tests that Enable constant has correct value.
        /// </summary>
        [Fact]
        public void Enable_HasCorrectValue()
        {
            // Assert
            Assert.Equal(1, Sdl.Enable);
        }

        /// <summary>
        ///     Tests the Button method calculation.
        /// </summary>
        [Fact]
        public void Button_WithValidInput_CalculatesCorrectly()
        {
            // Arrange
            uint button = 1;

            // Act
            uint result = Sdl.Button(button);

            // Assert
            Assert.Equal(1u, result);
        }

        /// <summary>
        ///     Tests the Button method with different values.
        /// </summary>
        [Theory, InlineData(1u, 1u), InlineData(2u, 2u), InlineData(3u, 4u), InlineData(4u, 8u), InlineData(5u, 16u)]
        public void Button_WithDifferentValues_CalculatesButtonMask(uint input, uint expected)
        {
            // Act
            uint result = Sdl.Button(input);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests the Fourcc method with valid ASCII characters.
        /// </summary>
        [Fact]
        public void Fourcc_WithValidAsciiCharacters_ReturnsCorrectValue()
        {
            // Arrange
            byte a = (byte) 'Y';
            byte b = (byte) 'V';
            byte c = (byte) '1';
            byte d = (byte) '2';

            // Act
            uint result = Sdl.Fourcc(a, b, c, d);

            // Assert
            Assert.Equal((uint) (a | (b << 8) | (c << 16) | (d << 24)), result);
        }

        /// <summary>
        ///     Tests the Fourcc method with different values.
        /// </summary>
        [Theory, InlineData((byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'), InlineData(0, 1, 2, 3)]
        public void Fourcc_WithDifferentValues_ReturnsCorrectCombination(byte a, byte b, byte c, byte d)
        {
            // Act
            uint result = Sdl.Fourcc(a, b, c, d);

            // Assert
            uint expected = (uint) (a | (b << 8) | (c << 16) | (d << 24));
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests the GetGlCompiledVersion method.
        /// </summary>
        [Fact]
        public void GetGlCompiledVersion_ReturnsExpectedValue()
        {
            // Act
            int version = Sdl.GetGlCompiledVersion();

            // Assert
            Assert.Equal(2018, version);
        }

        /// <summary>
        ///     Tests the GetVersion method.
        /// </summary>
        [Fact]
        public void GetVersion_ReturnsVersionStructure()
        {
            // Act
            Version version = Sdl.GetVersion();

            // Assert
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(18, version.patch);
        }

        /// <summary>
        ///     Tests WindowPosUndefinedDisplay method.
        /// </summary>
        [Fact]
        public void WindowPosUndefinedDisplay_WithValidInput_ReturnsCorrectValue()
        {
            // Act
            int result = Sdl.WindowPosUndefinedDisplay(0);

            // Assert
            Assert.NotEqual(0, result);
        }

        /// <summary>
        ///     Tests WindowPosIsUndefined method.
        /// </summary>
        [Fact]
        public void WindowPosIsUndefined_WithUndefinedPosition_ReturnsTrue()
        {
            // Arrange
            int undefinedPos = Sdl.WindowPosUndefinedDisplay(0);

            // Act
            bool result = Sdl.WindowPosIsUndefined(undefinedPos);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests WindowPosIsUndefined with defined position.
        /// </summary>
        [Fact]
        public void WindowPosIsUndefined_WithDefinedPosition_ReturnsFalse()
        {
            // Act
            bool result = Sdl.WindowPosIsUndefined(100);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests WindowPosCenteredDisplay method.
        /// </summary>
        [Fact]
        public void WindowPosCenteredDisplay_WithValidInput_ReturnsCorrectValue()
        {
            // Act
            int result = Sdl.WindowPosCenteredDisplay(0);

            // Assert
            Assert.NotEqual(0, result);
        }

        /// <summary>
        ///     Tests WindowPosIsCentered method.
        /// </summary>
        [Fact]
        public void WindowPosIsCentered_WithCenteredPosition_ReturnsTrue()
        {
            // Arrange
            int centeredPos = Sdl.WindowPosCenteredDisplay(0);

            // Act
            bool result = Sdl.WindowPosIsCentered(centeredPos);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests WindowPosIsCentered with non-centered position.
        /// </summary>
        [Fact]
        public void WindowPosIsCentered_WithNonCenteredPosition_ReturnsFalse()
        {
            // Act
            bool result = Sdl.WindowPosIsCentered(100);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests ButtonLeft constant value.
        /// </summary>
        [Fact]
        public void ButtonLeft_HasCorrectValue()
        {
            // Assert
            Assert.Equal(1u, Sdl.ButtonLeft);
        }

        /// <summary>
        ///     Tests ButtonMiddle constant value.
        /// </summary>
        [Fact]
        public void ButtonMiddle_HasCorrectValue()
        {
            // Assert
            Assert.Equal(2u, Sdl.ButtonMiddle);
        }

        /// <summary>
        ///     Tests ButtonRight constant value.
        /// </summary>
        [Fact]
        public void ButtonRight_HasCorrectValue()
        {
            // Assert
            Assert.Equal(3u, Sdl.ButtonRight);
        }

        /// <summary>
        ///     Tests ButtonX1 constant value.
        /// </summary>
        [Fact]
        public void ButtonX1_HasCorrectValue()
        {
            // Assert
            Assert.Equal(4u, Sdl.ButtonX1);
        }

        /// <summary>
        ///     Tests ButtonX2 constant value.
        /// </summary>
        [Fact]
        public void ButtonX2_HasCorrectValue()
        {
            // Assert
            Assert.Equal(5u, Sdl.ButtonX2);
        }

        /// <summary>
        ///     Tests audio constant values.
        /// </summary>
        [Fact]
        public void AudioConstants_HaveCorrectValues()
        {
            // Assert
            Assert.Equal(0xFFu, Sdl.AudioMaskBitSize);
            Assert.Equal(0x0008u, Sdl.AudioU8);
            Assert.Equal(0x8008u, Sdl.AudioS8);
            Assert.Equal(0x0010u, Sdl.AudioU16Lsb);
            Assert.Equal(0x8010u, Sdl.AudioS16Lsb);
        }

        /// <summary>
        ///     Tests MixMaxVolume constant value.
        /// </summary>
        [Fact]
        public void MixMaxVolume_HasCorrectValue()
        {
            // Assert
            Assert.Equal(128, Sdl.MixMaxVolume);
        }

        /// <summary>
        ///     Tests AndroidExternalStorageRead constant value.
        /// </summary>
        [Fact]
        public void AndroidExternalStorageRead_HasCorrectValue()
        {
            // Assert
            Assert.Equal(0x01, Sdl.AndroidExternalStorageRead);
        }

        /// <summary>
        ///     Tests AndroidExternalStorageWrite constant value.
        /// </summary>
        [Fact]
        public void AndroidExternalStorageWrite_HasCorrectValue()
        {
            // Assert
            Assert.Equal(0x02, Sdl.AndroidExternalStorageWrite);
        }


        /// <summary>
        ///     Tests SdlAudioBitSize helper function.
        /// </summary>
        [Fact]
        public void SdlAudioBitSize_WithValidInput_ExtractsBitSize()
        {
            // Arrange
            ushort format = 0x00FF;

            // Act
            ushort result = Sdl.SdlAudioBitSize(format);

            // Assert
            Assert.Equal(0xFF, result);
        }

        /// <summary>
        ///     Tests SdlAudioIsFloat helper function.
        /// </summary>
        [Fact]
        public void SdlAudioIsFloat_WithFloatFormat_ReturnsTrue()
        {
            // Arrange
            ushort format = Sdl.AudioF32Lsb;

            // Act
            bool result = Sdl.SdlAudioIsFloat(format);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests SdlAudioIsInt helper function.
        /// </summary>
        [Fact]
        public void SdlAudioIsInt_WithIntegerFormat_ReturnsTrue()
        {
            // Arrange
            ushort format = Sdl.AudioS16Lsb;

            // Act
            bool result = Sdl.SdlAudioIsInt(format);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests SdlAudioIsSigned helper function.
        /// </summary>
        [Fact]
        public void SdlAudioIsSigned_WithSignedFormat_ReturnsTrue()
        {
            // Arrange
            ushort format = Sdl.AudioS16Lsb;

            // Act
            bool result = Sdl.SdlAudioIsSigned(format);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests SdlAudioIsUnsigned helper function.
        /// </summary>
        [Fact]
        public void SdlAudioIsUnsigned_WithUnsignedFormat_ReturnsTrue()
        {
            // Arrange
            ushort format = Sdl.AudioU16Lsb;

            // Act
            bool result = Sdl.SdlAudioIsUnsigned(format);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests PixelFormatUnknown constant value.
        /// </summary>
        [Fact]
        public void PixelFormatUnknown_HasCorrectValue()
        {
            // Assert
            Assert.Equal(0u, Sdl.PixelFormatUnknown);
        }

        /// <summary>
        ///     Tests that pixel format constants are not zero.
        /// </summary>
        [Fact]
        public void PixelFormats_AreNotZero()
        {
            // Assert
            Assert.NotEqual(0u, Sdl.PixelFormatIndex8);
            Assert.NotEqual(0u, Sdl.PixelFormatRgb24);
            Assert.NotEqual(0u, Sdl.PixelFormatRgba8888);
        }

        /// <summary>
        ///     Tests button mask values.
        /// </summary>
        [Fact]
        public void ButtonMasks_HaveCorrectValues()
        {
            // Assert
            Assert.Equal(Sdl.Button(Sdl.ButtonLeft), Sdl.GlButtonLMask);
            Assert.Equal(Sdl.Button(Sdl.ButtonMiddle), Sdl.GlButtonMMask);
            Assert.Equal(Sdl.Button(Sdl.ButtonRight), Sdl.GlButtonRMask);
        }

        /// <summary>
        ///     Tests SdlDefinePixelFourcc method.
        /// </summary>
        [Fact]
        public void SdlDefinePixelFourcc_WithValidCharacters_ReturnsFourccValue()
        {
            // Act
            uint fourcc = Sdl.SdlDefinePixelFourcc((byte) 'Y', (byte) 'V', (byte) '1', (byte) '2');

            // Assert
            Assert.Equal(Sdl.PixelFormatYv12, fourcc);
        }
    }
}