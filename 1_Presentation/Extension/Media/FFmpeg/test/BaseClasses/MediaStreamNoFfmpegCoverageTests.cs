// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaStreamNoFfmpegCoverageTests.cs
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

using System.Collections.Generic;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     Unit tests for the MediaStream data properties that do not require the
    ///     native ffmpeg libraries to be exercised.
    /// </summary>
    public class MediaStreamNoFfmpegCoverageTests
    {
        /// <summary>
        ///     Tests the default values of all scalar properties.
        /// </summary>
        [Fact]
        public void ScalarProperties_Defaults_AreZero()
        {
            MediaStream stream = new MediaStream();

            Assert.Equal(0, stream.Index);
            Assert.Equal(0, stream.Width);
            Assert.Equal(0, stream.Height);
            Assert.Equal(0, stream.CodedWidth);
            Assert.Equal(0, stream.CodedHeight);
            Assert.Equal(0, stream.HasBFrames);
            Assert.Equal(0, stream.Level);
            Assert.Equal(0, stream.Refs);
            Assert.Equal(0, stream.StartPts);
            Assert.Equal(0, stream.DurationTs);
            Assert.Equal(0, stream.Channels);
            Assert.Equal(0, stream.BitsPerSample);
        }

        /// <summary>
        ///     Tests that all string properties default to null.
        /// </summary>
        [Fact]
        public void StringProperties_Defaults_AreNull()
        {
            MediaStream stream = new MediaStream();

            Assert.Null(stream.CodecName);
            Assert.Null(stream.CodecLongName);
            Assert.Null(stream.Profile);
            Assert.Null(stream.CodecType);
            Assert.Null(stream.CodecTimeBase);
            Assert.Null(stream.CodecTagString);
            Assert.Null(stream.CodecTag);
            Assert.Null(stream.SampleAspectRatio);
            Assert.Null(stream.DisplayAspectRatio);
            Assert.Null(stream.PixFmt);
            Assert.Null(stream.ColorRange);
            Assert.Null(stream.ColorSpace);
            Assert.Null(stream.ColorTransfer);
            Assert.Null(stream.ColorPrimaries);
            Assert.Null(stream.ChromaLocation);
            Assert.Null(stream.IsAvc);
            Assert.Null(stream.NalLengthSize);
            Assert.Null(stream.RFrameRate);
            Assert.Null(stream.AvgFrameRate);
            Assert.Null(stream.TimeBase);
            Assert.Null(stream.StartTime);
            Assert.Null(stream.Duration);
            Assert.Null(stream.BitRate);
            Assert.Null(stream.BitsPerRawSample);
            Assert.Null(stream.NbFrames);
            Assert.Null(stream.SampleFmt);
            Assert.Null(stream.SampleRate);
            Assert.Null(stream.ChannelLayout);
            Assert.Null(stream.MaxBitRate);
        }

        /// <summary>
        ///     Tests that IsAudio returns true when the codec type is audio.
        /// </summary>
        [Fact]
        public void IsAudio_WhenCodecTypeAudio_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "audio" };
            Assert.True(stream.IsAudio);
            Assert.False(stream.IsVideo);
        }

        /// <summary>
        ///     Tests that IsVideo returns true when the codec type is video.
        /// </summary>
        [Fact]
        public void IsVideo_WhenCodecTypeVideo_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "video" };
            Assert.True(stream.IsVideo);
            Assert.False(stream.IsAudio);
        }

        /// <summary>
        ///     Tests that the codec type check handles leading and trailing white-space and case.
        /// </summary>
        [Fact]
        public void IsAudio_WithWhitespaceAndCase_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "  AUDIO  " };
            Assert.True(stream.IsAudio);
        }

        /// <summary>
        ///     Tests that IsAudio and IsVideo return false for an unknown codec type.
        /// </summary>
        [Fact]
        public void IsAudio_WithUnknownType_ReturnsFalse()
        {
            MediaStream stream = new MediaStream { CodecType = "subtitle" };
            Assert.False(stream.IsAudio);
            Assert.False(stream.IsVideo);
        }

        /// <summary>
        ///     Tests that SampleRateNumber parses a valid sample rate string.
        /// </summary>
        [Fact]
        public void SampleRateNumber_WithValidValue_ParsesCorrectly()
        {
            MediaStream stream = new MediaStream { SampleRate = "44100" };
            Assert.Equal(44100, stream.SampleRateNumber);
        }

        /// <summary>
        ///     Tests that SampleRateNumber returns negative one for a null sample rate.
        /// </summary>
        [Fact]
        public void SampleRateNumber_WithNullValue_ReturnsNegativeOne()
        {
            MediaStream stream = new MediaStream();
            Assert.Equal(-1, stream.SampleRateNumber);
        }

        /// <summary>
        ///     Tests that all scalar properties can be set and read back.
        /// </summary>
        [Fact]
        public void ScalarProperties_CanBeSetAndRead()
        {
            MediaStream stream = new MediaStream
            {
                Index = 1,
                Width = 1920,
                Height = 1080,
                CodedWidth = 1920,
                CodedHeight = 1088,
                HasBFrames = 2,
                Level = 51,
                Refs = 4,
                StartPts = 100,
                DurationTs = 2500,
                Channels = 2,
                BitsPerSample = 16
            };

            Assert.Equal(1, stream.Index);
            Assert.Equal(1920, stream.Width);
            Assert.Equal(1080, stream.Height);
            Assert.Equal(1920, stream.CodedWidth);
            Assert.Equal(1088, stream.CodedHeight);
            Assert.Equal(2, stream.HasBFrames);
            Assert.Equal(51, stream.Level);
            Assert.Equal(4, stream.Refs);
            Assert.Equal(100, stream.StartPts);
            Assert.Equal(2500, stream.DurationTs);
            Assert.Equal(2, stream.Channels);
            Assert.Equal(16, stream.BitsPerSample);
        }

        /// <summary>
        ///     Tests that string properties can be set and read back.
        /// </summary>
        [Fact]
        public void StringProperties_CanBeSetAndRead()
        {
            MediaStream stream = new MediaStream
            {
                CodecName = "h264",
                CodecLongName = "H.264 / AVC",
                Profile = "High",
                CodecType = "video",
                CodecTimeBase = "1/50",
                CodecTagString = "avc1",
                CodecTag = "0x31637661",
                SampleAspectRatio = "1:1",
                DisplayAspectRatio = "16:9",
                PixFmt = "yuv420p",
                ColorRange = "tv",
                ColorSpace = "bt709",
                ColorTransfer = "bt709",
                ColorPrimaries = "bt709",
                ChromaLocation = "left",
                IsAvc = "true",
                NalLengthSize = "4",
                RFrameRate = "50/1",
                AvgFrameRate = "50/1",
                TimeBase = "1/90000",
                StartTime = "0.000000",
                Duration = "2.000000",
                BitRate = "5000000",
                BitsPerRawSample = "8",
                NbFrames = "100",
                SampleFmt = "yuv420p",
                SampleRate = "48000",
                ChannelLayout = "stereo",
                MaxBitRate = "6000000"
            };

            Assert.Equal("h264", stream.CodecName);
            Assert.Equal("H.264 / AVC", stream.CodecLongName);
            Assert.Equal("High", stream.Profile);
            Assert.Equal("video", stream.CodecType);
            Assert.Equal("1/50", stream.CodecTimeBase);
            Assert.Equal("avc1", stream.CodecTagString);
            Assert.Equal("0x31637661", stream.CodecTag);
            Assert.Equal("1:1", stream.SampleAspectRatio);
            Assert.Equal("16:9", stream.DisplayAspectRatio);
            Assert.Equal("yuv420p", stream.PixFmt);
            Assert.Equal("tv", stream.ColorRange);
            Assert.Equal("bt709", stream.ColorSpace);
            Assert.Equal("bt709", stream.ColorTransfer);
            Assert.Equal("bt709", stream.ColorPrimaries);
            Assert.Equal("left", stream.ChromaLocation);
            Assert.Equal("true", stream.IsAvc);
            Assert.Equal("4", stream.NalLengthSize);
            Assert.Equal("50/1", stream.RFrameRate);
            Assert.Equal("50/1", stream.AvgFrameRate);
            Assert.Equal("1/90000", stream.TimeBase);
            Assert.Equal("0.000000", stream.StartTime);
            Assert.Equal("2.000000", stream.Duration);
            Assert.Equal("5000000", stream.BitRate);
            Assert.Equal("8", stream.BitsPerRawSample);
            Assert.Equal("100", stream.NbFrames);
            Assert.Equal("yuv420p", stream.SampleFmt);
            Assert.Equal("48000", stream.SampleRate);
            Assert.Equal("stereo", stream.ChannelLayout);
            Assert.Equal("6000000", stream.MaxBitRate);
        }

        /// <summary>
        ///     Tests that AvgFrameRateNumber can be set and read back.
        /// </summary>
        [Fact]
        public void AvgFrameRateNumber_CanBeSetAndRead()
        {
            MediaStream stream = new MediaStream { AvgFrameRateNumber = 29.97 };
            Assert.Equal(29.97, stream.AvgFrameRateNumber, 5);
        }

        /// <summary>
        ///     Tests that Disposition and Tags can be set and read back.
        /// </summary>
        [Fact]
        public void DispositionAndTags_CanBeSetAndRead()
        {
            Dictionary<string, int> disposition = new Dictionary<string, int> {["default"] = 1};
            StreamTags tags = new StreamTags { CreationTime = "2020", Language = "eng", HandlerName = "handler" };

            MediaStream stream = new MediaStream { Disposition = disposition, Tags = tags };

            Assert.Same(disposition, stream.Disposition);
            Assert.Same(tags, stream.Tags);
        }
    }
}
