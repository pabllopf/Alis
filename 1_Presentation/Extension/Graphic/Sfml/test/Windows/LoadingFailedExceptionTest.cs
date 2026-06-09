using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The loading failed exception test class
    /// </summary>
    public class LoadingFailedExceptionTest
    {
        /// <summary>
        /// Tests that default constructor sets default message
        /// </summary>
        [Fact]
        public void DefaultConstructor_SetsDefaultMessage()
        {
            LoadingFailedException ex = new LoadingFailedException();
            Assert.Equal("Failed to load a resource", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceName_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("texture");
            Assert.Equal("Failed to load texture from memory", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name and inner exception sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndInnerException_SetsMessage()
        {
            System.Exception inner = new System.Exception("cause");
            LoadingFailedException ex = new LoadingFailedException("image", inner);
            Assert.Equal("Failed to load image from memory", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }

        /// <summary>
        /// Tests that constructor with resource name and filename sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndFilename_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("font", "arial.ttf");
            Assert.Equal("Failed to load font from file arial.ttf", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name filename and inner exception sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameFilenameAndInnerException_SetsMessage()
        {
            System.Exception inner = new System.Exception("io error");
            LoadingFailedException ex = new LoadingFailedException("sound", "song.ogg", inner);
            Assert.Equal("Failed to load sound from file song.ogg", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }
    }
}
