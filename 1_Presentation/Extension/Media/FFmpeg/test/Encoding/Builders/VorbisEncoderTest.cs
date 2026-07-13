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
        [Fact]
        public void VorbisEncoder_Constructor_ShouldCreateInstanceWithDefaultCqp()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.NotNull(encoder);
            Assert.Equal("-q:a 3.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_Name_ShouldReturnLibvorbis()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.Equal("libvorbis", encoder.Name);
        }

        [Fact]
        public void VorbisEncoder_DefaultFormat_ShouldBeOgg()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.Equal("ogg", encoder.Format);
        }

        [Fact]
        public void VorbisEncoder_Format_ShouldBeSettable()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            string format = "webm";

            encoder.Format = format;

            Assert.Equal(format, encoder.Format);
        }

        [Fact]
        public void VorbisEncoder_ChannelCount_ShouldBeSettable()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            int channelCount = 2;

            encoder.ChannelCount = channelCount;

            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        [Fact]
        public void VorbisEncoder_DefaultChannelCount_ShouldBeNull()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.Null(encoder.ChannelCount);
        }

        [Fact]
        public void VorbisEncoder_SampleRate_ShouldBeSettable()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            int sampleRate = 48000;

            encoder.SampleRate = sampleRate;

            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        [Fact]
        public void VorbisEncoder_DefaultSampleRate_ShouldBeNull()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.Null(encoder.SampleRate);
        }

        [Fact]
        public void VorbisEncoder_SetCbr_ShouldSetQualitySettings()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            string bitrate = "192k";

            encoder.SetCbr(bitrate);

            Assert.Equal("-b:a 192k", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_SetCbr_WithDifferentBitrates_ShouldSetQualitySettings()
        {
            VorbisEncoder encoder64k = new VorbisEncoder();
            encoder64k.SetCbr("64k");

            VorbisEncoder encoder128k = new VorbisEncoder();
            encoder128k.SetCbr("128k");

            VorbisEncoder encoder320k = new VorbisEncoder();
            encoder320k.SetCbr("320k");

            Assert.Equal("-b:a 64k", encoder64k.CurrentQualitySettings);
            Assert.Equal("-b:a 128k", encoder128k.CurrentQualitySettings);
            Assert.Equal("-b:a 320k", encoder320k.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_SetCqp_WithDefault_ShouldSetQuality3()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            encoder.SetCqp();

            Assert.Equal("-q:a 3.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_SetCqp_WithCustomQuality_ShouldSetQualitySettings()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            float q = 5.5f;

            encoder.SetCqp(q);

            Assert.Equal("-q:a 5.50", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_SetCqp_WithMinusOne_ShouldSetQualitySettings()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            encoder.SetCqp(-1f);

            Assert.Equal("-q:a -1.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_SetCqp_WithTen_ShouldSetQualitySettings()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            encoder.SetCqp(10f);

            Assert.Equal("-q:a 10.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_SetCqp_WithZero_ShouldSetQualitySettings()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            encoder.SetCqp(0f);

            Assert.Equal("-q:a 0.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldReturnEncoderOptions()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options);
            Assert.Equal("ogg", options.Format);
            Assert.Equal("libvorbis", options.EncoderName);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeDefaultQualityInArguments()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            EncoderOptions options = encoder.Create();

            Assert.Contains("-q:a 3.00", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldNotIncludeChannelCountWhenNull()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.ChannelCount = null;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-ac", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.ChannelCount = 2;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldNotIncludeSampleRateWhenNull()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.SampleRate = null;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-ar", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeSampleRateWhenSet()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.SampleRate = 44100;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("44100", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeBothChannelCountAndSampleRateWhenSet()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.ChannelCount = 2;
            encoder.SampleRate = 48000;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ac 2", options.EncoderArguments);
            Assert.Contains("-ar 48000", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_SetCbr_ShouldOverrideDefaultCqp()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            encoder.SetCbr("256k");
            EncoderOptions options = encoder.Create();

            Assert.Contains("-b:a 256k", options.EncoderArguments);
            Assert.DoesNotContain("-q:a", options.EncoderArguments);
        }

        [Fact]
        public void VorbisEncoder_ImplementsIEncoderOptionsBuilder()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.IsAssignableFrom<IEncoderOptionsBuilder>(encoder);
        }
    }
}
