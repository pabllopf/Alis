// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoMetadataCoverageTests.cs
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

using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video.Models
{
    /// <summary>
    /// The video metadata coverage tests class
    /// </summary>
    public class VideoMetadataCoverageTests
    {
        /// <summary>
        /// Tests that parameterized constructor should set all properties
        /// </summary>
        [Fact]
        public void ParameterizedConstructor_ShouldSetAllProperties()
        {
            VideoFormat format = new VideoFormat();
            MediaStream[] streams = new[]
            {
                new MediaStream { CodecType = "video" },
                new MediaStream { CodecType = "audio" }
            };

            VideoMetadata sut = new VideoMetadata(
                pixelFormat: "yuv420p",
                codecLongName: "H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10",
                codec: "h264",
                size: (1920, 1080),
                duration: 120.5,
                avgFramerate: 29.97,
                bitRate: 5000000,
                bitDepth: 8,
                sampleAspectRatio: "1:1",
                predictedFrameCount: 3600,
                streams: streams,
                format: format
            );

            Assert.Equal("yuv420p", sut.PixelFormat);
            Assert.Equal("H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10", sut.CodecLongName);
            Assert.Equal("h264", sut.Codec);
            Assert.Equal(1920, sut.Width);
            Assert.Equal(1080, sut.Height);
            Assert.Equal(120.5, sut.Duration);
            Assert.Equal(29.97, sut.AvgFramerate);
            Assert.Equal(5000000, sut.BitRate);
            Assert.Equal(8, sut.BitDepth);
            Assert.Equal("1:1", sut.SampleAspectRatio);
            Assert.Equal(3600, sut.PredictedFrameCount);
            Assert.Same(streams, sut.Streams);
            Assert.Same(format, sut.Format);
        }

        /// <summary>
        /// Tests that pixel format should round trip
        /// </summary>
        [Fact]
        public void PixelFormat_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            string value = "yuv444p";

            sut.PixelFormat = value;

            Assert.Equal(value, sut.PixelFormat);
        }

        /// <summary>
        /// Tests that pixel format default should be empty
        /// </summary>
        [Fact]
        public void PixelFormat_Default_ShouldBeEmpty()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(string.Empty, sut.PixelFormat);
        }

        /// <summary>
        /// Tests that codec long name should round trip
        /// </summary>
        [Fact]
        public void CodecLongName_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            string value = "HEVC (High Efficiency Video Coding)";

            sut.CodecLongName = value;

            Assert.Equal(value, sut.CodecLongName);
        }

        /// <summary>
        /// Tests that codec long name default should be empty
        /// </summary>
        [Fact]
        public void CodecLongName_Default_ShouldBeEmpty()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(string.Empty, sut.CodecLongName);
        }

        /// <summary>
        /// Tests that avg framerate should round trip
        /// </summary>
        [Fact]
        public void AvgFramerate_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            double value = 60.0;

            sut.AvgFramerate = value;

            Assert.Equal(value, sut.AvgFramerate);
        }

        /// <summary>
        /// Tests that avg framerate default should be zero
        /// </summary>
        [Fact]
        public void AvgFramerate_Default_ShouldBeZero()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(0.0, sut.AvgFramerate);
        }

        /// <summary>
        /// Tests that avg framerate should handle fractional values
        /// </summary>
        [Fact]
        public void AvgFramerate_ShouldHandleFractionalValues()
        {
            VideoMetadata sut = new VideoMetadata();
            double value = 23.976;

            sut.AvgFramerate = value;

            Assert.Equal(value, sut.AvgFramerate, 3);
        }

        /// <summary>
        /// Tests that avg framerate should handle negative value
        /// </summary>
        [Fact]
        public void AvgFramerate_ShouldHandleNegativeValue()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.AvgFramerate = -1.0;

            Assert.Equal(-1.0, sut.AvgFramerate);
        }

        /// <summary>
        /// Tests that bit depth should round trip
        /// </summary>
        [Fact]
        public void BitDepth_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            int value = 10;

            sut.BitDepth = value;

            Assert.Equal(value, sut.BitDepth);
        }

        /// <summary>
        /// Tests that bit depth default should be zero
        /// </summary>
        [Fact]
        public void BitDepth_Default_ShouldBeZero()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(0, sut.BitDepth);
        }

        /// <summary>
        /// Tests that bit depth should handle max value
        /// </summary>
        [Fact]
        public void BitDepth_ShouldHandleMaxValue()
        {
            VideoMetadata sut = new VideoMetadata();
            int value = int.MaxValue;

            sut.BitDepth = value;

            Assert.Equal(value, sut.BitDepth);
        }

        /// <summary>
        /// Tests that sample aspect ratio should round trip
        /// </summary>
        [Fact]
        public void SampleAspectRatio_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            string value = "16:9";

            sut.SampleAspectRatio = value;

            Assert.Equal(value, sut.SampleAspectRatio);
        }

        /// <summary>
        /// Tests that sample aspect ratio default should be empty
        /// </summary>
        [Fact]
        public void SampleAspectRatio_Default_ShouldBeEmpty()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(string.Empty, sut.SampleAspectRatio);
        }

        /// <summary>
        /// Tests that sample aspect ratio should handle null
        /// </summary>
        [Fact]
        public void SampleAspectRatio_ShouldHandleNull()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.SampleAspectRatio = null;

            Assert.Null(sut.SampleAspectRatio);
        }

        /// <summary>
        /// Tests that predicted frame count should round trip
        /// </summary>
        [Fact]
        public void PredictedFrameCount_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            int value = 1800;

            sut.PredictedFrameCount = value;

            Assert.Equal(value, sut.PredictedFrameCount);
        }

        /// <summary>
        /// Tests that predicted frame count default should be zero
        /// </summary>
        [Fact]
        public void PredictedFrameCount_Default_ShouldBeZero()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(0, sut.PredictedFrameCount);
        }

        /// <summary>
        /// Tests that predicted frame count should handle negative value
        /// </summary>
        [Fact]
        public void PredictedFrameCount_ShouldHandleNegativeValue()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.PredictedFrameCount = -1;

            Assert.Equal(-1, sut.PredictedFrameCount);
        }

        /// <summary>
        /// Tests that codec should round trip
        /// </summary>
        [Fact]
        public void Codec_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            string value = "hevc";

            sut.Codec = value;

            Assert.Equal(value, sut.Codec);
        }

        /// <summary>
        /// Tests that codec default should be empty
        /// </summary>
        [Fact]
        public void Codec_Default_ShouldBeEmpty()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(string.Empty, sut.Codec);
        }

        /// <summary>
        /// Tests that width should round trip
        /// </summary>
        [Fact]
        public void Width_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            int value = 640;

            sut.Width = value;

            Assert.Equal(value, sut.Width);
        }

        /// <summary>
        /// Tests that height should round trip
        /// </summary>
        [Fact]
        public void Height_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            int value = 480;

            sut.Height = value;

            Assert.Equal(value, sut.Height);
        }

        /// <summary>
        /// Tests that duration should round trip
        /// </summary>
        [Fact]
        public void Duration_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            double value = 3600.0;

            sut.Duration = value;

            Assert.Equal(value, sut.Duration);
        }

        /// <summary>
        /// Tests that duration should handle negative
        /// </summary>
        [Fact]
        public void Duration_ShouldHandleNegative()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.Duration = -1.0;

            Assert.Equal(-1.0, sut.Duration);
        }

        /// <summary>
        /// Tests that bit rate should round trip
        /// </summary>
        [Fact]
        public void BitRate_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            int value = 10000000;

            sut.BitRate = value;

            Assert.Equal(value, sut.BitRate);
        }

        /// <summary>
        /// Tests that bit rate default should be zero
        /// </summary>
        [Fact]
        public void BitRate_Default_ShouldBeZero()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(0, sut.BitRate);
        }

        /// <summary>
        /// Tests that streams should round trip
        /// </summary>
        [Fact]
        public void Streams_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            MediaStream[] streams = new[]
            {
                new MediaStream { CodecType = "video" },
                new MediaStream { CodecType = "audio" },
                new MediaStream { CodecType = "subtitle" }
            };

            sut.Streams = streams;

            Assert.Same(streams, sut.Streams);
        }

        /// <summary>
        /// Tests that streams default should be empty array
        /// </summary>
        [Fact]
        public void Streams_Default_ShouldBeEmptyArray()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.NotNull(sut.Streams);
            Assert.Empty(sut.Streams);
        }

        /// <summary>
        /// Tests that streams should handle null
        /// </summary>
        [Fact]
        public void Streams_ShouldHandleNull()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.Streams = null;

            Assert.Null(sut.Streams);
        }

        /// <summary>
        /// Tests that format should round trip
        /// </summary>
        [Fact]
        public void Format_ShouldRoundTrip()
        {
            VideoMetadata sut = new VideoMetadata();
            VideoFormat format = new VideoFormat();

            sut.Format = format;

            Assert.Same(format, sut.Format);
        }

        /// <summary>
        /// Tests that format default should be not null
        /// </summary>
        [Fact]
        public void Format_Default_ShouldBeNotNull()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.NotNull(sut.Format);
        }

        /// <summary>
        /// Tests that width and height should be settable independently
        /// </summary>
        [Fact]
        public void WidthAndHeight_ShouldBeSettableIndependently()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.Width = 1920;
            sut.Height = 1080;

            Assert.Equal(1920, sut.Width);
            Assert.Equal(1080, sut.Height);
        }

        /// <summary>
        /// Tests that pixel format and codec should be settable independently
        /// </summary>
        [Fact]
        public void PixelFormatAndCodec_ShouldBeSettableIndependently()
        {
            VideoMetadata sut = new VideoMetadata();

            sut.PixelFormat = "nv12";
            sut.Codec = "vp9";

            Assert.Equal("nv12", sut.PixelFormat);
            Assert.Equal("vp9", sut.Codec);
        }

        /// <summary>
        /// Tests that multiple properties should set and get consistently
        /// </summary>
        [Fact]
        public void MultipleProperties_ShouldSetAndGetConsistently()
        {
            VideoMetadata sut = new VideoMetadata();
            double duration = 90.0;

            sut.Duration = duration;
            sut.AvgFramerate = 30;
            sut.BitRate = 2000000;
            sut.BitDepth = 8;
            sut.SampleAspectRatio = "4:3";
            sut.PredictedFrameCount = 2700;

            Assert.Equal(duration, sut.Duration);
            Assert.Equal(30, sut.AvgFramerate);
            Assert.Equal(2000000, sut.BitRate);
            Assert.Equal(8, sut.BitDepth);
            Assert.Equal("4:3", sut.SampleAspectRatio);
            Assert.Equal(2700, sut.PredictedFrameCount);
        }

        /// <summary>
        /// Tests that parameterless constructor should initialize with defaults
        /// </summary>
        [Fact]
        public void ParameterlessConstructor_ShouldInitializeWithDefaults()
        {
            VideoMetadata sut = new VideoMetadata();

            Assert.Equal(string.Empty, sut.PixelFormat);
            Assert.Equal(string.Empty, sut.CodecLongName);
            Assert.Equal(string.Empty, sut.Codec);
            Assert.Equal(0, sut.Width);
            Assert.Equal(0, sut.Height);
            Assert.Equal(0.0, sut.Duration);
            Assert.Equal(0.0, sut.AvgFramerate);
            Assert.Equal(0, sut.BitRate);
            Assert.Equal(0, sut.BitDepth);
            Assert.Equal(string.Empty, sut.SampleAspectRatio);
            Assert.Equal(0, sut.PredictedFrameCount);
            Assert.NotNull(sut.Streams);
            Assert.Empty(sut.Streams);
            Assert.NotNull(sut.Format);
        }

        /// <summary>
        /// Tests that get first video stream when streams null should throw argument null exception
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_WhenStreamsNull_ShouldThrowArgumentNullException()
        {
            VideoMetadata sut = new VideoMetadata();
            sut.Streams = null;

            Assert.Throws<System.ArgumentNullException>(() => sut.GetFirstVideoStream());
        }

        /// <summary>
        /// Tests that get first audio stream when streams null should throw argument null exception
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_WhenStreamsNull_ShouldThrowArgumentNullException()
        {
            VideoMetadata sut = new VideoMetadata();
            sut.Streams = null;

            Assert.Throws<System.ArgumentNullException>(() => sut.GetFirstAudioStream());
        }
    }
}
