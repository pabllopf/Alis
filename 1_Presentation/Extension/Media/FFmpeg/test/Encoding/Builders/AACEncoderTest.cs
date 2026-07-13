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
    public class AacEncoderTest
    {
        [Fact]
        public void AacEncoder_Constructor_ShouldCreateInstanceWithDefaultCbr()
        {
            AacEncoder encoder = new AacEncoder();

            Assert.NotNull(encoder);
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void AacEncoder_NameProperty_ShouldReturnAac()
        {
            AacEncoder encoder = new AacEncoder();

            string name = encoder.Name;

            Assert.Equal("aac", name);
        }

        [Fact]
        public void AacEncoder_DefaultFormat_ShouldBeM4a()
        {
            AacEncoder encoder = new AacEncoder();

            Assert.Equal("m4a", encoder.Format);
        }

        [Fact]
        public void AacEncoder_FormatProperty_ShouldBeSettable()
        {
            AacEncoder encoder = new AacEncoder();
            string format = "mp4";

            encoder.Format = format;

            Assert.Equal(format, encoder.Format);
        }

        [Fact]
        public void AacEncoder_ChannelCountProperty_ShouldBeSettable()
        {
            AacEncoder encoder = new AacEncoder();
            int channelCount = 2;

            encoder.ChannelCount = channelCount;

            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        [Fact]
        public void AacEncoder_DefaultChannelCount_ShouldBeNull()
        {
            AacEncoder encoder = new AacEncoder();

            Assert.Null(encoder.ChannelCount);
        }

        [Fact]
        public void AacEncoder_SampleRateProperty_ShouldBeSettable()
        {
            AacEncoder encoder = new AacEncoder();
            int sampleRate = 44100;

            encoder.SampleRate = sampleRate;

            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        [Fact]
        public void AacEncoder_DefaultSampleRate_ShouldBeNull()
        {
            AacEncoder encoder = new AacEncoder();

            Assert.Null(encoder.SampleRate);
        }

        [Fact]
        public void AacEncoder_SetCbrWithCustomBitrate_ShouldWork()
        {
            AacEncoder encoder = new AacEncoder();
            string bitrate = "256k";

            encoder.SetCbr(bitrate);

            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("256k", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void AacEncoder_SetCbrDefault_ShouldBe128k()
        {
            AacEncoder encoder = new AacEncoder();

            encoder.SetCbr();

            Assert.Contains("128k", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void AacEncoder_SetCbrWithDifferentBitrates_ShouldWork()
        {
            AacEncoder encoder64k = new AacEncoder();
            encoder64k.SetCbr("64k");

            AacEncoder encoder192k = new AacEncoder();
            encoder192k.SetCbr("192k");

            AacEncoder encoder320k = new AacEncoder();
            encoder320k.SetCbr("320k");

            Assert.Contains("64k", encoder64k.CurrentQualitySettings);
            Assert.Contains("192k", encoder192k.CurrentQualitySettings);
            Assert.Contains("320k", encoder320k.CurrentQualitySettings);
        }

        [Fact]
        public void AacEncoder_Create_ShouldReturnEncoderOptions()
        {
            AacEncoder encoder = new AacEncoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options);
            Assert.Equal("m4a", options.Format);
            Assert.Equal("aac", options.EncoderName);
        }

        [Fact]
        public void AacEncoder_Create_ShouldIncludeDefaultBitrateInArguments()
        {
            AacEncoder encoder = new AacEncoder();

            EncoderOptions options = encoder.Create();

            Assert.Contains("-b:a", options.EncoderArguments);
            Assert.Contains("128k", options.EncoderArguments);
        }

        [Fact]
        public void AacEncoder_Create_ShouldNotIncludeChannelCountWhenNull()
        {
            AacEncoder encoder = new AacEncoder();
            encoder.ChannelCount = null;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-ac", options.EncoderArguments);
        }

        [Fact]
        public void AacEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            AacEncoder encoder = new AacEncoder();
            encoder.ChannelCount = 2;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        [Fact]
        public void AacEncoder_Create_ShouldNotIncludeSampleRateWhenNull()
        {
            AacEncoder encoder = new AacEncoder();
            encoder.SampleRate = null;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-ar", options.EncoderArguments);
        }

        [Fact]
        public void AacEncoder_Create_ShouldIncludeSampleRateWhenSet()
        {
            AacEncoder encoder = new AacEncoder();
            encoder.SampleRate = 48000;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("48000", options.EncoderArguments);
        }

        [Fact]
        public void AacEncoder_Create_ShouldIncludeBothChannelCountAndSampleRateWhenSet()
        {
            AacEncoder encoder = new AacEncoder();
            encoder.ChannelCount = 2;
            encoder.SampleRate = 48000;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("48000", options.EncoderArguments);
        }

        [Fact]
        public void AacEncoder_ImplementsIEncoderOptionsBuilder()
        {
            AacEncoder encoder = new AacEncoder();

            Assert.IsAssignableFrom<IEncoderOptionsBuilder>(encoder);
        }
    }
}
