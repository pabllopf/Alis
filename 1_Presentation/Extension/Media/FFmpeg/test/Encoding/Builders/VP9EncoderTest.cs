// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VP9EncoderTest.cs
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
    ///     The vp 9 encoder test class
    /// </summary>
    /// <seealso cref="Vp9Encoder" />
    public class Vp9EncoderTest
    {
        /// <summary>
        ///     Tests that vp 9 encoder constructor should create instance with default cqp
        /// </summary>
        [Fact]
        public void Vp9Encoder_Constructor_ShouldCreateInstanceWithDefaultCqp()
        {
            // Arrange & Act
            Vp9Encoder encoder = new Vp9Encoder();

            // Assert
            Assert.NotNull(encoder);
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder name property should return libvpx vp 9
        /// </summary>
        [Fact]
        public void Vp9Encoder_NameProperty_ShouldReturnLibvpxVp9()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();

            // Act
            string name = encoder.Name;

            // Assert
            Assert.Equal("libvpx-vp9", name);
        }

        /// <summary>
        ///     Tests that vp 9 encoder default format should be webm
        /// </summary>
        [Fact]
        public void Vp9Encoder_DefaultFormat_ShouldBeWebm()
        {
            // Arrange & Act
            Vp9Encoder encoder = new Vp9Encoder();

            // Assert
            Assert.Equal("webm", encoder.Format);
        }

        /// <summary>
        ///     Tests that vp 9 encoder encoder quality property should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_EncoderQualityProperty_ShouldBeSettable()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            Quality quality = Quality.Best;

            // Act
            encoder.EncoderQuality = quality;

            // Assert
            Assert.Equal(quality, encoder.EncoderQuality);
        }

        /// <summary>
        ///     Tests that vp 9 encoder default quality should be good
        /// </summary>
        [Fact]
        public void Vp9Encoder_DefaultQuality_ShouldBeGood()
        {
            // Arrange & Act
            Vp9Encoder encoder = new Vp9Encoder();

            // Assert
            Assert.Equal(Quality.Good, encoder.EncoderQuality);
        }

        /// <summary>
        ///     Tests that vp 9 encoder encoder tune property should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_EncoderTuneProperty_ShouldBeSettable()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            Vp9Encoder.Tune tune = Vp9Encoder.Tune.Film;

            // Act
            encoder.EncoderTune = tune;

            // Assert
            Assert.Equal(tune, encoder.EncoderTune);
        }

        /// <summary>
        ///     Tests that vp 9 encoder cpu used property should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_CpuUsedProperty_ShouldBeSettable()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            int cpuUsed = 4;

            // Act
            encoder.CpuUsed = cpuUsed;

            // Assert
            Assert.Equal(cpuUsed, encoder.CpuUsed);
        }

        /// <summary>
        ///     Tests that vp 9 encoder default cpu used should be null
        /// </summary>
        [Fact]
        public void Vp9Encoder_DefaultCpuUsed_ShouldBeNull()
        {
            // Arrange & Act
            Vp9Encoder encoder = new Vp9Encoder();

            // Assert
            Assert.Null(encoder.CpuUsed);
        }

        /// <summary>
        ///     Tests that vp 9 encoder row based multithreading property should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_RowBasedMultithreadingProperty_ShouldBeSettable()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();

            // Act
            encoder.RowBasedMultithreading = true;

            // Assert
            Assert.True(encoder.RowBasedMultithreading);
        }

        /// <summary>
        ///     Tests that vp 9 encoder default row based multithreading should be false
        /// </summary>
        [Fact]
        public void Vp9Encoder_DefaultRowBasedMultithreading_ShouldBeFalse()
        {
            // Arrange & Act
            Vp9Encoder encoder = new Vp9Encoder();

            // Assert
            Assert.False(encoder.RowBasedMultithreading);
        }

        /// <summary>
        ///     Tests that vp 9 encoder set cvbr with crf should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCvbrWithCrf_ShouldSetQualitySettings()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            int crf = 31;
            string maxBitrate = "2M";

            // Act
            encoder.SetCvbr(crf, maxBitrate);

            // Assert
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
            Assert.Contains("31", encoder.CurrentQualitySettings);
            Assert.Contains("2M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder set cvbr with bitrates should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCvbrWithBitrates_ShouldSetQualitySettings()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            string targetBitrate = "1M";
            string minBitrate = "500k";
            string maxBitrate = "2M";

            // Act
            encoder.SetCvbr(targetBitrate, minBitrate, maxBitrate);

            // Assert
            Assert.Contains("-minrate", encoder.CurrentQualitySettings);
            Assert.Contains("-b:v", encoder.CurrentQualitySettings);
            Assert.Contains("-maxrate", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder set abr should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetAbr_ShouldSetQualitySettings()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            string bitrate = "1M";

            // Act
            encoder.SetAbr(bitrate);

            // Assert
            Assert.Contains("-b:v", encoder.CurrentQualitySettings);
            Assert.Contains("1M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder set cqp with custom value should work
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCqpWithCustomValue_ShouldWork()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            int crf = 40;

            // Act
            encoder.SetCqp(crf);

            // Assert
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
            Assert.Contains("40", encoder.CurrentQualitySettings);
            Assert.Contains("-b:v 0", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCbr_ShouldSetQualitySettings()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            string bitrate = "2M";

            // Act
            encoder.SetCbr(bitrate);

            // Assert
            Assert.Contains("-minrate", encoder.CurrentQualitySettings);
            Assert.Contains("-maxrate", encoder.CurrentQualitySettings);
            Assert.Contains("-b:v", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder set lossless should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetLossless_ShouldSetQualitySettings()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();

            // Act
            encoder.SetLossless();

            // Assert
            Assert.Contains("-lossless 1", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vp 9 encoder create should return encoder options
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldReturnEncoderOptions()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("webm", options.Format);
            Assert.Equal("libvpx-vp9", options.EncoderName);
        }

        /// <summary>
        ///     Tests that vp 9 encoder create should include cpu used when set
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeCpuUsedWhenSet()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.CpuUsed = 5;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-cpu-used", options.EncoderArguments);
            Assert.Contains("5", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that vp 9 encoder create should include row mt when enabled
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeRowMtWhenEnabled()
        {
            // Arrange
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.RowBasedMultithreading = true;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-row-mt 1", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that vp 9 encoder tune enum should have three values
        /// </summary>
        [Fact]
        public void Vp9Encoder_TuneEnum_ShouldHaveThreeValues()
        {
            // Arrange & Act
            Vp9Encoder.Tune[] values = (Vp9Encoder.Tune[]) Enum.GetValues(typeof(Vp9Encoder.Tune));

            // Assert
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that vp 9 encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void Vp9Encoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            // Arrange & Act
            Vp9Encoder encoder = new Vp9Encoder();

            // Assert
            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }
    }
}