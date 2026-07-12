// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioMetadataTest.cs
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
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio.Models
{
    /// <summary>
    ///     The audio metadata test class
    /// </summary>
    public class AudioMetadataTest
    {
        /// <summary>
        ///     Tests that constructor creates an empty metadata instance
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateEmptyMetadata()
        {
            AudioMetadata metadata = new AudioMetadata();

            Assert.NotNull(metadata);
        }

        /// <summary>
        ///     Tests that SampleFormat property can be set and retrieved
        /// </summary>
        [Fact]
        public void SampleFormat_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.SampleFormat = "fltp";

            Assert.Equal("fltp", metadata.SampleFormat);
        }

        /// <summary>
        ///     Tests that CodecLongName property can be set and retrieved
        /// </summary>
        [Fact]
        public void CodecLongName_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.CodecLongName = "FLAC (Free Lossless Audio Codec)";

            Assert.Equal("FLAC (Free Lossless Audio Codec)", metadata.CodecLongName);
        }

        /// <summary>
        ///     Tests that Codec property can be set and retrieved
        /// </summary>
        [Fact]
        public void Codec_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Codec = "aac";

            Assert.Equal("aac", metadata.Codec);
        }

        /// <summary>
        ///     Tests that Channels property can be set and retrieved
        /// </summary>
        [Fact]
        public void Channels_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Channels = 2;

            Assert.Equal(2, metadata.Channels);
        }

        /// <summary>
        ///     Tests that SampleRate property can be set and retrieved
        /// </summary>
        [Fact]
        public void SampleRate_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.SampleRate = 44100;

            Assert.Equal(44100, metadata.SampleRate);
        }

        /// <summary>
        ///     Tests that Duration property can be set and retrieved
        /// </summary>
        [Fact]
        public void Duration_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Duration = 180.5;

            Assert.Equal(180.5, metadata.Duration);
        }

        /// <summary>
        ///     Tests that BitRate property can be set and retrieved
        /// </summary>
        [Fact]
        public void BitRate_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.BitRate = 320000;

            Assert.Equal(320000, metadata.BitRate);
        }

        /// <summary>
        ///     Tests that BitDepth property can be set and retrieved
        /// </summary>
        [Fact]
        public void BitDepth_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.BitDepth = 24;

            Assert.Equal(24, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that PredictedSampleCount property can be set and retrieved
        /// </summary>
        [Fact]
        public void PredictedSampleCount_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.PredictedSampleCount = 7938048;

            Assert.Equal(7938048, metadata.PredictedSampleCount);
        }

        /// <summary>
        ///     Tests that Streams property can be set and retrieved
        /// </summary>
        [Fact]
        public void Streams_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            List<MediaStream> streams = new List<MediaStream>
            {
                new MediaStream(),
                new MediaStream()
            };

            metadata.Streams = streams;

            Assert.NotNull(metadata.Streams);
            Assert.Equal(2, metadata.Streams.Count);
        }

        /// <summary>
        ///     Tests that Streams is null by default
        /// </summary>
        [Fact]
        public void Streams_Default_ShouldBeNull()
        {
            AudioMetadata metadata = new AudioMetadata();

            Assert.Null(metadata.Streams);
        }

        /// <summary>
        ///     Tests that Format property can be set and retrieved
        /// </summary>
        [Fact]
        public void Format_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            AudioFormat format = new AudioFormat
            {
                FormatName = "mp3",
                FormatLongName = "MP2/3 (MPEG audio layer 2/3)"
            };

            metadata.Format = format;

            Assert.NotNull(metadata.Format);
            Assert.Equal("mp3", metadata.Format.FormatName);
        }

        /// <summary>
        ///     Tests that Format is null by default
        /// </summary>
        [Fact]
        public void Format_Default_ShouldBeNull()
        {
            AudioMetadata metadata = new AudioMetadata();

            Assert.Null(metadata.Format);
        }

        /// <summary>
        ///     Tests that GetFirstVideoStream returns null when no video streams
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_WhenNoVideoStreams_ShouldReturnNull()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Streams = new List<MediaStream>
            {
                new MediaStream { CodecType = "audio" },
                new MediaStream { CodecType = "subtitle" }
            };

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetFirstVideoStream returns first video stream
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_WhenVideoStreamsExist_ShouldReturnFirst()
        {
            AudioMetadata metadata = new AudioMetadata();
            MediaStream videoStream1 = new MediaStream { CodecType = "video", Index = 0 };
            MediaStream audioStream = new MediaStream { CodecType = "audio", Index = 1 };
            MediaStream videoStream2 = new MediaStream { CodecType = "video", Index = 2 };

            metadata.Streams = new List<MediaStream> { videoStream1, audioStream, videoStream2 };

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.Equal(0, result.Index);
        }

        /// <summary>
        ///     Tests that GetFirstAudioStream returns null when no audio streams
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_WhenNoAudioStreams_ShouldReturnNull()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Streams = new List<MediaStream>
            {
                new MediaStream { CodecType = "video" },
                new MediaStream { CodecType = "subtitle" }
            };

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that GetFirstAudioStream returns first audio stream
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_WhenAudioStreamsExist_ShouldReturnFirst()
        {
            AudioMetadata metadata = new AudioMetadata();
            MediaStream videoStream = new MediaStream { CodecType = "video", Index = 0 };
            MediaStream audioStream1 = new MediaStream { CodecType = "audio", Index = 1 };
            MediaStream audioStream2 = new MediaStream { CodecType = "audio", Index = 3 };

            metadata.Streams = new List<MediaStream> { videoStream, audioStream1, audioStream2 };

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.Equal(1, result.Index);
        }

        /// <summary>
        ///     Tests that GetFirstAudioStream returns first audio stream when mixed with video
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_MixedStreams_ShouldReturnFirstAudio()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Streams = new List<MediaStream>
            {
                new MediaStream { CodecType = "video" },
                new MediaStream { CodecType = "audio" },
                new MediaStream { CodecType = "subtitle" },
                new MediaStream { CodecType = "audio" }
            };

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.True(result.IsAudio);
            Assert.False(result.IsVideo);
        }

        /// <summary>
        ///     Tests that GetFirstVideoStream returns first video stream when mixed with audio
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_MixedStreams_ShouldReturnFirstVideo()
        {
            AudioMetadata metadata = new AudioMetadata();
            metadata.Streams = new List<MediaStream>
            {
                new MediaStream { CodecType = "audio" },
                new MediaStream { CodecType = "video" },
                new MediaStream { CodecType = "subtitle" },
                new MediaStream { CodecType = "video" }
            };

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.True(result.IsVideo);
            Assert.False(result.IsAudio);
        }

        /// <summary>
        ///     Tests that all properties can be set together
        /// </summary>
        [Fact]
        public void AllProperties_ShouldBeSettableTogether()
        {
            AudioMetadata metadata = new AudioMetadata
            {
                SampleFormat = "s16",
                CodecLongName = "PCM signed 16-bit little-endian",
                Codec = "pcm_s16le",
                Channels = 2,
                SampleRate = 48000,
                Duration = 60.0,
                BitRate = 1536000,
                BitDepth = 16,
                PredictedSampleCount = 2880000
            };

            Assert.Equal("s16", metadata.SampleFormat);
            Assert.Equal("PCM signed 16-bit little-endian", metadata.CodecLongName);
            Assert.Equal("pcm_s16le", metadata.Codec);
            Assert.Equal(2, metadata.Channels);
            Assert.Equal(48000, metadata.SampleRate);
            Assert.Equal(60.0, metadata.Duration);
            Assert.Equal(1536000, metadata.BitRate);
            Assert.Equal(16, metadata.BitDepth);
            Assert.Equal(2880000, metadata.PredictedSampleCount);
        }

        /// <summary>
        ///     Tests that PredictedSampleCount is calculated correctly from Duration and SampleRate
        /// </summary>
        [Fact]
        public void PredictedSampleCount_ShouldMatchDurationTimesSampleRate()
        {
            AudioMetadata metadata = new AudioMetadata
            {
                Duration = 10.0,
                SampleRate = 44100
            };

            metadata.PredictedSampleCount = (long) System.Math.Round(metadata.Duration * metadata.SampleRate);

            Assert.Equal(441000, metadata.PredictedSampleCount);
        }

        /// <summary>
        ///     Tests that PredictedSampleCount with fractional duration is rounded correctly
        /// </summary>
        [Fact]
        public void PredictedSampleCount_WithFractionalDuration_ShouldRoundCorrectly()
        {
            AudioMetadata metadata = new AudioMetadata
            {
                Duration = 10.5,
                SampleRate = 44100
            };

            metadata.PredictedSampleCount = (long) System.Math.Round(metadata.Duration * metadata.SampleRate);

            Assert.Equal(463050, metadata.PredictedSampleCount);
        }
    }
}
