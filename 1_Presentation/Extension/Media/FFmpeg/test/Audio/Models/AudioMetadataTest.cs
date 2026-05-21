

using System.Collections.Generic;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio.Models
{
    /// <summary>
    ///     The audio metadata test class
    /// </summary>
    /// <seealso cref="AudioMetadata" />
    public class AudioMetadataTest
    {
        /// <summary>
        ///     Tests that audio metadata constructor should create instance
        /// </summary>
        [Fact]
        public void AudioMetadata_Constructor_ShouldCreateInstance()
        {
            AudioMetadata metadata = new AudioMetadata();

            Assert.NotNull(metadata);
        }

        /// <summary>
        ///     Tests that audio metadata sample format property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_SampleFormatProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            string sampleFormat = "s16";

            metadata.SampleFormat = sampleFormat;

            Assert.Equal(sampleFormat, metadata.SampleFormat);
        }

        /// <summary>
        ///     Tests that audio metadata codec property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_CodecProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            string codec = "mp3";

            metadata.Codec = codec;

            Assert.Equal(codec, metadata.Codec);
        }

        /// <summary>
        ///     Tests that audio metadata codec long name property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_CodecLongNameProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            string codecLongName = "MP3 (MPEG audio layer 3)";

            metadata.CodecLongName = codecLongName;

            Assert.Equal(codecLongName, metadata.CodecLongName);
        }

        /// <summary>
        ///     Tests that audio metadata channels property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_ChannelsProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            int channels = 2;

            metadata.Channels = channels;

            Assert.Equal(channels, metadata.Channels);
        }

        /// <summary>
        ///     Tests that audio metadata sample rate property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_SampleRateProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            int sampleRate = 44100;

            metadata.SampleRate = sampleRate;

            Assert.Equal(sampleRate, metadata.SampleRate);
        }

        /// <summary>
        ///     Tests that audio metadata duration property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_DurationProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            double duration = 180.5;

            metadata.Duration = duration;

            Assert.Equal(duration, metadata.Duration);
        }

        /// <summary>
        ///     Tests that audio metadata bit rate property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_BitRateProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            int bitRate = 320000;

            metadata.BitRate = bitRate;

            Assert.Equal(bitRate, metadata.BitRate);
        }

        /// <summary>
        ///     Tests that audio metadata bit depth property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_BitDepthProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            int bitDepth = 16;

            metadata.BitDepth = bitDepth;

            Assert.Equal(bitDepth, metadata.BitDepth);
        }

        /// <summary>
        ///     Tests that audio metadata predicted sample count property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_PredictedSampleCountProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            long predictedSampleCount = 7056000;

            metadata.PredictedSampleCount = predictedSampleCount;

            Assert.Equal(predictedSampleCount, metadata.PredictedSampleCount);
        }

        /// <summary>
        ///     Tests that audio metadata streams property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_StreamsProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            List<MediaStream> streams = new List<MediaStream>();

            metadata.Streams = streams;

            Assert.Equal(streams, metadata.Streams);
        }

        /// <summary>
        ///     Tests that audio metadata format property should be settable
        /// </summary>
        [Fact]
        public void AudioMetadata_FormatProperty_ShouldBeSettable()
        {
            AudioMetadata metadata = new AudioMetadata();
            AudioFormat format = new AudioFormat();

            metadata.Format = format;

            Assert.Equal(format, metadata.Format);
        }

        /// <summary>
        ///     Tests that audio metadata get first audio stream should return audio stream
        /// </summary>
        [Fact]
        public void AudioMetadata_GetFirstAudioStream_ShouldReturnAudioStream()
        {
            AudioMetadata metadata = new AudioMetadata();
            MediaStream audioStream = new MediaStream {CodecType = "audio"};
            metadata.Streams = new List<MediaStream> {audioStream};

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.Equal(audioStream, result);
        }

        /// <summary>
        ///     Tests that audio metadata get first video stream should return video stream
        /// </summary>
        [Fact]
        public void AudioMetadata_GetFirstVideoStream_ShouldReturnVideoStream()
        {
            AudioMetadata metadata = new AudioMetadata();
            MediaStream videoStream = new MediaStream {CodecType = "video"};
            metadata.Streams = new List<MediaStream> {videoStream};

            MediaStream result = metadata.GetFirstVideoStream();

            Assert.Equal(videoStream, result);
        }

        /// <summary>
        ///     Tests that audio metadata get first audio stream should return null when no audio stream
        /// </summary>
        [Fact]
        public void AudioMetadata_GetFirstAudioStream_ShouldReturnNullWhenNoAudioStream()
        {
            AudioMetadata metadata = new AudioMetadata();
            MediaStream videoStream = new MediaStream {CodecType = "video"};
            metadata.Streams = new List<MediaStream> {videoStream};

            MediaStream result = metadata.GetFirstAudioStream();

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that audio metadata should support common sample rates
        /// </summary>
        [Fact]
        public void AudioMetadata_ShouldSupportCommonSampleRates()
        {
            AudioMetadata metadata22050 = new AudioMetadata {SampleRate = 22050};
            AudioMetadata metadata44100 = new AudioMetadata {SampleRate = 44100};
            AudioMetadata metadata48000 = new AudioMetadata {SampleRate = 48000};

            Assert.Equal(22050, metadata22050.SampleRate);
            Assert.Equal(44100, metadata44100.SampleRate);
            Assert.Equal(48000, metadata48000.SampleRate);
        }

        /// <summary>
        ///     Tests that audio metadata should support common bit rates
        /// </summary>
        [Fact]
        public void AudioMetadata_ShouldSupportCommonBitRates()
        {
            AudioMetadata metadata128k = new AudioMetadata {BitRate = 128000};
            AudioMetadata metadata192k = new AudioMetadata {BitRate = 192000};
            AudioMetadata metadata320k = new AudioMetadata {BitRate = 320000};

            Assert.Equal(128000, metadata128k.BitRate);
            Assert.Equal(192000, metadata192k.BitRate);
            Assert.Equal(320000, metadata320k.BitRate);
        }

        /// <summary>
        ///     Tests that audio metadata should support common channel configurations
        /// </summary>
        [Fact]
        public void AudioMetadata_ShouldSupportCommonChannelConfigurations()
        {
            AudioMetadata monoMetadata = new AudioMetadata {Channels = 1};
            AudioMetadata stereoMetadata = new AudioMetadata {Channels = 2};
            AudioMetadata surroundMetadata = new AudioMetadata {Channels = 6};

            Assert.Equal(1, monoMetadata.Channels);
            Assert.Equal(2, stereoMetadata.Channels);
            Assert.Equal(6, surroundMetadata.Channels);
        }
    }
}