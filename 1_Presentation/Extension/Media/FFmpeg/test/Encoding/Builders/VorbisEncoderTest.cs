// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VorbisEncoderTest.cs
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
    ///     The vorbis encoder test class
    /// </summary>
    /// <seealso cref="VorbisEncoder" />
    public class VorbisEncoderTest
    {
        /// <summary>
        ///     Tests that vorbis encoder constructor should create instance with default cqp
        /// </summary>
        [Fact]
        public void VorbisEncoder_Constructor_ShouldCreateInstanceWithDefaultCqp()
        {
            // Arrange & Act
            VorbisEncoder encoder = new VorbisEncoder();

            // Assert
            Assert.NotNull(encoder);
            Assert.Contains("-q:a", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder name property should return libvorbis
        /// </summary>
        [Fact]
        public void VorbisEncoder_NameProperty_ShouldReturnLibvorbis()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();

            // Act
            string name = encoder.Name;

            // Assert
            Assert.Equal("libvorbis", name);
        }

        /// <summary>
        ///     Tests that vorbis encoder default format should be ogg
        /// </summary>
        [Fact]
        public void VorbisEncoder_DefaultFormat_ShouldBeOgg()
        {
            // Arrange & Act
            VorbisEncoder encoder = new VorbisEncoder();

            // Assert
            Assert.Equal("ogg", encoder.Format);
        }

        /// <summary>
        ///     Tests that vorbis encoder channel count property should be settable
        /// </summary>
        [Fact]
        public void VorbisEncoder_ChannelCountProperty_ShouldBeSettable()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            int channelCount = 2;

            // Act
            encoder.ChannelCount = channelCount;

            // Assert
            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that vorbis encoder sample rate property should be settable
        /// </summary>
        [Fact]
        public void VorbisEncoder_SampleRateProperty_ShouldBeSettable()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            int sampleRate = 48000;

            // Act
            encoder.SampleRate = sampleRate;

            // Assert
            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that vorbis encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void VorbisEncoder_SetCbr_ShouldSetQualitySettings()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            string bitrate = "192k";

            // Act
            encoder.SetCbr(bitrate);

            // Assert
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("192k", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder set cqp with custom quality should work
        /// </summary>
        [Fact]
        public void VorbisEncoder_SetCqpWithCustomQuality_ShouldWork()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            float q = 5.5f;

            // Act
            encoder.SetCqp(q);

            // Assert
            Assert.Contains("-q:a", encoder.CurrentQualitySettings);
            Assert.Contains("5.50", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder create should return encoder options
        /// </summary>
        [Fact]
        public void VorbisEncoder_Create_ShouldReturnEncoderOptions()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("ogg", options.Format);
            Assert.Equal("libvorbis", options.EncoderName);
        }

        /// <summary>
        ///     Tests that vorbis encoder create should include channel count when set
        /// </summary>
        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.ChannelCount = 2;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that vorbis encoder create should include sample rate when set
        /// </summary>
        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeSampleRateWhenSet()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.SampleRate = 48000;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("48000", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that vorbis encoder set cqp with boundary values should work
        /// </summary>
        [Fact]
        public void VorbisEncoder_SetCqpWithBoundaryValues_ShouldWork()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();

            // Act & Assert
            encoder.SetCqp(-1);
            Assert.Contains("-1.00", encoder.CurrentQualitySettings);

            encoder.SetCqp(10);
            Assert.Contains("10.00", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void VorbisEncoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            // Arrange & Act
            VorbisEncoder encoder = new VorbisEncoder();

            // Assert
            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }
    }
}

