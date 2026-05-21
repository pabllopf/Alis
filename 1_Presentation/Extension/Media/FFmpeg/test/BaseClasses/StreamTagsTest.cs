

using Alis.Extension.Media.FFmpeg.BaseClasses;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.BaseClasses
{
    /// <summary>
    ///     The stream tags test class
    /// </summary>
    /// <seealso cref="StreamTags" />
    public class StreamTagsTest
    {
        /// <summary>
        ///     Tests that stream tags default constructor should create instance with empty strings
        /// </summary>
        [Fact]
        public void StreamTags_DefaultConstructor_ShouldCreateInstanceWithEmptyStrings()
        {
            StreamTags tags = new StreamTags();

            Assert.NotNull(tags);
            Assert.Equal(string.Empty, tags.CreationTime);
            Assert.Equal(string.Empty, tags.Language);
            Assert.Equal(string.Empty, tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags parameterized constructor should create instance with values
        /// </summary>
        [Fact]
        public void StreamTags_ParameterizedConstructor_ShouldCreateInstanceWithValues()
        {
            string creationTime = "2021-01-01T00:00:00.000000Z";
            string language = "eng";
            string handlerName = "VideoHandler";

            StreamTags tags = new StreamTags(creationTime, language, handlerName);

            Assert.Equal(creationTime, tags.CreationTime);
            Assert.Equal(language, tags.Language);
            Assert.Equal(handlerName, tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags creation time property should be settable
        /// </summary>
        [Fact]
        public void StreamTags_CreationTimeProperty_ShouldBeSettable()
        {
            StreamTags tags = new StreamTags();
            string creationTime = "2021-01-01T00:00:00.000000Z";

            tags.CreationTime = creationTime;

            Assert.Equal(creationTime, tags.CreationTime);
        }

        /// <summary>
        ///     Tests that stream tags language property should be settable
        /// </summary>
        [Fact]
        public void StreamTags_LanguageProperty_ShouldBeSettable()
        {
            StreamTags tags = new StreamTags();
            string language = "eng";

            tags.Language = language;

            Assert.Equal(language, tags.Language);
        }

        /// <summary>
        ///     Tests that stream tags handler name property should be settable
        /// </summary>
        [Fact]
        public void StreamTags_HandlerNameProperty_ShouldBeSettable()
        {
            StreamTags tags = new StreamTags();
            string handlerName = "AudioHandler";

            tags.HandlerName = handlerName;

            Assert.Equal(handlerName, tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags should allow null values
        /// </summary>
        [Fact]
        public void StreamTags_ShouldAllowNullValues()
        {
            StreamTags tags = new StreamTags();

            tags.CreationTime = null;
            tags.Language = null;
            tags.HandlerName = null;

            Assert.Null(tags.CreationTime);
            Assert.Null(tags.Language);
            Assert.Null(tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags should support common language codes
        /// </summary>
        [Fact]
        public void StreamTags_ShouldSupportCommonLanguageCodes()
        {
            StreamTags engTags = new StreamTags {Language = "eng"};
            StreamTags espTags = new StreamTags {Language = "spa"};
            StreamTags freTags = new StreamTags {Language = "fre"};

            Assert.Equal("eng", engTags.Language);
            Assert.Equal("spa", espTags.Language);
            Assert.Equal("fre", freTags.Language);
        }

        /// <summary>
        ///     Tests that stream tags properties should be independent
        /// </summary>
        [Fact]
        public void StreamTags_Properties_ShouldBeIndependent()
        {
            StreamTags tags = new StreamTags();

            tags.CreationTime = "2021-01-01T00:00:00.000000Z";
            tags.Language = "eng";
            tags.HandlerName = "VideoHandler";

            Assert.Equal("2021-01-01T00:00:00.000000Z", tags.CreationTime);
            Assert.Equal("eng", tags.Language);
            Assert.Equal("VideoHandler", tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags should support initializer syntax
        /// </summary>
        [Fact]
        public void StreamTags_ShouldSupportInitializerSyntax()
        {
            StreamTags tags = new StreamTags
            {
                CreationTime = "2021-01-01T00:00:00.000000Z",
                Language = "eng",
                HandlerName = "AudioHandler"
            };

            Assert.Equal("2021-01-01T00:00:00.000000Z", tags.CreationTime);
            Assert.Equal("eng", tags.Language);
            Assert.Equal("AudioHandler", tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags properties should be mutable
        /// </summary>
        [Fact]
        public void StreamTags_Properties_ShouldBeMutable()
        {
            StreamTags tags = new StreamTags("2021-01-01", "eng", "VideoHandler");

            tags.CreationTime = "2022-01-01";
            tags.Language = "spa";
            tags.HandlerName = "AudioHandler";

            Assert.Equal("2022-01-01", tags.CreationTime);
            Assert.Equal("spa", tags.Language);
            Assert.Equal("AudioHandler", tags.HandlerName);
        }

        /// <summary>
        ///     Tests that stream tags constructor with null parameters should work
        /// </summary>
        [Fact]
        public void StreamTags_ConstructorWithNullParameters_ShouldWork()
        {
            StreamTags tags = new StreamTags(null, null, null);

            Assert.Null(tags.CreationTime);
            Assert.Null(tags.Language);
            Assert.Null(tags.HandlerName);
        }
    }
}