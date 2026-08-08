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
        /// Tests that vp 9 encoder constructor should set default current quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_Constructor_ShouldSetDefaultCurrentQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            Assert.Equal("-crf 31 -b:v 0", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder constructor should set defaults
        /// </summary>
        [Fact]
        public void Vp9Encoder_Constructor_ShouldSetDefaults()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            Assert.Equal(Quality.Good, encoder.EncoderQuality);
            Assert.Equal(Vp9Encoder.Tune.Default, encoder.EncoderTune);
            Assert.Null(encoder.CpuUsed);
            Assert.False(encoder.RowBasedMultithreading);
            Assert.Equal("webm", encoder.Format);
            Assert.Equal("libvpx-vp9", encoder.Name);
        }

        /// <summary>
        /// Tests that vp 9 encoder encoder quality should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_EncoderQuality_ShouldBeSettable()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.EncoderQuality = Quality.Best;

            Assert.Equal(Quality.Best, encoder.EncoderQuality);
        }

        /// <summary>
        /// Tests that vp 9 encoder encoder tune should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_EncoderTune_ShouldBeSettable()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.EncoderTune = Vp9Encoder.Tune.Film;

            Assert.Equal(Vp9Encoder.Tune.Film, encoder.EncoderTune);
        }

        /// <summary>
        /// Tests that vp 9 encoder cpu used should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_CpuUsed_ShouldBeSettable()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.CpuUsed = 4;

            Assert.Equal(4, encoder.CpuUsed);
        }

        /// <summary>
        /// Tests that vp 9 encoder cpu used should accept negative values
        /// </summary>
        [Fact]
        public void Vp9Encoder_CpuUsed_ShouldAcceptNegativeValues()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.CpuUsed = -8;

            Assert.Equal(-8, encoder.CpuUsed);
        }

        /// <summary>
        /// Tests that vp 9 encoder row based multithreading should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_RowBasedMultithreading_ShouldBeSettable()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.RowBasedMultithreading = true;

            Assert.True(encoder.RowBasedMultithreading);
        }

        /// <summary>
        /// Tests that vp 9 encoder format should be settable
        /// </summary>
        [Fact]
        public void Vp9Encoder_Format_ShouldBeSettable()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.Format = "mkv";

            Assert.Equal("mkv", encoder.Format);
        }

        /// <summary>
        /// Tests that vp 9 encoder name should return libvpx vp 9
        /// </summary>
        [Fact]
        public void Vp9Encoder_Name_ShouldReturnLibvpxVp9()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            Assert.Equal("libvpx-vp9", encoder.Name);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cvbr with crf and max bitrate should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCvbr_WithCrfAndMaxBitrate_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCvbr(25, "2M");

            Assert.Equal("-crf 25 -b:v 2M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cvbr with bitrates should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCvbr_WithBitrates_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCvbr("1M", "500k", "2M");

            Assert.Equal("-minrate 500k -b:v 1M -maxrate 2M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set abr should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetAbr_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetAbr("1M");

            Assert.Equal("-b:v 1M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cqp with default should use crf 31
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCqp_WithDefault_ShouldUseCrf31()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCqp();

            Assert.Equal("-crf 31 -b:v 0", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cqp with custom crf should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCqp_WithCustomCrf_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCqp(40);

            Assert.Equal("-crf 40 -b:v 0", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cqp with crf zero should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCqp_WithCrfZero_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCqp(0);

            Assert.Equal("-crf 0 -b:v 0", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cqp with crf 63 should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCqp_WithCrf63_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCqp(63);

            Assert.Equal("-crf 63 -b:v 0", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetCbr_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetCbr("2M");

            Assert.Equal("-minrate 2M -maxrate 2M -b:v 2M", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder set lossless should set quality settings
        /// </summary>
        [Fact]
        public void Vp9Encoder_SetLossless_ShouldSetQualitySettings()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            encoder.SetLossless();

            Assert.Equal("-lossless 1", encoder.CurrentQualitySettings);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should return encoder options with correct format and name
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldReturnEncoderOptionsWithCorrectFormatAndName()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options);
            Assert.Equal("webm", options.Format);
            Assert.Equal("libvpx-vp9", options.EncoderName);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include quality settings in arguments
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeQualitySettingsInArguments()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.SetCqp(25);

            EncoderOptions options = encoder.Create();

            Assert.Contains("-crf 25 -b:v 0", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include tune content default
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeTuneContentDefault()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            EncoderOptions options = encoder.Create();

            Assert.Contains("-tune-content default", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include tune content film
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeTuneContentFilm()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.EncoderTune = Vp9Encoder.Tune.Film;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-tune-content film", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include tune content screen
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeTuneContentScreen()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.EncoderTune = Vp9Encoder.Tune.Screen;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-tune-content screen", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include deadline good by default
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeDeadlineGoodByDefault()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            EncoderOptions options = encoder.Create();

            Assert.Contains("-deadline good", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include deadline best
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeDeadlineBest()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.EncoderQuality = Quality.Best;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-deadline best", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include deadline realtime
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeDeadlineRealtime()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.EncoderQuality = Quality.RealTime;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-deadline realtime", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include cpu used when set
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeCpuUsedWhenSet()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.CpuUsed = 5;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-cpu-used 5", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should not include cpu used when null
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldNotIncludeCpuUsedWhenNull()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.CpuUsed = null;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-cpu-used", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include row mt when enabled
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeRowMtWhenEnabled()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.RowBasedMultithreading = true;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-row-mt 1", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should not include row mt when disabled
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldNotIncludeRowMtWhenDisabled()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.RowBasedMultithreading = false;

            EncoderOptions options = encoder.Create();

            Assert.DoesNotContain("-row-mt", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder create should include custom format
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_ShouldIncludeCustomFormat()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.Format = "mkv";

            EncoderOptions options = encoder.Create();

            Assert.Equal("mkv", options.Format);
        }

        /// <summary>
        /// Tests that vp 9 encoder create include all features
        /// </summary>
        [Fact]
        public void Vp9Encoder_Create_IncludeAllFeatures()
        {
            Vp9Encoder encoder = new Vp9Encoder();
            encoder.EncoderQuality = Quality.Best;
            encoder.EncoderTune = Vp9Encoder.Tune.Film;
            encoder.CpuUsed = 2;
            encoder.RowBasedMultithreading = true;
            encoder.SetCbr("5M");

            EncoderOptions options = encoder.Create();

            Assert.Contains("-minrate 5M -maxrate 5M -b:v 5M", options.EncoderArguments);
            Assert.Contains("-tune-content film", options.EncoderArguments);
            Assert.Contains("-deadline best", options.EncoderArguments);
            Assert.Contains("-cpu-used 2", options.EncoderArguments);
            Assert.Contains("-row-mt 1", options.EncoderArguments);
        }

        /// <summary>
        /// Tests that vp 9 encoder tune enum should have default screen film
        /// </summary>
        [Fact]
        public void Vp9Encoder_TuneEnum_ShouldHaveDefaultScreenFilm()
        {
            Assert.Equal(0, (int)Vp9Encoder.Tune.Default);
            Assert.Equal(1, (int)Vp9Encoder.Tune.Screen);
            Assert.Equal(2, (int)Vp9Encoder.Tune.Film);
        }

        /// <summary>
        /// Tests that vp 9 encoder implements i encoder options builder
        /// </summary>
        [Fact]
        public void Vp9Encoder_ImplementsIEncoderOptionsBuilder()
        {
            Vp9Encoder encoder = new Vp9Encoder();

            Assert.IsAssignableFrom<IEncoderOptionsBuilder>(encoder);
        }
    }
}
