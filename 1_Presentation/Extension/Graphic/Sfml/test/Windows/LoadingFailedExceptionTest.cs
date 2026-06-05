using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class LoadingFailedExceptionTest
    {
        [Fact]
        public void DefaultConstructor_SetsDefaultMessage()
        {
            LoadingFailedException ex = new LoadingFailedException();
            Assert.Equal("Failed to load a resource", ex.Message);
        }

        [Fact]
        public void Constructor_WithResourceName_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("texture");
            Assert.Equal("Failed to load texture from memory", ex.Message);
        }

        [Fact]
        public void Constructor_WithResourceNameAndInnerException_SetsMessage()
        {
            System.Exception inner = new System.Exception("cause");
            LoadingFailedException ex = new LoadingFailedException("image", inner);
            Assert.Equal("Failed to load image from memory", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }

        [Fact]
        public void Constructor_WithResourceNameAndFilename_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("font", "arial.ttf");
            Assert.Equal("Failed to load font from file arial.ttf", ex.Message);
        }

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
