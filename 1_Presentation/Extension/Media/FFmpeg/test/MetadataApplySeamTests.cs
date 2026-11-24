// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:MetadataApplySeamTests.cs
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
using System.Collections.Generic;
using System.IO;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video;
using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     Covers ffprobe metadata mapping through injectable metadata seams.
    /// </summary>
    public class MetadataApplySeamTests : IDisposable
    {
        private readonly string _tempFile = Path.GetTempFileName();

        public void Dispose()
        {
            if (File.Exists(_tempFile))
            {
                File.Delete(_tempFile);
            }
        }

        [Fact]
        public void ApplyAudioMetadata_WithAudioStream_PopulatesDerivedFields()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            AudioMetadata metadata = new AudioMetadata
            {
                Format = new AudioFormat { Duration = "2.0" },
                Streams = new List<MediaStream>
                {
                    new MediaStream
                    {
                        CodecType = "audio",
                        Channels = 2,
                        CodecName = "aac",
                        CodecLongName = "AAC",
                        SampleFmt = "fltp",
                        SampleRate = "48000",
                        Duration = "1.5",
                        BitRate = "128000",
                        BitsPerSample = 16
                    }
                }
            };

            reader.ApplyAudioMetadata(metadata, false);

            Assert.True(reader.MetadataLoaded);
            Assert.Same(metadata, reader.Metadata);
            Assert.Equal("aac", metadata.Codec);
            Assert.Equal(48000, metadata.SampleRate);
            Assert.Equal(1.5, metadata.Duration);
            Assert.Equal(128000, metadata.BitRate);
            Assert.Equal(16, metadata.BitDepth);
            Assert.Equal(72000, metadata.PredictedSampleCount);
        }

        [Fact]
        public void ApplyAudioMetadata_WithInvalidStream_ThrowsWhenErrorsAreNotIgnored()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            AudioMetadata metadata = new AudioMetadata
            {
                Format = new AudioFormat { Duration = "2.0" },
                Streams = new List<MediaStream> { new MediaStream { CodecType = "audio", SampleRate = "invalid" } }
            };

            InvalidDataException exception = Assert.Throws<InvalidDataException>(() => reader.ApplyAudioMetadata(metadata, false));

            Assert.Contains("Failed to parse audio stream data!", exception.Message);
        }

        [Fact]
        public void ApplyAudioMetadata_WithInvalidStream_IgnoresErrorWhenRequested()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            AudioMetadata metadata = new AudioMetadata
            {
                Format = new AudioFormat { Duration = "2.0" },
                Streams = new List<MediaStream> { new MediaStream { CodecType = "audio", SampleRate = "invalid" } }
            };

            reader.ApplyAudioMetadata(metadata, true);

            Assert.True(reader.MetadataLoaded);
            Assert.Same(metadata, reader.Metadata);
        }

        [Fact]
        public void ApplyAudioMetadataJson_WithEmptyPayload_LeavesDefaults()
        {
            using AudioReader reader = new AudioReader(_tempFile);

            reader.ApplyAudioMetadataJson("{}", true);

            Assert.True(reader.MetadataLoaded);
            Assert.NotNull(reader.Metadata);
        }

        [Fact]
        public void ApplyAudioMetadata_WithNullDurationAndBitRate_UsesFormatFallbacks()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            AudioMetadata metadata = new AudioMetadata
            {
                Format = new AudioFormat { Duration = "2.0" },
                Streams = new List<MediaStream>
                {
                    new MediaStream { CodecType = "audio", SampleRate = "1000", Duration = null, BitRate = null }
                }
            };

            reader.ApplyAudioMetadata(metadata, false);

            Assert.Equal(2.0, metadata.Duration);
            Assert.Equal(-1, metadata.BitRate);
            Assert.Equal(2000, metadata.PredictedSampleCount);
        }

        [Fact]
        public void ApplyAudioMetadata_WithMissingDurationAndFormat_UsesMinusOne()
        {
            using AudioReader reader = new AudioReader(_tempFile);
            AudioMetadata metadata = new AudioMetadata
            {
                Format = new AudioFormat(),
                Streams = new List<MediaStream> { new MediaStream { CodecType = "audio", SampleRate = "1" } }
            };

            reader.ApplyAudioMetadata(metadata, false);

            Assert.Equal(-1, metadata.Duration);
            Assert.Equal(-1, metadata.PredictedSampleCount);
        }

        [Fact]
        public void ApplyVideoMetadata_WithVideoStream_PopulatesDerivedFields()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            VideoMetadata metadata = new VideoMetadata(
                string.Empty,
                string.Empty,
                string.Empty,
                (0, 0),
                0,
                0,
                0,
                0,
                string.Empty,
                0,
                new[]
                {
                    new MediaStream
                    {
                        CodecType = "video",
                        Width = 64,
                        Height = 32,
                        PixFmt = "yuv420p",
                        CodecName = "h264",
                        CodecLongName = "H.264",
                        BitRate = "1000",
                        BitsPerRawSample = "8",
                        Duration = "10.5",
                        SampleAspectRatio = "1:1",
                        AvgFrameRateNumber = 30
                    }
                },
                new VideoFormat());

            reader.ApplyVideoMetadata(metadata, false);

            Assert.True(reader.LoadedMetadata);
            Assert.Same(metadata, reader.Metadata);
            Assert.Equal(64, metadata.Width);
            Assert.Equal(32, metadata.Height);
            Assert.Equal("h264", metadata.Codec);
            Assert.Equal(1000, metadata.BitRate);
            Assert.Equal(8, metadata.BitDepth);
            Assert.Equal(10.5, metadata.Duration);
            Assert.Equal(315, metadata.PredictedFrameCount);
        }

        [Fact]
        public void ApplyVideoMetadata_WithInvalidStream_ThrowsWhenErrorsAreNotIgnored()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            VideoMetadata metadata = new VideoMetadata(
                string.Empty, string.Empty, string.Empty, (0, 0), 0, 0, 0, 0, string.Empty, 0,
                new[] { new MediaStream { CodecType = "video", BitRate = "invalid" } },
                new VideoFormat());

            InvalidDataException exception = Assert.Throws<InvalidDataException>(() => reader.ApplyVideoMetadata(metadata, false));

            Assert.Contains("Failed to parse video stream data!", exception.Message);
        }

        [Fact]
        public void ApplyVideoMetadata_WithInvalidStream_IgnoresErrorWhenRequested()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            VideoMetadata metadata = new VideoMetadata(
                string.Empty, string.Empty, string.Empty, (0, 0), 0, 0, 0, 0, string.Empty, 0,
                new[] { new MediaStream { CodecType = "video", BitRate = "invalid" } },
                new VideoFormat());

            reader.ApplyVideoMetadata(metadata, true);

            Assert.True(reader.LoadedMetadata);
            Assert.Same(metadata, reader.Metadata);
        }

        [Fact]
        public void ApplyVideoMetadataJson_WithEmptyPayload_LeavesDefaults()
        {
            using VideoReader reader = new VideoReader(_tempFile);

            reader.ApplyVideoMetadataJson("{}", true);

            Assert.True(reader.LoadedMetadata);
            Assert.NotNull(reader.Metadata);
        }

        [Fact]
        public void ApplyVideoMetadata_WithNullOptionalFields_UsesFormatAndParserFallbacks()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            VideoMetadata metadata = new VideoMetadata(
                string.Empty, string.Empty, string.Empty, (0, 0), 0, 0, 0, 0, string.Empty, 0,
                new[]
                {
                    new MediaStream
                    {
                        CodecType = "video",
                        PixFmt = "yuv420p",
                        BitRate = null,
                        BitsPerRawSample = null,
                        Duration = null,
                        AvgFrameRateNumber = 10
                    }
                },
                new VideoFormat { Duration = "3.5" });

            reader.ApplyVideoMetadata(metadata, false);

            Assert.Equal(-1, metadata.BitRate);
            Assert.Equal(3.5, metadata.Duration);
            Assert.Equal(35, metadata.PredictedFrameCount);
        }

        [Fact]
        public void ApplyVideoMetadata_WithMissingDurationAndFormat_UsesZero()
        {
            using VideoReader reader = new VideoReader(_tempFile);
            VideoMetadata metadata = new VideoMetadata(
                string.Empty, string.Empty, string.Empty, (0, 0), 0, 0, 0, 0, string.Empty, 0,
                new[] { new MediaStream { CodecType = "video", PixFmt = "yuv420p", BitsPerRawSample = "8", Duration = null, AvgFrameRateNumber = 5 } },
                new VideoFormat { Duration = null });

            reader.ApplyVideoMetadata(metadata, false);

            Assert.Equal(0, metadata.Duration);
            Assert.Equal(0, metadata.PredictedFrameCount);
        }
    }
}
