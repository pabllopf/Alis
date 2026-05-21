

using System;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The opus encoder test class
    /// </summary>
    /// <seealso cref="OpusEncoder" />
    public class OpusEncoderTest
    {
        /// <summary>
        ///     Tests that opus encoder constructor should create instance with default vbr
        /// </summary>
        [Fact]
        public void OpusEncoder_Constructor_ShouldCreateInstanceWithDefaultVbr()
        {
            OpusEncoder encoder = new OpusEncoder();

            Assert.NotNull(encoder);
            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr on", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder name property should return libopus
        /// </summary>
        [Fact]
        public void OpusEncoder_NameProperty_ShouldReturnLibopus()
        {
            OpusEncoder encoder = new OpusEncoder();

            string name = encoder.Name;

            Assert.Equal("libopus", name);
        }

        /// <summary>
        ///     Tests that opus encoder default format should be ogg
        /// </summary>
        [Fact]
        public void OpusEncoder_DefaultFormat_ShouldBeOgg()
        {
            OpusEncoder encoder = new OpusEncoder();

            Assert.Equal("ogg", encoder.Format);
        }

        /// <summary>
        ///     Tests that opus encoder channel count property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_ChannelCountProperty_ShouldBeSettable()
        {
            OpusEncoder encoder = new OpusEncoder();
            int channelCount = 2;

            encoder.ChannelCount = channelCount;

            Assert.Equal(channelCount, encoder.ChannelCount);
        }

        /// <summary>
        ///     Tests that opus encoder sample rate property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_SampleRateProperty_ShouldBeSettable()
        {
            OpusEncoder encoder = new OpusEncoder();
            int sampleRate = 48000;

            encoder.SampleRate = sampleRate;

            Assert.Equal(sampleRate, encoder.SampleRate);
        }

        /// <summary>
        ///     Tests that opus encoder codec application property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_CodecApplicationProperty_ShouldBeSettable()
        {
            OpusEncoder encoder = new OpusEncoder();
            OpusEncoder.Application application = OpusEncoder.Application.VoIp;

            encoder.CodecApplication = application;

            Assert.Equal(application, encoder.CodecApplication);
        }

        /// <summary>
        ///     Tests that opus encoder default application should be audio
        /// </summary>
        [Fact]
        public void OpusEncoder_DefaultApplication_ShouldBeAudio()
        {
            OpusEncoder encoder = new OpusEncoder();

            Assert.Equal(OpusEncoder.Application.Audio, encoder.CodecApplication);
        }

        /// <summary>
        ///     Tests that opus encoder compression level property should be settable
        /// </summary>
        [Fact]
        public void OpusEncoder_CompressionLevelProperty_ShouldBeSettable()
        {
            OpusEncoder encoder = new OpusEncoder();
            int compressionLevel = 5;

            encoder.CompressionLevel = compressionLevel;

            Assert.Equal(compressionLevel, encoder.CompressionLevel);
        }

        /// <summary>
        ///     Tests that opus encoder default compression level should be 10
        /// </summary>
        [Fact]
        public void OpusEncoder_DefaultCompressionLevel_ShouldBe10()
        {
            OpusEncoder encoder = new OpusEncoder();

            Assert.Equal(10, encoder.CompressionLevel);
        }

        /// <summary>
        ///     Tests that opus encoder set cbr should set quality settings
        /// </summary>
        [Fact]
        public void OpusEncoder_SetCbr_ShouldSetQualitySettings()
        {
            OpusEncoder encoder = new OpusEncoder();
            string bitrate = "128k";

            encoder.SetCbr(bitrate);

            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("128k", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr off", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder set vbr should set quality settings
        /// </summary>
        [Fact]
        public void OpusEncoder_SetVbr_ShouldSetQualitySettings()
        {
            OpusEncoder encoder = new OpusEncoder();
            string bitrate = "96k";

            encoder.SetVbr(bitrate);

            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("96k", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr on", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder set cvbr should set quality settings
        /// </summary>
        [Fact]
        public void OpusEncoder_SetCvbr_ShouldSetQualitySettings()
        {
            OpusEncoder encoder = new OpusEncoder();
            string bitrate = "128k";

            encoder.SetCvbr(bitrate);

            Assert.Contains("-b:a", encoder.CurrentQualitySettings);
            Assert.Contains("128k", encoder.CurrentQualitySettings);
            Assert.Contains("-vbr constrained", encoder.CurrentQualitySettings);
        }

        /// <summary>
        ///     Tests that opus encoder create should return encoder options
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldReturnEncoderOptions()
        {
            OpusEncoder encoder = new OpusEncoder();

            EncoderOptions options = encoder.Create();

            Assert.NotNull(options);
            Assert.Equal("ogg", options.Format);
            Assert.Equal("libopus", options.EncoderName);
        }

        /// <summary>
        ///     Tests that opus encoder create should include application in arguments
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldIncludeApplicationInArguments()
        {
            OpusEncoder encoder = new OpusEncoder();
            encoder.CodecApplication = OpusEncoder.Application.VoIp;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-application", options.EncoderArguments);
            Assert.Contains("voip", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that opus encoder create should include compression level in arguments
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldIncludeCompressionLevelInArguments()
        {
            OpusEncoder encoder = new OpusEncoder();
            encoder.CompressionLevel = 8;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-compression_level", options.EncoderArguments);
            Assert.Contains("8", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that opus encoder create should include channel count when set
        /// </summary>
        [Fact]
        public void OpusEncoder_Create_ShouldIncludeChannelCountWhenSet()
        {
            OpusEncoder encoder = new OpusEncoder();
            encoder.ChannelCount = 2;

            EncoderOptions options = encoder.Create();

            Assert.Contains("-ac", options.EncoderArguments);
            Assert.Contains("2", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that opus encoder application enum should have three values
        /// </summary>
        [Fact]
        public void OpusEncoder_ApplicationEnum_ShouldHaveThreeValues()
        {
            OpusEncoder.Application[] values = (OpusEncoder.Application[]) Enum.GetValues(typeof(OpusEncoder.Application));

            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that opus encoder should inherit from encoder options builder
        /// </summary>
        [Fact]
        public void OpusEncoder_ShouldInheritFromEncoderOptionsBuilder()
        {
            OpusEncoder encoder = new OpusEncoder();

            Assert.IsAssignableFrom<EncoderOptionsBuilder>(encoder);
        }

        /// <summary>
        ///     Tests that opus encoder compression level should support valid range
        /// </summary>
        [Fact]
        public void OpusEncoder_CompressionLevel_ShouldSupportValidRange()
        {
            OpusEncoder encoder = new OpusEncoder();

            encoder.CompressionLevel = 0;
            Assert.Equal(0, encoder.CompressionLevel);

            encoder.CompressionLevel = 10;
            Assert.Equal(10, encoder.CompressionLevel);
        }
    }
}