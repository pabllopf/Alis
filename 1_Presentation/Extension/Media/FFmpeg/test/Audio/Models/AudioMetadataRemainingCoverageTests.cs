// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioMetadataRemainingCoverageTests.cs
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
    ///     The audio metadata remaining coverage tests class
    /// </summary>
    public class AudioMetadataRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the constructor creates a non-null instance
        /// </summary>
        [Fact]
        public void Constructor_CreatesNonNullInstance()
        {
            AudioMetadata audioMetadata = new AudioMetadata();

            Assert.NotNull(audioMetadata);
        }

        /// <summary>
        ///     Verifies that the SampleFormat property round-trips the value fltp
        /// </summary>
        [Fact]
        public void SampleFormat_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.SampleFormat = "fltp";

            Assert.Equal("fltp", audioMetadata.SampleFormat);
        }

        /// <summary>
        ///     Verifies that the CodecLongName property round-trips its value
        /// </summary>
        [Fact]
        public void CodecLongName_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.CodecLongName = "MP3 (MPEG audio layer 3)";

            Assert.Equal("MP3 (MPEG audio layer 3)", audioMetadata.CodecLongName);
        }

        /// <summary>
        ///     Verifies that the Codec property round-trips its value
        /// </summary>
        [Fact]
        public void Codec_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.Codec = "mp3";

            Assert.Equal("mp3", audioMetadata.Codec);
        }

        /// <summary>
        ///     Verifies that the Channels property round-trips the value 2
        /// </summary>
        [Fact]
        public void Channels_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.Channels = 2;

            Assert.Equal(2, audioMetadata.Channels);
        }

        /// <summary>
        ///     Verifies that the SampleRate property round-trips the value 44100
        /// </summary>
        [Fact]
        public void SampleRate_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.SampleRate = 44100;

            Assert.Equal(44100, audioMetadata.SampleRate);
        }

        /// <summary>
        ///     Verifies that the Duration property round-trips the value 180.5
        /// </summary>
        [Fact]
        public void Duration_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.Duration = 180.5;

            Assert.Equal(180.5, audioMetadata.Duration, 5);
        }

        /// <summary>
        ///     Verifies that the BitRate property round-trips the value 320000
        /// </summary>
        [Fact]
        public void BitRate_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.BitRate = 320000;

            Assert.Equal(320000, audioMetadata.BitRate);
        }

        /// <summary>
        ///     Verifies that the BitDepth property round-trips the value 16
        /// </summary>
        [Fact]
        public void BitDepth_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.BitDepth = 16;

            Assert.Equal(16, audioMetadata.BitDepth);
        }

        /// <summary>
        ///     Verifies that the PredictedSampleCount property round-trips its value
        /// </summary>
        [Fact]
        public void PredictedSampleCount_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            audioMetadata.PredictedSampleCount = 44100L * 180;

            Assert.Equal(44100L * 180, audioMetadata.PredictedSampleCount);
        }

        /// <summary>
        ///     Verifies that the Streams property round-trips a list of media streams
        /// </summary>
        [Fact]
        public void Streams_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            List<MediaStream> streams = new List<MediaStream>
            {
                new MediaStream { CodecType = "audio" },
                new MediaStream { CodecType = "video" },
            };
            audioMetadata.Streams = streams;

            Assert.Same(streams, audioMetadata.Streams);
            Assert.Equal(2, audioMetadata.Streams.Count);
        }

        /// <summary>
        ///     Verifies that the Streams property defaults to null
        /// </summary>
        [Fact]
        public void Streams_DefaultIsNull()
        {
            AudioMetadata audioMetadata = new AudioMetadata();

            Assert.Null(audioMetadata.Streams);
        }

        /// <summary>
        ///     Verifies that the Format property round-trips an audio format instance
        /// </summary>
        [Fact]
        public void Format_RoundTrip()
        {
            AudioMetadata audioMetadata = new AudioMetadata();
            AudioFormat format = new AudioFormat { Filename = "test.mp3", NbStreams = 1L };
            audioMetadata.Format = format;

            Assert.Same(format, audioMetadata.Format);
            Assert.Equal("test.mp3", audioMetadata.Format.Filename);
        }

        /// <summary>
        ///     Verifies that the Format property defaults to null
        /// </summary>
        [Fact]
        public void Format_DefaultIsNull()
        {
            AudioMetadata audioMetadata = new AudioMetadata();

            Assert.Null(audioMetadata.Format);
        }

        /// <summary>
        ///     Verifies that GetFirstVideoStream returns the first video stream
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_ReturnsVideoStream()
        {
            AudioMetadata audioMetadata = new AudioMetadata
            {
                Streams = new List<MediaStream>
                {
                    new MediaStream { CodecType = "video" },
                    new MediaStream { CodecType = "audio" },
                },
            };

            MediaStream result = audioMetadata.GetFirstVideoStream();

            Assert.NotNull(result);
            Assert.True(result.IsVideo);
        }

        /// <summary>
        ///     Verifies that GetFirstAudioStream returns the first audio stream
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_ReturnsAudioStream()
        {
            AudioMetadata audioMetadata = new AudioMetadata
            {
                Streams = new List<MediaStream>
                {
                    new MediaStream { CodecType = "video" },
                    new MediaStream { CodecType = "audio" },
                },
            };

            MediaStream result = audioMetadata.GetFirstAudioStream();

            Assert.NotNull(result);
            Assert.True(result.IsAudio);
        }

        /// <summary>
        ///     Verifies that GetFirstVideoStream returns null when no video stream is present
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_NoVideoStream_ReturnsNull()
        {
            AudioMetadata audioMetadata = new AudioMetadata
            {
                Streams = new List<MediaStream>
                {
                    new MediaStream { CodecType = "audio" },
                    new MediaStream { CodecType = "audio" },
                },
            };

            MediaStream result = audioMetadata.GetFirstVideoStream();

            Assert.Null(result);
        }

        /// <summary>
        ///     Verifies that GetFirstAudioStream returns null when no audio stream is present
        /// </summary>
        [Fact]
        public void GetFirstAudioStream_NoAudioStream_ReturnsNull()
        {
            AudioMetadata audioMetadata = new AudioMetadata
            {
                Streams = new List<MediaStream>
                {
                    new MediaStream { CodecType = "video" },
                    new MediaStream { CodecType = "video" },
                },
            };

            MediaStream result = audioMetadata.GetFirstAudioStream();

            Assert.Null(result);
        }

        /// <summary>
        ///     Verifies that GetFirstVideoStream returns null when the streams list is empty
        /// </summary>
        [Fact]
        public void GetFirstVideoStream_EmptyStreams_ReturnsNull()
        {
            AudioMetadata audioMetadata = new AudioMetadata
            {
                Streams = new List<MediaStream>(),
            };

            MediaStream result = audioMetadata.GetFirstVideoStream();

            Assert.Null(result);
        }
    }
}