// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaStreamTest.cs
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
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The media stream test class
    /// </summary>
    /// <seealso cref="MediaStream" />
    public class MediaStreamTest
    {
        /// <summary>
        ///     Tests that media stream constructor should create instance
        /// </summary>
        [Fact]
        public void MediaStream_Constructor_ShouldCreateInstance()
        {
            // Arrange & Act
            MediaStream stream = new MediaStream();

            // Assert
            Assert.NotNull(stream);
        }

        /// <summary>
        ///     Tests that media stream codec name property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_CodecNameProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            string codecName = "h264";

            // Act
            stream.CodecName = codecName;

            // Assert
            Assert.Equal(codecName, stream.CodecName);
        }

        /// <summary>
        ///     Tests that media stream codec type property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_CodecTypeProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            string codecType = "video";

            // Act
            stream.CodecType = codecType;

            // Assert
            Assert.Equal(codecType, stream.CodecType);
        }

        /// <summary>
        ///     Tests that media stream is audio should return true for audio codec type
        /// </summary>
        [Fact]
        public void MediaStream_IsAudio_ShouldReturnTrueForAudioCodecType()
        {
            // Arrange
            MediaStream stream = new MediaStream { CodecType = "audio" };

            // Act
            bool isAudio = stream.IsAudio;

            // Assert
            Assert.True(isAudio);
        }

        /// <summary>
        ///     Tests that media stream is video should return true for video codec type
        /// </summary>
        [Fact]
        public void MediaStream_IsVideo_ShouldReturnTrueForVideoCodecType()
        {
            // Arrange
            MediaStream stream = new MediaStream { CodecType = "video" };

            // Act
            bool isVideo = stream.IsVideo;

            // Assert
            Assert.True(isVideo);
        }

        /// <summary>
        ///     Tests that media stream is audio should be case insensitive
        /// </summary>
        [Fact]
        public void MediaStream_IsAudio_ShouldBeCaseInsensitive()
        {
            // Arrange
            MediaStream stream1 = new MediaStream { CodecType = "AUDIO" };
            MediaStream stream2 = new MediaStream { CodecType = "Audio" };
            MediaStream stream3 = new MediaStream { CodecType = "audio" };

            // Act & Assert
            Assert.True(stream1.IsAudio);
            Assert.True(stream2.IsAudio);
            Assert.True(stream3.IsAudio);
        }

        /// <summary>
        ///     Tests that media stream is video should be case insensitive
        /// </summary>
        [Fact]
        public void MediaStream_IsVideo_ShouldBeCaseInsensitive()
        {
            // Arrange
            MediaStream stream1 = new MediaStream { CodecType = "VIDEO" };
            MediaStream stream2 = new MediaStream { CodecType = "Video" };
            MediaStream stream3 = new MediaStream { CodecType = "video" };

            // Act & Assert
            Assert.True(stream1.IsVideo);
            Assert.True(stream2.IsVideo);
            Assert.True(stream3.IsVideo);
        }

        /// <summary>
        ///     Tests that media stream width property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_WidthProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            int width = 1920;

            // Act
            stream.Width = width;

            // Assert
            Assert.Equal(width, stream.Width);
        }

        /// <summary>
        ///     Tests that media stream height property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_HeightProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            int height = 1080;

            // Act
            stream.Height = height;

            // Assert
            Assert.Equal(height, stream.Height);
        }

        /// <summary>
        ///     Tests that media stream sample rate property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_SampleRateProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            string sampleRate = "44100";

            // Act
            stream.SampleRate = sampleRate;

            // Assert
            Assert.Equal(sampleRate, stream.SampleRate);
        }

        /// <summary>
        ///     Tests that media stream sample rate number should parse string correctly
        /// </summary>
        [Fact]
        public void MediaStream_SampleRateNumber_ShouldParseStringCorrectly()
        {
            // Arrange
            MediaStream stream = new MediaStream { SampleRate = "44100" };

            // Act
            int sampleRateNumber = stream.SampleRateNumber;

            // Assert
            Assert.Equal(44100, sampleRateNumber);
        }

        /// <summary>
        ///     Tests that media stream sample rate number should return negative one for null
        /// </summary>
        [Fact]
        public void MediaStream_SampleRateNumber_ShouldReturnNegativeOneForNull()
        {
            // Arrange
            MediaStream stream = new MediaStream { SampleRate = null };

            // Act
            int sampleRateNumber = stream.SampleRateNumber;

            // Assert
            Assert.Equal(-1, sampleRateNumber);
        }

        /// <summary>
        ///     Tests that media stream sample rate number should return negative one for empty string
        /// </summary>
        [Fact]
        public void MediaStream_SampleRateNumber_ShouldReturnNegativeOneForEmptyString()
        {
            // Arrange
            MediaStream stream = new MediaStream { SampleRate = string.Empty };

            // Act
            int sampleRateNumber = stream.SampleRateNumber;

            // Assert
            Assert.Equal(-1, sampleRateNumber);
        }

        /// <summary>
        ///     Tests that media stream channels property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_ChannelsProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            int channels = 2;

            // Act
            stream.Channels = channels;

            // Assert
            Assert.Equal(channels, stream.Channels);
        }

        /// <summary>
        ///     Tests that media stream bit rate property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_BitRateProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            string bitRate = "320000";

            // Act
            stream.BitRate = bitRate;

            // Assert
            Assert.Equal(bitRate, stream.BitRate);
        }

        /// <summary>
        ///     Tests that media stream tags property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_TagsProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            StreamTags tags = new StreamTags();

            // Act
            stream.Tags = tags;

            // Assert
            Assert.Equal(tags, stream.Tags);
        }

        /// <summary>
        ///     Tests that media stream should support common video codecs
        /// </summary>
        [Fact]
        public void MediaStream_ShouldSupportCommonVideoCodecs()
        {
            // Arrange & Act
            MediaStream h264Stream = new MediaStream { CodecName = "h264", CodecType = "video" };
            MediaStream h265Stream = new MediaStream { CodecName = "hevc", CodecType = "video" };
            MediaStream vp9Stream = new MediaStream { CodecName = "vp9", CodecType = "video" };

            // Assert
            Assert.True(h264Stream.IsVideo);
            Assert.True(h265Stream.IsVideo);
            Assert.True(vp9Stream.IsVideo);
        }

        /// <summary>
        ///     Tests that media stream should support common audio codecs
        /// </summary>
        [Fact]
        public void MediaStream_ShouldSupportCommonAudioCodecs()
        {
            // Arrange & Act
            MediaStream mp3Stream = new MediaStream { CodecName = "mp3", CodecType = "audio" };
            MediaStream aacStream = new MediaStream { CodecName = "aac", CodecType = "audio" };
            MediaStream vorbisStream = new MediaStream { CodecName = "vorbis", CodecType = "audio" };

            // Assert
            Assert.True(mp3Stream.IsAudio);
            Assert.True(aacStream.IsAudio);
            Assert.True(vorbisStream.IsAudio);
        }

        /// <summary>
        ///     Tests that media stream index property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_IndexProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            long index = 0;

            // Act
            stream.Index = index;

            // Assert
            Assert.Equal(index, stream.Index);
        }

        /// <summary>
        ///     Tests that media stream duration property should be settable
        /// </summary>
        [Fact]
        public void MediaStream_DurationProperty_ShouldBeSettable()
        {
            // Arrange
            MediaStream stream = new MediaStream();
            string duration = "180.000000";

            // Act
            stream.Duration = duration;

            // Assert
            Assert.Equal(duration, stream.Duration);
        }

        /// <summary>
        ///     Tests that media stream should support initializer syntax
        /// </summary>
        [Fact]
        public void MediaStream_ShouldSupportInitializerSyntax()
        {
            // Arrange & Act
            MediaStream stream = new MediaStream
            {
                CodecName = "h264",
                CodecType = "video",
                Width = 1920,
                Height = 1080,
                BitRate = "8000000"
            };

            // Assert
            Assert.Equal("h264", stream.CodecName);
            Assert.Equal("video", stream.CodecType);
            Assert.Equal(1920, stream.Width);
            Assert.Equal(1080, stream.Height);
            Assert.Equal("8000000", stream.BitRate);
        }

        /// <summary>
        ///     Tests that media stream is audio should handle whitespace
        /// </summary>
        [Fact]
        public void MediaStream_IsAudio_ShouldHandleWhitespace()
        {
            // Arrange
            MediaStream stream = new MediaStream { CodecType = "  audio  " };

            // Act
            bool isAudio = stream.IsAudio;

            // Assert
            Assert.True(isAudio);
        }

        /// <summary>
        ///     Tests that media stream is video should handle whitespace
        /// </summary>
        [Fact]
        public void MediaStream_IsVideo_ShouldHandleWhitespace()
        {
            // Arrange
            MediaStream stream = new MediaStream { CodecType = "  video  " };

            // Act
            bool isVideo = stream.IsVideo;

            // Assert
            Assert.True(isVideo);
        }
    }
}

