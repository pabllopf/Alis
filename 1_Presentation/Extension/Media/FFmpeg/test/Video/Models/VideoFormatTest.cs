// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFormatTest.cs
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

using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video.Models
{
    /// <summary>
    ///     The video format test class
    /// </summary>
    /// <seealso cref="VideoFormat" />
    public class VideoFormatTest
    {
        /// <summary>
        ///     Tests that video format constructor should create instance
        /// </summary>
        [Fact]
        public void VideoFormat_Constructor_ShouldCreateInstance()
        {
            VideoFormat format = new VideoFormat();

            Assert.NotNull(format);
        }

        /// <summary>
        ///     Tests that video format filename property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_FilenameProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string filename = "video.mp4";

            format.Filename = filename;

            Assert.Equal(filename, format.Filename);
        }

        /// <summary>
        ///     Tests that video format nb streams property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_NbStreamsProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            long nbStreams = 2;

            format.NbStreams = nbStreams;

            Assert.Equal(nbStreams, format.NbStreams);
        }

        /// <summary>
        ///     Tests that video format nb programs property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_NbProgramsProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            long nbPrograms = 0;

            format.NbPrograms = nbPrograms;

            Assert.Equal(nbPrograms, format.NbPrograms);
        }

        /// <summary>
        ///     Tests that video format format name property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_FormatNameProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string formatName = "mov,mp4,m4a,3gp,3g2,mj2";

            format.FormatName = formatName;

            Assert.Equal(formatName, format.FormatName);
        }

        /// <summary>
        ///     Tests that video format format long name property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_FormatLongNameProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string formatLongName = "QuickTime / MOV";

            format.FormatLongName = formatLongName;

            Assert.Equal(formatLongName, format.FormatLongName);
        }

        /// <summary>
        ///     Tests that video format start time property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_StartTimeProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string startTime = "0.000000";

            format.StartTime = startTime;

            Assert.Equal(startTime, format.StartTime);
        }

        /// <summary>
        ///     Tests that video format duration property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_DurationProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string duration = "120.000000";

            format.Duration = duration;

            Assert.Equal(duration, format.Duration);
        }

        /// <summary>
        ///     Tests that video format size property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_SizeProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string size = "50000000";

            format.Size = size;

            Assert.Equal(size, format.Size);
        }

        /// <summary>
        ///     Tests that video format bit rate property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_BitRateProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            string bitRate = "5000000";

            format.BitRate = bitRate;

            Assert.Equal(bitRate, format.BitRate);
        }

        /// <summary>
        ///     Tests that video format probe score property should be settable
        /// </summary>
        [Fact]
        public void VideoFormat_ProbeScoreProperty_ShouldBeSettable()
        {
            VideoFormat format = new VideoFormat();
            long probeScore = 100;

            format.ProbeScore = probeScore;

            Assert.Equal(probeScore, format.ProbeScore);
        }

        /// <summary>
        ///     Tests that video format should support null values
        /// </summary>
        [Fact]
        public void VideoFormat_ShouldSupportNullValues()
        {
            VideoFormat format = new VideoFormat();

            format.Filename = null;
            format.FormatName = null;
            format.FormatLongName = null;

            Assert.Null(format.Filename);
            Assert.Null(format.FormatName);
            Assert.Null(format.FormatLongName);
        }

        /// <summary>
        ///     Tests that video format should support initializer syntax
        /// </summary>
        [Fact]
        public void VideoFormat_ShouldSupportInitializerSyntax()
        {
            VideoFormat format = new VideoFormat
            {
                Filename = "video.mp4",
                FormatName = "mp4",
                Duration = "120.000000",
                BitRate = "5000000"
            };

            Assert.Equal("video.mp4", format.Filename);
            Assert.Equal("mp4", format.FormatName);
            Assert.Equal("120.000000", format.Duration);
            Assert.Equal("5000000", format.BitRate);
        }

        /// <summary>
        ///     Tests that video format properties should be mutable
        /// </summary>
        [Fact]
        public void VideoFormat_Properties_ShouldBeMutable()
        {
            VideoFormat format = new VideoFormat
            {
                Filename = "video1.mp4",
                FormatName = "mp4"
            };

            format.Filename = "video2.mkv";
            format.FormatName = "matroska";

            Assert.Equal("video2.mkv", format.Filename);
            Assert.Equal("matroska", format.FormatName);
        }

        /// <summary>
        ///     Tests that video format should support common video formats
        /// </summary>
        [Fact]
        public void VideoFormat_ShouldSupportCommonVideoFormats()
        {
            VideoFormat mp4 = new VideoFormat {FormatName = "mp4"};
            VideoFormat mkv = new VideoFormat {FormatName = "matroska"};
            VideoFormat webm = new VideoFormat {FormatName = "webm"};

            Assert.Equal("mp4", mp4.FormatName);
            Assert.Equal("matroska", mkv.FormatName);
            Assert.Equal("webm", webm.FormatName);
        }

        /// <summary>
        ///     Tests that video format probe score should support valid range
        /// </summary>
        [Fact]
        public void VideoFormat_ProbeScore_ShouldSupportValidRange()
        {
            VideoFormat lowScore = new VideoFormat {ProbeScore = 0};
            VideoFormat mediumScore = new VideoFormat {ProbeScore = 50};
            VideoFormat highScore = new VideoFormat {ProbeScore = 100};

            Assert.Equal(0, lowScore.ProbeScore);
            Assert.Equal(50, mediumScore.ProbeScore);
            Assert.Equal(100, highScore.ProbeScore);
        }
    }
}