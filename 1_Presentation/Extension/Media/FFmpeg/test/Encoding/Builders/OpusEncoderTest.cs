// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OpusEncoderTest.cs
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
    ///     The opus encoder test class
    /// </summary>
    /// <seealso cref="OpusEncoder" />
    public class OpusEncoderTest
    {
        /// <summary>
        ///     Tests that opus encoder constructor should create instance with default vbr
        /// </summary>
        [Fact]
        public void OpusEncoder_Constructor_ShouldCreateInstanceWithDefaultVbr()
        {
            // Arrange & Act
            OpusEncoder encoder = new OpusEncoder();

            // Assert
            Assert.NotNull(encoder);
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr on", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder name property should return libopus
        /// </summary>
        [Fact]
        public void OpusEncoder_NameProperty_ShouldReturnLibopus()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();

            // Act
            string name = encoder.Name;

            // Assert
            Assert.Equal("libopus", name);
        }

        /// <summary>
        ///     Tests that opus encoder default format should be ogg
        /// </summary>
        [Fact]
        public void OpusEncoder_DefaultFormat_ShouldBeOgg()
        {
            // Arrange & Act
            OpusEncoder encoder = new OpusEncoder();

            // Assert
            Assert.Equal("ogg", encoder.Format);
        }

        /// <summary>
        ///     Tests that opus encoder channel count property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_ChannelCountProperty_ShouldBeSettable()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            int channelCount = 2;

            // Act
            encoder.ChannelCount = channelCount;

            // Assert
            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that opus encoder sample rate property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_SampleRateProperty_ShouldBeSettable()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            int sampleRate = 48000;

            // Act
            encoder.SampleRate = sampleRate;

            // Assert
            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that opus encoder codec application property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_CodecApplicationProperty_ShouldBeSettable()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            OpusEncoder.Application application = OpusEncoder.Application.VoIp;

            // Act
            encoder.CodecApplication = application;

            // Assert
            Assert.Equal(application, encoder.CodecApplication);
        }

        /// <summary>
        ///     Tests that opus encoder default application should be audio
        /// </summary>
        [Fact]
        public void OpusEncoder_DefaultApplication_ShouldBeAudio()
        {
            // Arrange & Act
            OpusEncoder encoder = new OpusEncoder();

            // Assert
            Assert.Equal(OpusEncoder.Application.Audio, encoder.CodecApplication);
        }

        /// <summary>
        ///     Tests that opus encoder compression level property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_CompressionLevelProperty_ShouldBeSettable()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            int compressionLevel = 5;

            // Act
            encoder.CompressionLevel = compressionLevel;

            // Assert
            Assert.Equal(compressionLevel, encoder.CompressionLevel);
        }

        /// <summary>
        ///     Tests that opus encoder default compression level should be 10
        /// </summary>
        [Fact]
        public void OpusEncoder_DefaultCompressionLevel_ShouldBe10()
        {
            // Arrange & Act
            OpusEncoder encoder = new OpusEncoder();

            // Assert
            Assert.Equal(10, encoder.CompressionLevel);
        }

        /// <summary>
        ///     Tests that opus encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void OpusEncoder_SetCbr_ShouldSetQualitySettings()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            string bitrate = "128k";

            // Act
            encoder.SetCbr(bitrate);

            // Assert
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("128k", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr off", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder set vbr should set quality settings
        /// </summary>
        [Fact]
        public void OpusEncoder_SetVbr_ShouldSetQualitySettings()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            string bitrate = "96k";

            // Act
            encoder.SetVbr(bitrate);

            // Assert
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("96k", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr on", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder set cvbr should set quality settings
        /// </summary>
        [Fact]
        public void OpusEncoder_SetCvbr_ShouldSetQualitySettings()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            string bitrate = "128k";

            // Act
            encoder.SetCvbr(bitrate);

            // Assert
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("128k", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr constrained", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder create should return encoder options
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldReturnEncoderOptions()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("ogg", options.Format);
            Assert.Equal("libopus", options.EncoderName);
        }

        /// <summary>
        ///     Tests that opus encoder create should include application in arguments
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldIncludeApplicationInArguments()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            encoder.CodecApplication = OpusEncoder.Application.VoIp;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-application", options.EncoderArguments);
            Assert.Contains("voip", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that opus encoder create should include compression level in arguments
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldIncludeCompressionLevelInArguments()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            encoder.CompressionLevel = 8;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-compression_level", options.EncoderArguments);
            Assert.Contains("8", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that opus encoder create should include channel count when set
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();
            encoder.ChannelCount = 2;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that opus encoder application enum should have three values
        /// </summary>
        [Fact]
        public void OpusEncoder_ApplicationEnum_ShouldHaveThreeValues()
        {
            // Arrange & Act
            OpusEncoder.Application[] values = (OpusEncoder.Application[])System.Enum.GetValues(typeof(OpusEncoder.Application));

            // Assert
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that opus encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void OpusEncoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            // Arrange & Act
            OpusEncoder encoder = new OpusEncoder();

            // Assert
            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }

        /// <summary>
        ///     Tests that opus encoder compression level should support valid range
        /// </summary>
        [Fact]
        public void OpusEncoder_CompressionLevel_ShouldSupportValidRange()
        {
            // Arrange
            OpusEncoder encoder = new OpusEncoder();

            // Act & Assert
            encoder.CompressionLevel = 0;
            Assert.Equal(0, encoder.CompressionLevel);

            encoder.CompressionLevel = 10;
            Assert.Equal(10, encoder.CompressionLevel);
        }
    }
}

