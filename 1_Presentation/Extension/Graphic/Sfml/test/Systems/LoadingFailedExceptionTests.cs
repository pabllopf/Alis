using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    /// The loading failed exception tests class
    /// </summary>
    public class LoadingFailedExceptionTests
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
            LoadingFailedException ex = new LoadingFailedException("Texture");
            Assert.Equal("Failed to load Texture from memory", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name and inner exception sets message and inner
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndInnerException_SetsMessageAndInner()
        {
            Exception inner = new Exception("Inner");
            LoadingFailedException ex = new LoadingFailedException("Font", inner);
            Assert.Equal("Failed to load Font from memory", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }

        /// <summary>
        /// Tests that constructor with resource name and filename sets message
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameAndFilename_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("Image", "file.png");
            Assert.Equal("Failed to load Image from file file.png", ex.Message);
        }

        /// <summary>
        /// Tests that constructor with resource name filename and inner sets message and inner
        /// </summary>
        [Fact]
        public void Constructor_WithResourceNameFilenameAndInner_SetsMessageAndInner()
        {
            Exception inner = new Exception("Inner");
            LoadingFailedException ex = new LoadingFailedException("Sound", "file.wav", inner);
            Assert.Equal("Failed to load Sound from file file.wav", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }
    }
}

