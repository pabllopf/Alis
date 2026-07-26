// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:H264EncoderTests.cs
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
    public class H264EncoderTests
    {
        [Fact]
        public void Constructor_ShouldSetDefaultCqp()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.NotNull(encoder);
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
            Assert.Contains("22.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void Name_ShouldReturnLibx264()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.Equal("libx264", encoder.Name);
        }

        [Fact]
        public void Format_Default_ShouldBeMp4()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.Equal("mp4", encoder.Format);
        }

        [Fact]
        public void Format_ShouldBeSettable()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.Format = "mkv";
            Assert.Equal("mkv", encoder.Format);
        }

        [Fact]
        public void EncoderPreset_Default_ShouldBeMedium()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.Equal(Preset.Medium, encoder.EncoderPreset);
        }

        [Fact]
        public void EncoderPreset_ShouldBeSettable()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderPreset = Preset.Fast;
            Assert.Equal(Preset.Fast, encoder.EncoderPreset);
        }

        [Fact]
        public void EncoderTune_Default_ShouldBeAuto()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.Equal(Tune.Auto, encoder.EncoderTune);
        }

        [Fact]
        public void EncoderTune_ShouldBeSettable()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.Film;
            Assert.Equal(Tune.Film, encoder.EncoderTune);
        }

        [Fact]
        public void EncoderFFmpegProfile_Default_ShouldBeAuto()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.Equal(FFmpegProfile.Auto, encoder.EncoderFFmpegProfile);
        }

        [Fact]
        public void EncoderFFmpegProfile_ShouldBeSettable()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.High;
            Assert.Equal(FFmpegProfile.High, encoder.EncoderFFmpegProfile);
        }

        [Fact]
        public void SetCqp_ShouldUpdateCurrentQualitySettings()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCqp(18.5f);
            Assert.Contains("-crf", encoder.CurrentQualitySettings);
            Assert.Contains("18.50", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetCqp_WithDefaultCrf_ShouldUse22()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCqp();
            Assert.Contains("-crf 22.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetCbr_ShouldUpdateCurrentQualitySettings()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCbr("5M", "10M");
            Assert.Contains("-b:v 5M", encoder.CurrentQualitySettings);
            Assert.Contains("-minrate 5M", encoder.CurrentQualitySettings);
            Assert.Contains("-maxrate 5M", encoder.CurrentQualitySettings);
            Assert.Contains("-bufsize 10M", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetVbv_ShouldUpdateCurrentQualitySettings()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetVbv(23, "5M", "10M");
            Assert.Contains("-crf 23.00", encoder.CurrentQualitySettings);
            Assert.Contains("-maxrate 5M", encoder.CurrentQualitySettings);
            Assert.Contains("-bufsize 10M", encoder.CurrentQualitySettings);
            Assert.Contains("-crf_max -1", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetVbv_WithCustomCrfMax_ShouldIncludeCrfMax()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetVbv(23, "5M", "10M", 25);
            Assert.Contains("-crf_max 25", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetAbr_ShouldUpdateCurrentQualitySettings()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetAbr("4M");
            Assert.Contains("-b:v 4M", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void Create_ShouldReturnEncoderOptionsWithDefaults()
        {
            H264Encoder encoder = new H264Encoder();
            EncoderOptions options = encoder.Create();
            Assert.NotNull(options);
            Assert.Equal("mp4", options.Format);
            Assert.Equal("libx264", options.EncoderName);
            Assert.NotNull(options.EncoderArguments);
        }

        [Fact]
        public void Create_ShouldIncludeCrfAndPresetInArguments()
        {
            H264Encoder encoder = new H264Encoder();
            EncoderOptions options = encoder.Create();
            Assert.Contains("-crf", options.EncoderArguments);
            Assert.Contains("-preset medium", options.EncoderArguments);
        }

        [Fact]
        public void Create_ShouldNotIncludeTuneWhenAuto()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.Auto;
            EncoderOptions options = encoder.Create();
            Assert.DoesNotContain("-tune", options.EncoderArguments);
        }

        [Fact]
        public void Create_ShouldIncludeTuneWhenNotAuto()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.Film;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-tune film", options.EncoderArguments);
        }

        [Fact]
        public void Create_ShouldNotIncludeProfileWhenAuto()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.Auto;
            EncoderOptions options = encoder.Create();
            Assert.DoesNotContain("-profile:v", options.EncoderArguments);
        }

        [Fact]
        public void Create_ShouldIncludeProfileWhenNotAuto()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.High;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-profile:v high", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithAllTuneValues_ShouldGenerateValidArguments()
        {
            foreach (Tune tune in Enum.GetValues(typeof(Tune)))
            {
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderTune = tune;
                EncoderOptions options = encoder.Create();
                Assert.NotNull(options);
                Assert.NotNull(options.EncoderArguments);
            }
        }

        [Fact]
        public void Create_WithAllPresetValues_ShouldGenerateValidArguments()
        {
            foreach (Preset preset in Enum.GetValues(typeof(Preset)))
            {
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderPreset = preset;
                EncoderOptions options = encoder.Create();
                Assert.NotNull(options);
                Assert.NotNull(options.EncoderArguments);
            }
        }

        [Fact]
        public void Create_WithAllProfileValues_ShouldGenerateValidArguments()
        {
            foreach (FFmpegProfile profile in Enum.GetValues(typeof(FFmpegProfile)))
            {
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderFFmpegProfile = profile;
                EncoderOptions options = encoder.Create();
                Assert.NotNull(options);
                Assert.NotNull(options.EncoderArguments);
            }
        }

        [Fact]
        public void Create_WithCbrSettings_ShouldIncludeCbrArguments()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCbr("5M", "10M");
            EncoderOptions options = encoder.Create();
            Assert.Contains("-x264-params", options.EncoderArguments);
            Assert.Contains("nal-hrd=cbr", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithVbvSettings_ShouldIncludeVbvArguments()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetVbv(23, "5M", "10M");
            EncoderOptions options = encoder.Create();
            Assert.Contains("-maxrate 5M", options.EncoderArguments);
            Assert.Contains("-bufsize 10M", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithAbrSettings_ShouldIncludeAbrArguments()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetAbr("4M");
            EncoderOptions options = encoder.Create();
            Assert.Contains("-b:v 4M", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithCustomFormat_ShouldReflectInOptions()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.Format = "flv";
            EncoderOptions options = encoder.Create();
            Assert.Equal("flv", options.Format);
        }

        [Fact]
        public void Create_WithBaselineProfile_ShouldIncludeBaseline()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.Baseline;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-profile:v baseline", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithMainProfile_ShouldIncludeMain()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.Main;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-profile:v main", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithMultipleSettings_ShouldCombineAll()
        {
            H264Encoder encoder = new H264Encoder
            {
                EncoderPreset = Preset.Slow,
                EncoderTune = Tune.Grain,
                EncoderFFmpegProfile = FFmpegProfile.High444
            };
            encoder.SetCqp(15);
            EncoderOptions options = encoder.Create();
            Assert.Contains("-crf 15.00", options.EncoderArguments);
            Assert.Contains("-preset slow", options.EncoderArguments);
            Assert.Contains("-tune grain", options.EncoderArguments);
            Assert.Contains("-profile:v high444", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithHigh10Profile_ShouldIncludeHigh10()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.High10;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-profile:v high10", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithHigh442Profile_ShouldIncludeHigh442()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.High442;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-profile:v high442", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithHigh444Profile_ShouldIncludeHigh444()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderFFmpegProfile = FFmpegProfile.High444;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-profile:v high444", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithAllTuneNonAuto_ShouldIncludeCorrectTune()
        {
            foreach (Tune tune in Enum.GetValues(typeof(Tune)))
            {
                if (tune == Tune.Auto) continue;
                H264Encoder encoder = new H264Encoder();
                encoder.EncoderTune = tune;
                EncoderOptions options = encoder.Create();
                string expected = tune.ToString().ToLowerInvariant();
                Assert.Contains($"-tune {expected}", options.EncoderArguments);
            }
        }

        [Fact]
        public void Create_WithAnimationTune_ShouldIncludeAnimation()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.Animation;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-tune animation", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithStillImageTune_ShouldIncludeStillImage()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.StillImage;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-tune stillimage", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithFastDecodeTune_ShouldIncludeFastDecode()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.FastDecode;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-tune fastdecode", options.EncoderArguments);
        }

        [Fact]
        public void Create_WithZeroLatencyTune_ShouldIncludeZeroLatency()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.EncoderTune = Tune.ZeroLatency;
            EncoderOptions options = encoder.Create();
            Assert.Contains("-tune zerolatency", options.EncoderArguments);
        }

        [Fact]
        public void SetCqp_WithZeroCrf_ShouldUseZero()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCqp(0);
            Assert.Contains("-crf 0.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetCqp_WithMaxCrf_ShouldUse51()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCqp(51);
            Assert.Contains("-crf 51.00", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetCbr_WithEmptyStrings_ShouldSetEmptyValues()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetCbr("", "");
            Assert.Contains("-b:v ", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void SetVbv_WithNegativeCrfMax_ShouldIncludeNegative()
        {
            H264Encoder encoder = new H264Encoder();
            encoder.SetVbv(23, "5M", "10M", -1);
            Assert.Contains("-crf_max -1", encoder.CurrentQualitySettings);
        }

        [Fact]
        public void ImplementsIEncoderOptionsBuilder()
        {
            H264Encoder encoder = new H264Encoder();
            Assert.IsAssignableFrom<IEncoderOptionsBuilder>(encoder);
        }
    }
}
