// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MP3EncoderTest.cs
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
    ///     The mp 3 encoder test class
    /// </summary>
    /// <seealso cref="Mp3Encoder" />
    public class Mp3EncoderTest
    {
        /// <summary>
        ///     Tests that mp 3 encoder constructor should create instance with default cqp
        /// </summary>
        [Fact]
        public void Mp3Encoder_Constructor_ShouldCreateInstanceWithDefaultCqp()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            Assert.NotNull(encoder);
            Assert.Contains("-q:a", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that mp 3 encoder name property should return libmp 3 lame
        /// </summary>
        [Fact]
        public void Mp3Encoder_NameProperty_ShouldReturnLibmp3lame()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            string name = encoder.Name;

            Assert.Equal("libmp3lame", name);
        }

        /// <summary>
        ///     Tests that mp 3 encoder default format should be mp 3
        /// </summary>
        [Fact]
        public void Mp3Encoder_DefaultFormat_ShouldBeMp3()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            Assert.Equal("mp3", encoder.Format);
        }

        /// <summary>
        ///     Tests that mp 3 encoder format property should be settable
        /// </summary>
        [Fact]
        public void Mp3Encoder_FormatProperty_ShouldBeSettable()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            string format = "mp3";

            encoder.Format = format;

            Assert.Equal(format, encoder.Format);
        }

        /// <summary>
        ///     Tests that mp 3 encoder channel count property should be settable
        /// </summary>
        [Fact]
        public void Mp3Encoder_ChannelCountProperty_ShouldBeSettable()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            int channelCount = 2;

            encoder.ChannelCount = channelCount;

            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that mp 3 encoder default channel count should be null
        /// </summary>
        [Fact]
        public void Mp3Encoder_DefaultChannelCount_ShouldBeNull()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            Assert.Null(encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that mp 3 encoder sample rate property should be settable
        /// </summary>
        [Fact]
        public void Mp3Encoder_SampleRateProperty_ShouldBeSettable()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            int sampleRate = 44100;

            encoder.SampleRate = sampleRate;

            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that mp 3 encoder default sample rate should be null
        /// </summary>
        [Fact]
        public void Mp3Encoder_DefaultSampleRate_ShouldBeNull()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            Assert.Null(encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that mp 3 encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void Mp3Encoder_SetCbr_ShouldSetQualitySettings()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            string bitrate = "320k";

            encoder.SetCbr(bitrate);

            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("320k", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that mp 3 encoder set abr should set quality settings
        /// </summary>
        [Fact]
        public void Mp3Encoder_SetAbr_ShouldSetQualitySettings()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            string avgBitrate = "256k";

            encoder.SetAbr(avgBitrate);

            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("-abr", encoder.CurrentQualitySettings);
            Assert.Contains("256k", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that mp 3 encoder set cqp with custom quality should work
        /// </summary>
        [Fact]
        public void Mp3Encoder_SetCqpWithCustomQuality_ShouldWork()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            int qscale = 2;

            encoder.SetCqp(qscale);

            Assert.Contains("-q:a", encoder.CurrentQualitySettings);
            Assert.Contains("2", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that mp 3 encoder create should include channel count when set
        /// </summary>
        [Fact]
        public void Mp3Encoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            encoder.ChannelCount = 2;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that mp 3 encoder create should include sample rate when set
        /// </summary>
        [Fact]
        public void Mp3Encoder_Create_ShouldIncludeSampleRateWhenSet()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            encoder.SampleRate = 44100;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("44100", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that mp 3 encoder create should not include channel count when null
        /// </summary>
        [Fact]
        public void Mp3Encoder_Create_ShouldNotIncludeChannelCountWhenNull()
        {
            Mp3Encoder encoder = new Mp3Encoder();
            encoder.ChannelCount = null;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-ac", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that mp 3 encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void Mp3Encoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            Assert.IsAssignableFrom<Mp3Encoder>(encoder);
        }

        /// <summary>
        ///     Tests that mp 3 encoder set cqp with boundary values should work
        /// </summary>
        [Fact]
        public void Mp3Encoder_SetCqpWithBoundaryValues_ShouldWork()
        {
            Mp3Encoder encoder = new Mp3Encoder();

            encoder.SetCqp(0);
            Assert.Contains("0", encoder.CurrentQualitySettings);

            encoder.SetCqp(9);
            Assert.Contains("9", encoder.CurrentQualitySettings);
        }
    }
}