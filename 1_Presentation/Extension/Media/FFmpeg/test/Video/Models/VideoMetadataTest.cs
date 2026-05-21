

using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video.Models
{
    /// <summary>
    ///     The video metadata test class
    /// </summary>
    /// <seealso cref="VideoMetadata" />
    public class VideoMetadataTest
    {
        /// <summary>
        ///     Tests that video metadata constructor should create instance
        /// </summary>
        [Fact]
        public void VideoMetadata_Constructor_ShouldCreateInstance()
        {
            VideoMetadata metadata = new VideoMetadata();

            Assert.NotNull(metadata);
        }

        /// <summary>
        ///     Tests that video metadata width property should be settable
        /// </summary>
        [Fact]
        public void VideoMetadata_WidthProperty_ShouldBeSettable()
        {
            VideoMetadata metadata = new VideoMetadata();
            int width = 1920;

            metadata.Width = width;

            Assert.Equal(width, metadata.Width);
        }

        /// <summary>
        ///     Tests that video metadata height property should be settable
        /// </summary>
        [Fact]
        public void VideoMetadata_HeightProperty_ShouldBeSettable()
        {
            VideoMetadata metadata = new VideoMetadata();
            int height = 1080;

            metadata.Height = height;

            Assert.Equal(height, metadata.Height);
        }


        /// <summary>
        ///     Tests that video metadata duration property should be settable
        /// </summary>
        [Fact]
        public void VideoMetadata_DurationProperty_ShouldBeSettable()
        {
            VideoMetadata metadata = new VideoMetadata();
            double duration = 120.5;

            metadata.Duration = duration;

            Assert.Equal(duration, metadata.Duration);
        }

        /// <summary>
        ///     Tests that video metadata bit rate property should be settable
        /// </summary>
        [Fact]
        public void VideoMetadata_BitRateProperty_ShouldBeSettable()
        {
            VideoMetadata metadata = new VideoMetadata();
            int bitRate = 5000000;

            metadata.BitRate = bitRate;

            Assert.Equal(bitRate, metadata.BitRate);
        }

        /// <summary>
        ///     Tests that video metadata codec property should be settable
        /// </summary>
        [Fact]
        public void VideoMetadata_CodecProperty_ShouldBeSettable()
        {
            VideoMetadata metadata = new VideoMetadata();
            string codec = "h264";

            metadata.Codec = codec;

            Assert.Equal(codec, metadata.Codec);
        }


        /// <summary>
        ///     Tests that video metadata format property should be settable
        /// </summary>
        [Fact]
        public void VideoMetadata_FormatProperty_ShouldBeSettable()
        {
            VideoMetadata metadata = new VideoMetadata();
            VideoFormat format = new VideoFormat();

            metadata.Format = format;

            Assert.Equal(format, metadata.Format);
        }

        /// <summary>
        ///     Tests that video metadata should support common resolutions
        /// </summary>
        [Fact]
        public void VideoMetadata_ShouldSupportCommonResolutions()
        {
            VideoMetadata hd720 = new VideoMetadata {Width = 1280, Height = 720};
            VideoMetadata hd1080 = new VideoMetadata {Width = 1920, Height = 1080};
            VideoMetadata uhd4k = new VideoMetadata {Width = 3840, Height = 2160};

            Assert.Equal(1280, hd720.Width);
            Assert.Equal(720, hd720.Height);
            Assert.Equal(1920, hd1080.Width);
            Assert.Equal(1080, hd1080.Height);
            Assert.Equal(3840, uhd4k.Width);
            Assert.Equal(2160, uhd4k.Height);
        }

        /// <summary>
        ///     Tests that video metadata should support common codecs
        /// </summary>
        [Fact]
        public void VideoMetadata_ShouldSupportCommonCodecs()
        {
            VideoMetadata h264 = new VideoMetadata {Codec = "h264"};
            VideoMetadata h265 = new VideoMetadata {Codec = "hevc"};
            VideoMetadata vp9 = new VideoMetadata {Codec = "vp9"};

            Assert.Equal("h264", h264.Codec);
            Assert.Equal("hevc", h265.Codec);
            Assert.Equal("vp9", vp9.Codec);
        }
    }
}