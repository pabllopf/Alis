

using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The vorbis encoder test class
    /// </summary>
    /// <seealso cref="VorbisEncoder" />
    public class VorbisEncoderTest
    {
        /// <summary>
        ///     Tests that vorbis encoder constructor should create instance with default cqp
        /// </summary>
        [Fact]
        public void VorbisEncoder_Constructor_ShouldCreateInstanceWithDefaultCqp()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.NotNull(encoder);
            Assert.Contains("-q:a", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder name property should return libvorbis
        /// </summary>
        [Fact]
        public void VorbisEncoder_NameProperty_ShouldReturnLibvorbis()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            string name = encoder.Name;

            Assert.Equal("libvorbis", name);
        }

        /// <summary>
        ///     Tests that vorbis encoder default format should be ogg
        /// </summary>
        [Fact]
        public void VorbisEncoder_DefaultFormat_ShouldBeOgg()
        {
            VorbisEncoder encoder = new VorbisEncoder();

            Assert.Equal("ogg", encoder.Format);
        }

        /// <summary>
        ///     Tests that vorbis encoder channel count property should be settable
        /// </summary>
        [Fact]
        public void VorbisEncoder_ChannelCountProperty_ShouldBeSettable()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            int channelCount = 2;

            encoder.ChannelCount = channelCount;

            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that vorbis encoder sample rate property should be settable
        /// </summary>
        [Fact]
        public void VorbisEncoder_SampleRateProperty_ShouldBeSettable()
        {
            VorbisEncoder encoder = new VorbisEncoder();
            int sampleRate = 48000;

            encoder.SampleRate = sampleRate;

            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that vorbis encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void VorbisEncoder_SetCbr_ShouldSetQualitySettings()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            string bitrate = "192k";

            // Act
            encoder.SetCbr(bitrate);

            // Assert
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("192k", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder set cqp with custom quality should work
        /// </summary>
        [Fact]
        public void VorbisEncoder_SetCqpWithCustomQuality_ShouldWork()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            float q = 5.5f;

            // Act
            encoder.SetCqp(q);

            // Assert
            Assert.Contains("-q:a", encoder.CurrentQualitySettings);
            Assert.Contains("5.50", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder create should return encoder options
        /// </summary>
        [Fact]
        public void VorbisEncoder_Create_ShouldReturnEncoderOptions()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.NotNull(options);
            Assert.Equal("ogg", options.Format);
            Assert.Equal("libvorbis", options.EncoderName);
        }

        /// <summary>
        ///     Tests that vorbis encoder create should include channel count when set
        /// </summary>
        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.ChannelCount = 2;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that vorbis encoder create should include sample rate when set
        /// </summary>
        [Fact]
        public void VorbisEncoder_Create_ShouldIncludeSampleRateWhenSet()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();
            encoder.SampleRate = 48000;

            // Act
            EncoderOptions options = encoder.Create();

            // Assert
            Assert.Contains("-ar", options.EncoderArguments);
            Assert.Contains("48000", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that vorbis encoder set cqp with boundary values should work
        /// </summary>
        [Fact]
        public void VorbisEncoder_SetCqpWithBoundaryValues_ShouldWork()
        {
            // Arrange
            VorbisEncoder encoder = new VorbisEncoder();

            // Act & Assert
            encoder.SetCqp(-1);
            Assert.Contains("-1.00", encoder.CurrentQualitySettings);

            encoder.SetCqp(10);
            Assert.Contains("10.00", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that vorbis encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void VorbisEncoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            // Arrange & Act
            VorbisEncoder encoder = new VorbisEncoder();

            // Assert
            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }
    }
}