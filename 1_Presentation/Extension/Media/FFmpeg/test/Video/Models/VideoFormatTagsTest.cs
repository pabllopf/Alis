

using Alis.Extension.Media.FFmpeg.Video.Models;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Video.Models
{
    /// <summary>
    ///     The video format tags test class
    /// </summary>
    /// <seealso cref="VideoFormatTags" />
    public class VideoFormatTagsTest
    {
        /// <summary>
        ///     Tests that video format tags constructor should create instance
        /// </summary>
        [Fact]
        public void VideoFormatTags_Constructor_ShouldCreateInstance()
        {
            VideoFormatTags tags = new VideoFormatTags();

            Assert.NotNull(tags);
        }

        /// <summary>
        ///     Tests that video format tags creation time property should be settable
        /// </summary>
        [Fact]
        public void VideoFormatTags_CreationTimeProperty_ShouldBeSettable()
        {
            VideoFormatTags tags = new VideoFormatTags();
            string creationTime = "2021-01-01T00:00:00.000000Z";

            tags.CreationTime = creationTime;

            Assert.Equal(creationTime, tags.CreationTime);
        }
    }
}