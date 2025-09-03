using Xunit;
using Alis.Extension.Graphic.Sfml.Render;
using System.IO;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The font tests class
    /// </summary>
    public class FontTests
    {
        /// <summary>
        /// Tests that constructor from file throws if file not found
        /// </summary>
        [Fact(Skip = "Cannot test Font without native SFML dependencies and font files.")]
        public void Constructor_FromFile_ThrowsIfFileNotFound()
        {
            Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new Font("notfound.ttf"));
        }

        /// <summary>
        /// Tests that constructor from stream throws if invalid
        /// </summary>
        [Fact(Skip = "Cannot test Font without native SFML dependencies.")]
        public void Constructor_FromStream_ThrowsIfInvalid()
        {
            using var ms = new MemoryStream(new byte[] { 1, 2, 3 });
            Assert.Throws<Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException>(() => new Font(ms));
        }

        /// <summary>
        /// Tests that to string returns font
        /// </summary>
        [Fact(Skip = "Cannot test Font without native SFML dependencies.")]
        public void ToString_ReturnsFont()
        {
            // Would require a valid font file and native SFML
            var font = new Font("somefile.ttf");
            Assert.Equal("Font", font.ToString());
        }
    }
}

