using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Test.Attributes;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    /// The media stream tests class
    /// </summary>
    public class MediaStreamTests
    {
        /// <summary>
        /// Ises the audio codec type null throws null reference exception
        /// </summary>
        [RequireFfmpegFact]
        public void IsAudio_CodecTypeNull_ThrowsNullReferenceException()
        {
            MediaStream stream = new MediaStream { CodecType = null };
            Assert.Throws<NullReferenceException>(() => stream.IsAudio);
        }

        /// <summary>
        /// Ises the video codec type null throws null reference exception
        /// </summary>
        [RequireFfmpegFact]
        public void IsVideo_CodecTypeNull_ThrowsNullReferenceException()
        {
            MediaStream stream = new MediaStream { CodecType = null };
            Assert.Throws<NullReferenceException>(() => stream.IsVideo);
        }

        /// <summary>
        /// Ises the audio codec type empty returns false
        /// </summary>
        [RequireFfmpegFact]
        public void IsAudio_CodecTypeEmpty_ReturnsFalse()
        {
            MediaStream stream = new MediaStream { CodecType = string.Empty };
            Assert.False(stream.IsAudio);
        }

        /// <summary>
        /// Ises the video codec type empty returns false
        /// </summary>
        [RequireFfmpegFact]
        public void IsVideo_CodecTypeEmpty_ReturnsFalse()
        {
            MediaStream stream = new MediaStream { CodecType = string.Empty };
            Assert.False(stream.IsVideo);
        }

        /// <summary>
        /// Ises the audio codec type upper case returns true
        /// </summary>
        [RequireFfmpegFact]
        public void IsAudio_CodecTypeUpperCase_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "AUDIO" };
            Assert.True(stream.IsAudio);
        }

        /// <summary>
        /// Ises the video codec type upper case returns true
        /// </summary>
        [RequireFfmpegFact]
        public void IsVideo_CodecTypeUpperCase_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "VIDEO" };
            Assert.True(stream.IsVideo);
        }

        /// <summary>
        /// Ises the audio codec type mixed case returns true
        /// </summary>
        [RequireFfmpegFact]
        public void IsAudio_CodecTypeMixedCase_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "AuDiO" };
            Assert.True(stream.IsAudio);
        }

        /// <summary>
        /// Ises the video codec type mixed case returns true
        /// </summary>
        [RequireFfmpegFact]
        public void IsVideo_CodecTypeMixedCase_ReturnsTrue()
        {
            MediaStream stream = new MediaStream { CodecType = "ViDeO" };
            Assert.True(stream.IsVideo);
        }

        /// <summary>
        /// Ises the audio subtitle codec returns false
        /// </summary>
        [RequireFfmpegFact]
        public void IsAudio_SubtitleCodec_ReturnsFalse()
        {
            MediaStream stream = new MediaStream { CodecType = "subtitle" };
            Assert.False(stream.IsAudio);
        }

        /// <summary>
        /// Ises the video subtitle codec returns false
        /// </summary>
        [RequireFfmpegFact]
        public void IsVideo_SubtitleCodec_ReturnsFalse()
        {
            MediaStream stream = new MediaStream { CodecType = "subtitle" };
            Assert.False(stream.IsVideo);
        }

        /// <summary>
        /// Samples the rate number valid value returns parsed int
        /// </summary>
        [RequireFfmpegFact]
        public void SampleRateNumber_ValidValue_ReturnsParsedInt()
        {
            MediaStream stream = new MediaStream { SampleRate = "48000" };
            Assert.Equal(48000, stream.SampleRateNumber);
        }

        /// <summary>
        /// Samples the rate number empty string returns negative one
        /// </summary>
        [RequireFfmpegFact]
        public void SampleRateNumber_EmptyString_ReturnsNegativeOne()
        {
            MediaStream stream = new MediaStream { SampleRate = "" };
            Assert.Equal(-1, stream.SampleRateNumber);
        }

        /// <summary>
        /// Samples the rate number null string returns negative one
        /// </summary>
        [RequireFfmpegFact]
        public void SampleRateNumber_NullString_ReturnsNegativeOne()
        {
            MediaStream stream = new MediaStream { SampleRate = null };
            Assert.Equal(-1, stream.SampleRateNumber);
        }

        /// <summary>
        /// Samples the rate number whitespace string throws format exception
        /// </summary>
        [RequireFfmpegFact]
        public void SampleRateNumber_WhitespaceString_ThrowsFormatException()
        {
            MediaStream stream = new MediaStream { SampleRate = "   " };
            Assert.Throws<FormatException>(() => stream.SampleRateNumber);
        }

        /// <summary>
        /// Avgs the frame rate number default returns zero
        /// </summary>
        [RequireFfmpegFact]
        public void AvgFrameRateNumber_Default_ReturnsZero()
        {
            MediaStream stream = new MediaStream();
            Assert.Equal(0.0, stream.AvgFrameRateNumber);
        }

        /// <summary>
        /// Avgs the frame rate number set value returns value
        /// </summary>
        [RequireFfmpegFact]
        public void AvgFrameRateNumber_SetValue_ReturnsValue()
        {
            MediaStream stream = new MediaStream { AvgFrameRateNumber = 29.97 };
            Assert.Equal(29.97, stream.AvgFrameRateNumber);
        }

        /// <summary>
        /// Dispositions the set dictionary returns same
        /// </summary>
        [RequireFfmpegFact]
        public void Disposition_SetDictionary_ReturnsSame()
        {
            Dictionary<string, int> disposition = new Dictionary<string, int>
            {
                { "default", 1 },
                { "dub", 0 },
                { "original", 1 }
            };
            MediaStream stream = new MediaStream { Disposition = disposition };
            Assert.Equal(disposition, stream.Disposition);
        }

        /// <summary>
        /// Dispositions the default returns null
        /// </summary>
        [RequireFfmpegFact]
        public void Disposition_Default_ReturnsNull()
        {
            MediaStream stream = new MediaStream();
            Assert.Null(stream.Disposition);
        }

        /// <summary>
        /// Tagses the set and get returns same
        /// </summary>
        [RequireFfmpegFact]
        public void Tags_SetAndGet_ReturnsSame()
        {
            StreamTags tags = new StreamTags { Language = "eng", CreationTime = "2024-01-01" };
            MediaStream stream = new MediaStream { Tags = tags };
            Assert.Equal(tags, stream.Tags);
        }

        /// <summary>
        /// Tagses the default returns null
        /// </summary>
        [RequireFfmpegFact]
        public void Tags_Default_ReturnsNull()
        {
            MediaStream stream = new MediaStream();
            Assert.Null(stream.Tags);
        }

        /// <summary>
        /// Serializes the default stream produces json
        /// </summary>
        [RequireFfmpegFact]
        public void Serialize_DefaultStream_ProducesJson()
        {
            MediaStream stream = new MediaStream();
            string json = JsonNativeAot.Serialize(stream);
            Assert.NotNull(json);
            Assert.Contains("\"index\"", json);
        }

        /// <summary>
        /// Serializes the and deserialize round trip produces equal instance
        /// </summary>
        [RequireFfmpegFact]
        public void SerializeAndDeserialize_RoundTrip_ProducesEqualInstance()
        {
            MediaStream original = new MediaStream
            {
                Index = 1,
                CodecName = "h264",
                CodecType = "video",
                Width = 1920,
                Height = 1080,
                BitRate = "8000000",
                SampleRate = "44100",
                Channels = 2
            };
            string json = JsonNativeAot.Serialize(original);
            MediaStream restored = JsonNativeAot.Deserialize<MediaStream>(json);
            Assert.NotNull(restored);
            Assert.Equal(original.Index, restored.Index);
            Assert.Equal(original.CodecName, restored.CodecName);
            Assert.Equal(original.CodecType, restored.CodecType);
            Assert.Equal(original.Width, restored.Width);
            Assert.Equal(original.Height, restored.Height);
        }

        /// <summary>
        /// Serializes the with tags produces json
        /// </summary>
        [RequireFfmpegFact]
        public void Serialize_WithTags_ProducesJson()
        {
            MediaStream stream = new MediaStream
            {
                Tags = new StreamTags { Language = "eng", HandlerName = "StreamHandler" }
            };
            string json = JsonNativeAot.Serialize(stream);
            Assert.NotNull(json);
            Assert.Contains("language", json);
        }

        /// <summary>
        /// Serializes the all properties set produces complete json
        /// </summary>
        [RequireFfmpegFact]
        public void Serialize_AllPropertiesSet_ProducesCompleteJson()
        {
            MediaStream stream = new MediaStream
            {
                Index = 1,
                CodecName = "aac",
                CodecLongName = "AAC (Advanced Audio Coding)",
                Profile = "LC",
                CodecType = "audio",
                CodecTimeBase = "1/44100",
                CodecTagString = "mp4a",
                CodecTag = "0x6134706d",
                Width = 0,
                Height = 0,
                CodedWidth = 0,
                CodedHeight = 0,
                HasBFrames = 0,
                SampleAspectRatio = "N/A",
                DisplayAspectRatio = "N/A",
                PixFmt = "fltp",
                Level = 0,
                ColorRange = "N/A",
                ColorSpace = "N/A",
                ColorTransfer = "N/A",
                ColorPrimaries = "N/A",
                ChromaLocation = "N/A",
                Refs = 0,
                IsAvc = "false",
                NalLengthSize = "0",
                RFrameRate = "0/0",
                AvgFrameRate = "0/0",
                AvgFrameRateNumber = 0.0,
                TimeBase = "1/44100",
                StartPts = 0,
                StartTime = "0.000000",
                DurationTs = 0,
                Duration = "0.000000",
                BitRate = "128000",
                BitsPerRawSample = "32",
                NbFrames = "0",
                SampleFmt = "fltp",
                SampleRate = "44100",
                Channels = 2,
                ChannelLayout = "stereo",
                BitsPerSample = 16,
                MaxBitRate = "256000"
            };
            string json = JsonNativeAot.Serialize(stream);
            Assert.Contains("\"codec_name\":\"aac\"", json);
            Assert.Contains("\"sample_rate\":\"44100\"", json);
        }
    }
}
