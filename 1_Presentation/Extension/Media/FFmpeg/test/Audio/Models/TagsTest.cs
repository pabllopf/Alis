

using Alis.Extension.Media.FFmpeg.Audio.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Audio.Models
{
    /// <summary>
    ///     The tags test class
    /// </summary>
    /// <seealso cref="Tags" />
    public class TagsTest
    {
        /// <summary>
        ///     Tests that tags constructor should create instance
        /// </summary>
        [Fact]
        public void Tags_Constructor_ShouldCreateInstance()
        {
            Tags tags = new Tags();

            Assert.NotNull(tags);
        }

        /// <summary>
        ///     Tests that tags encoder property should be settable
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldBeSettable()
        {
            Tags tags = new Tags();
            string encoder = "Lavf58.29.100";

            tags.Encoder = encoder;

            Assert.Equal(encoder, tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags encoder property should accept null
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldAcceptNull()
        {
            Tags tags = new Tags();

            tags.Encoder = null;

            Assert.Null(tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags encoder property should accept empty string
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldAcceptEmptyString()
        {
            Tags tags = new Tags();

            tags.Encoder = string.Empty;

            Assert.Equal(string.Empty, tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags should support initializer syntax
        /// </summary>
        [Fact]
        public void Tags_ShouldSupportInitializerSyntax()
        {
            Tags tags = new Tags
            {
                Encoder = "Lavf58.29.100"
            };

            Assert.Equal("Lavf58.29.100", tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags encoder property should be mutable
        /// </summary>
        [Fact]
        public void Tags_EncoderProperty_ShouldBeMutable()
        {
            Tags tags = new Tags {Encoder = "Lavf58.29.100"};

            tags.Encoder = "Lavf59.27.100";

            Assert.Equal("Lavf59.27.100", tags.Encoder);
        }

        /// <summary>
        ///     Tests that tags should support common encoder strings
        /// </summary>
        [Fact]
        public void Tags_ShouldSupportCommonEncoderStrings()
        {
            Tags lavfTags = new Tags {Encoder = "Lavf58.29.100"};
            Tags ffmpegTags = new Tags {Encoder = "FFmpeg"};
            Tags customTags = new Tags {Encoder = "Custom Encoder 1.0"};

            Assert.Equal("Lavf58.29.100", lavfTags.Encoder);
            Assert.Equal("FFmpeg", ffmpegTags.Encoder);
            Assert.Equal("Custom Encoder 1.0", customTags.Encoder);
        }
    }
}