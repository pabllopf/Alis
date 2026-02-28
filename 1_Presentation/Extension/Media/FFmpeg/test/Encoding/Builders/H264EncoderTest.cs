// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:H264EncoderTest.cs
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
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The h 264 encoder test class
    /// </summary>
    /// <seealso cref="H264Encoder" />
    public class H264EncoderTest
    {
        /// <summary>
        ///     Tests that h 264 encoder constructor should create instance with default cqp
        /// </summary>
        [Fact]
        public void H264Encoder_Constructor_ShouldCreateInstanceWithDefaultCqp()
        {
            // Arrange & Act
            H264Encoder encoder = new H264Encoder();

            // Assert
            Assert.NotNull(encoder);
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that h 264 encoder name property should return libx 264
        /// </summary>
        [Fact]
        public void H264Encoder_NameProperty_ShouldReturnLibx264()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            string name = encoder.Name;

            // Assert
            Assert.Equal("libx264", name);
        }

        /// <summary>
        ///     Tests that h 264 encoder format property should be settable
        /// </summary>
        [Fact]
        public void H264Encoder_FormatProperty_ShouldBeSettable()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            string format = "mkv";

            // Act
            encoder.Format = format;

            // Assert
            Assert.Equal(format, encoder.Format);
        }

        /// <summary>
        ///     Tests that h 264 encoder default format should be mp 4
        /// </summary>
        [Fact]
        public void H264Encoder_DefaultFormat_ShouldBeMp4()
        {
            // Arrange & Act
            H264Encoder encoder = new H264Encoder();

            // Assert
            Assert.Equal("mp4", encoder.Format);
        }

        /// <summary>
        ///     Tests that h 264 encoder encoder preset property should be settable
        /// </summary>
        [Fact]
        public void H264Encoder_EncoderPresetProperty_ShouldBeSettable()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            Preset preset = Preset.Fast;

            // Act
            encoder.EncoderPreset = preset;

            // Assert
            Assert.Equal(preset, encoder.EncoderPreset);
        }

        /// <summary>
        ///     Tests that h 264 encoder default preset should be medium
        /// </summary>
        [Fact]
        public void H264Encoder_DefaultPreset_ShouldBeMedium()
        {
            // Arrange & Act
            H264Encoder encoder = new H264Encoder();

            // Assert
            Assert.Equal(Preset.Medium, encoder.EncoderPreset);
        }

        /// <summary>
        ///     Tests that h 264 encoder encoder tune property should be settable
        /// </summary>
        [Fact]
        public void H264Encoder_EncoderTuneProperty_ShouldBeSettable()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            Tune tune = Tune.Film;

            // Act
            encoder.EncoderTune = tune;

            // Assert
            Assert.Equal(tune, encoder.EncoderTune);
        }

        /// <summary>
        ///     Tests that h 264 encoder default tune should be auto
        /// </summary>
        [Fact]
        public void H264Encoder_DefaultTune_ShouldBeAuto()
        {
            // Arrange & Act
            H264Encoder encoder = new H264Encoder();

            // Assert
            Assert.Equal(Tune.Auto, encoder.EncoderTune);
        }

        /// <summary>
        ///     Tests that h 264 encoder encoder ffmpeg profile property should be settable
        /// </summary>
        [Fact]
        public void H264Encoder_EncoderFFmpegProfileProperty_ShouldBeSettable()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            FFmpegProfile profile = FFmpegProfile.High;

            // Act
            encoder.EncoderFFmpegProfile = profile;

            // Assert
            Assert.Equal(profile, encoder.EncoderFFmpegProfile);
        }

        /// <summary>
        ///     Tests that h 264 encoder default profile should be auto
        /// </summary>
        [Fact]
        public void H264Encoder_DefaultProfile_ShouldBeAuto()
        {
            // Arrange & Act
            H264Encoder encoder = new H264Encoder();

            // Assert
            Assert.Equal(FFmpegProfile.Auto, encoder.EncoderFFmpegProfile);
        }

        /// <summary>
        ///     Tests that h 264 encoder set cqp should set quality settings
        /// </summary>
        [Fact]
        public void H264Encoder_SetCqp_ShouldSetQualitySettings()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            float crf = 18.5f;

            // Act
            encoder.SetCqp(crf);

            // Assert
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
            Assert.Contains("18.50", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that h 264 encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void H264Encoder_SetCbr_ShouldSetQualitySettings()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            string bitrate = "5M";
            string bufsize = "10M";

            // Act
            encoder.SetCbr(bitrate, bufsize);

            // Assert
            Assert.Contains("-b:v", encoder.CurrentQualitySettings);
            Assert.Contains("5M", encoder.CurrentQualitySettings);
            Assert.Contains("10M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that h 264 encoder set vbv should set quality settings
        /// </summary>
        [Fact]
        public void H264Encoder_SetVbv_ShouldSetQualitySettings()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            float crf = 23;
            string maxBitrate = "5M";
            string bufsize = "10M";

            // Act
            encoder.SetVbv(crf, maxBitrate, bufsize);

            // Assert
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
            Assert.Contains("-maxrate", encoder.CurrentQualitySettings);
            Assert.Contains("5M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that h 264 encoder set abr should set quality settings
        /// </summary>
        [Fact]
        public void H264Encoder_SetAbr_ShouldSetQualitySettings()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            string avgBitrate = "4M";

            // Act
            encoder.SetAbr(avgBitrate);

            // Assert
            Assert.Contains("-b:v", encoder.CurrentQualitySettings);
            Assert.Contains("4M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that h 264 encoder create should return encoder options
        /// </summary>
        [Fact]
        public void H264Encoder_Create_ShouldReturnEncoderOptions()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("mp4", options.Format);
            Assert.Equal("libx264", options.EncoderName);
            Assert.NotNull(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that h 264 encoder create should include preset in arguments
        /// </summary>
        [Fact]
        public void H264Encoder_Create_ShouldIncludePresetInArguments()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderPreset = Preset.Fast;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("fast", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that h 264 encoder create should not include tune when auto
        /// </summary>
        [Fact]
        public void H264Encoder_Create_ShouldNotIncludeTuneWhenAuto()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.Auto;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.DoesNotContain("-tune", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that h 264 encoder create should include tune when not auto
        /// </summary>
        [Fact]
        public void H264Encoder_Create_ShouldIncludeTuneWhenNotAuto()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.Film;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-tune", options.EncoderArguments);
            Assert.Contains("film", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that h 264 encoder create should not include profile when auto
        /// </summary>
        [Fact]
        public void H264Encoder_Create_ShouldNotIncludeProfileWhenAuto()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.Auto;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.DoesNotContain("-profile:v", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that h 264 encoder create should include profile when not auto
        /// </summary>
        [Fact]
        public void H264Encoder_Create_ShouldIncludeProfileWhenNotAuto()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.High;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-profile:v", options.EncoderArguments);
            Assert.Contains("high", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that h 264 encoder should support all presets
        /// </summary>
        [Fact]
        public void H264Encoder_ShouldSupportAllPresets()
        {
            // Arrange & Act & Assert
            foreach (Preset preset in Enum.GetValues(typeof(Preset)))
            {
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderPreset = preset;
                EncoderOptions options = encoder.Create();
                Assert.NotNull(options);
            }
        }

        /// <summary>
        ///     Tests that h 264 encoder should support all tunes
        /// </summary>
        [Fact]
        public void H264Encoder_ShouldSupportAllTunes()
        {
            // Arrange & Act & Assert
            foreach (Tune tune in Enum.GetValues(typeof(Tune)))
            {
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderTune = tune;
                EncoderOptions options = encoder.Create();
                Assert.NotNull(options);
            }
        }

        /// <summary>
        ///     Tests that h 264 encoder should support all profiles
        /// </summary>
        [Fact]
        public void H264Encoder_ShouldSupportAllProfiles()
        {
            // Arrange & Act & Assert
            foreach (FFmpegProfile profile in Enum.GetValues(typeof(FFmpegProfile)))
            {
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderFFmpegProfile = profile;
                EncoderOptions options = encoder.Create();
                Assert.NotNull(options);
            }
        }

        /// <summary>
        ///     Tests that h 264 encoder set vbv with crf max should include in settings
        /// </summary>
        [Fact]
        public void H264Encoder_SetVbvWithCrfMax_ShouldIncludeInSettings()
        {
            // Arrange
            H264Encoder encoder = new H264Encoder();

            // Act
            encoder.SetVbv(23, "5M", "10M", 25);

            // Assert
            Assert.Contains("-crf_max", encoder.CurrentQualitySettings);
            Assert.Contains("25", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that h 264 encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void H264Encoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            // Arrange & Act
            H264Encoder encoder = new H264Encoder();

            // Assert
            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }
    }
}