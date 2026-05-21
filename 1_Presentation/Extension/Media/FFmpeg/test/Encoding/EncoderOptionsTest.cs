

using Alis.Extension.Media.FFmpeg.Encoding;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding
{
    /// <summary>
    ///     The encoder options test class
    /// </summary>
    /// <seealso cref="EncoderOptions" />
    public class EncoderOptionsTest
    {
        /// <summary>
        ///     Tests that encoder options constructor should create instance
        /// </summary>
        [Fact]
        public void EncoderOptions_Constructor_ShouldCreateInstance()
        {
            EncoderOptions options = new EncoderOptions();

            Assert.NotNull(options);
        }

        /// <summary>
        ///     Tests that encoder options format property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptions_FormatProperty_ShouldBeSettable()
        {
            EncoderOptions options = new EncoderOptions();
            string format = "mp4";

            options.Format = format;

            Assert.Equal(format, options.Format);
        }

        /// <summary>
        ///     Tests that encoder options encoder name property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptions_EncoderNameProperty_ShouldBeSettable()
        {
            EncoderOptions options = new EncoderOptions();
            string encoderName = "libx264";

            options.EncoderName = encoderName;

            Assert.Equal(encoderName, options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options encoder arguments property should be settable
        /// </summary>
        [Fact]
        public void EncoderOptions_EncoderArgumentsProperty_ShouldBeSettable()
        {
            EncoderOptions options = new EncoderOptions();
            string arguments = "-crf 22 -preset medium";

            options.EncoderArguments = arguments;

            Assert.Equal(arguments, options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should allow null format
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowNullFormat()
        {
            EncoderOptions options = new EncoderOptions();

            options.Format = null;

            Assert.Null(options.Format);
        }

        /// <summary>
        ///     Tests that encoder options should allow null encoder name
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowNullEncoderName()
        {
            EncoderOptions options = new EncoderOptions();

            options.EncoderName = null;

            Assert.Null(options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options should allow null encoder arguments
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowNullEncoderArguments()
        {
            EncoderOptions options = new EncoderOptions();

            options.EncoderArguments = null;

            Assert.Null(options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should allow empty strings
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowEmptyStrings()
        {
            EncoderOptions options = new EncoderOptions();

            options.Format = string.Empty;
            options.EncoderName = string.Empty;
            options.EncoderArguments = string.Empty;

            Assert.Equal(string.Empty, options.Format);
            Assert.Equal(string.Empty, options.EncoderName);
            Assert.Equal(string.Empty, options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options all properties should be independent
        /// </summary>
        [Fact]
        public void EncoderOptions_AllProperties_ShouldBeIndependent()
        {
            EncoderOptions options = new EncoderOptions();

            options.Format = "mp4";
            options.EncoderName = "libx264";
            options.EncoderArguments = "-crf 22";

            Assert.Equal("mp4", options.Format);
            Assert.Equal("libx264", options.EncoderName);
            Assert.Equal("-crf 22", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should support common video formats
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonVideoFormats()
        {
            EncoderOptions mp4Options = new EncoderOptions {Format = "mp4"};
            EncoderOptions webmOptions = new EncoderOptions {Format = "webm"};
            EncoderOptions mkvOptions = new EncoderOptions {Format = "mkv"};

            Assert.Equal("mp4", mp4Options.Format);
            Assert.Equal("webm", webmOptions.Format);
            Assert.Equal("mkv", mkvOptions.Format);
        }

        /// <summary>
        ///     Tests that encoder options should support common audio formats
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonAudioFormats()
        {
            EncoderOptions mp3Options = new EncoderOptions {Format = "mp3"};
            EncoderOptions oggOptions = new EncoderOptions {Format = "ogg"};
            EncoderOptions m4aOptions = new EncoderOptions {Format = "m4a"};

            Assert.Equal("mp3", mp3Options.Format);
            Assert.Equal("ogg", oggOptions.Format);
            Assert.Equal("m4a", m4aOptions.Format);
        }

        /// <summary>
        ///     Tests that encoder options should support common video encoders
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonVideoEncoders()
        {
            EncoderOptions h264Options = new EncoderOptions {EncoderName = "libx264"};
            EncoderOptions h265Options = new EncoderOptions {EncoderName = "libx265"};
            EncoderOptions vp9Options = new EncoderOptions {EncoderName = "libvpx-vp9"};

            Assert.Equal("libx264", h264Options.EncoderName);
            Assert.Equal("libx265", h265Options.EncoderName);
            Assert.Equal("libvpx-vp9", vp9Options.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options should support common audio encoders
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportCommonAudioEncoders()
        {
            EncoderOptions mp3Options = new EncoderOptions {EncoderName = "libmp3lame"};
            EncoderOptions aacOptions = new EncoderOptions {EncoderName = "aac"};
            EncoderOptions vorbisOptions = new EncoderOptions {EncoderName = "libvorbis"};

            Assert.Equal("libmp3lame", mp3Options.EncoderName);
            Assert.Equal("aac", aacOptions.EncoderName);
            Assert.Equal("libvorbis", vorbisOptions.EncoderName);
        }

        /// <summary>
        ///     Tests that encoder options should allow complex encoder arguments
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldAllowComplexEncoderArguments()
        {
            EncoderOptions options = new EncoderOptions();
            string complexArgs = "-crf 22 -preset medium -tune film -profile:v high";

            options.EncoderArguments = complexArgs;

            Assert.Equal(complexArgs, options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options properties should be mutable
        /// </summary>
        [Fact]
        public void EncoderOptions_Properties_ShouldBeMutable()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 22"
            };

            options.Format = "webm";
            options.EncoderName = "libvpx-vp9";
            options.EncoderArguments = "-crf 31";

            Assert.Equal("webm", options.Format);
            Assert.Equal("libvpx-vp9", options.EncoderName);
            Assert.Equal("-crf 31", options.EncoderArguments);
        }

        /// <summary>
        ///     Tests that encoder options should support initializer syntax
        /// </summary>
        [Fact]
        public void EncoderOptions_ShouldSupportInitializerSyntax()
        {
            EncoderOptions options = new EncoderOptions
            {
                Format = "mp4",
                EncoderName = "libx264",
                EncoderArguments = "-crf 22 -preset medium"
            };

            Assert.Equal("mp4", options.Format);
            Assert.Equal("libx264", options.EncoderName);
            Assert.Equal("-crf 22 -preset medium", options.EncoderArguments);
        }
    }
}