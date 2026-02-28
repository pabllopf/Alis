// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AACEncoderTest.cs
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

using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The aac encoder test class
    /// </summary>
    /// <seealso cref="AacEncoder" />
    public class AacEncoderTest
    {
        /// <summary>
        ///     Tests that aac encoder constructor should create instance with default cbr
        /// </summary>
        [Fact]
        public void AacEncoder_Constructor_ShouldCreateInstanceWithDefaultCbr()
        {
            // Arrange & Act
            AacEncoder encoder = new AacEncoder();

            // Assert
            Assert.NotNull(encoder);
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that aac encoder name property should return aac
        /// </summary>
        [Fact]
        public void AacEncoder_NameProperty_ShouldReturnAac()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();

            // Act
            string name = encoder.Name;

            // Assert
            Assert.Equal("aac", name);
        }

        /// <summary>
        ///     Tests that aac encoder default format should be m 4 a
        /// </summary>
        [Fact]
        public void AacEncoder_DefaultFormat_ShouldBeM4a()
        {
            // Arrange & Act
            AacEncoder encoder = new AacEncoder();

            // Assert
            Assert.Equal("m4a", encoder.Format);
        }

        /// <summary>
        ///     Tests that aac encoder format property should be settable
        /// </summary>
        [Fact]
        public void AacEncoder_FormatProperty_ShouldBeSettable()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();
            string format = "mp4";

            // Act
            encoder.Format = format;

            // Assert
            Assert.Equal(format, encoder.Format);
        }

        /// <summary>
        ///     Tests that aac encoder channel count property should be settable
        /// </summary>
        [Fact]
        public void AacEncoder_ChannelCountProperty_ShouldBeSettable()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();
            int channelCount = 2;

            // Act
            encoder.ChannelCount = channelCount;

            // Assert
            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that aac encoder default channel count should be null
        /// </summary>
        [Fact]
        public void AacEncoder_DefaultChannelCount_ShouldBeNull()
        {
            // Arrange & Act
            AacEncoder encoder = new AacEncoder();

            // Assert
            Assert.Null(encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that aac encoder sample rate property should be settable
        /// </summary>
        [Fact]
        public void AacEncoder_SampleRateProperty_ShouldBeSettable()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();
            int sampleRate = 44100;

            // Act
            encoder.SampleRate = sampleRate;

            // Assert
            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that aac encoder default sample rate should be null
        /// </summary>
        [Fact]
        public void AacEncoder_DefaultSampleRate_ShouldBeNull()
        {
            // Arrange & Act
            AacEncoder encoder = new AacEncoder();

            // Assert
            Assert.Null(encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that aac encoder set cbr with custom bitrate should work
        /// </summary>
        [Fact]
        public void AacEncoder_SetCbrWithCustomBitrate_ShouldWork()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();
            string bitrate = "256k";

            // Act
            encoder.SetCbr(bitrate);

            // Assert
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("256k", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that aac encoder set cbr default should be 128 k
        /// </summary>
        [Fact]
        public void AacEncoder_SetCbrDefault_ShouldBe128k()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();

            // Act
            encoder.SetCbr();

            // Assert
            Assert.Contains("128k", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that aac encoder create should return encoder options
        /// </summary>
        [Fact]
        public void AacEncoder_Create_ShouldReturnEncoderOptions()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("m4a", options.Format);
            Assert.Equal("aac", options.EncoderName);
        }

        /// <summary>
        ///     Tests that aac encoder create should include channel count when set
        /// </summary>
        [Fact]
        public void AacEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();
            encoder.ChannelCount = 2;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that aac encoder create should include sample rate when set
        /// </summary>
        [Fact]
        public void AacEncoder_Create_ShouldIncludeSampleRateWhenSet()
        {
            // Arrange
            AacEncoder encoder = new AacEncoder();
            encoder.SampleRate = 48000;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("48000", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that aac encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void AacEncoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            // Arrange & Act
            AacEncoder encoder = new AacEncoder();

            // Assert
            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }

        /// <summary>
        ///     Tests that aac encoder set cbr with different bitrates should work
        /// </summary>
        [Fact]
        public void AacEncoder_SetCbrWithDifferentBitrates_ShouldWork()
        {
            // Arrange & Act
            AacEncoder encoder64k = new AacEncoder();
            encoder64k.SetCbr("64k");

            AacEncoder encoder192k = new AacEncoder();
            encoder192k.SetCbr("192k");

            AacEncoder encoder320k = new AacEncoder();
            encoder320k.SetCbr("320k");

            // Assert
            Assert.Contains("64k", encoder64k.CurrentQualitySettings);
            Assert.Contains("192k", encoder192k.CurrentQualitySettings);
            Assert.Contains("320k", encoder320k.CurrentQualitySettings);
        }
    }
}