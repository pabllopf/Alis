using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    public class LoadingFailedExceptionTests
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
            LoadingFailedException ex = new LoadingFailedException("Texture");
            Assert.Equal("Failed to load Texture from memory", ex.Message);
        }

        [Fact]
        public void Constructor_WithResourceNameAndInnerException_SetsMessageAndInner()
        {
            Exception inner = new Exception("Inner");
            LoadingFailedException ex = new LoadingFailedException("Font", inner);
            Assert.Equal("Failed to load Font from memory", ex.Message);
            Assert.Equal(inner, ex.InnerException);
        }

        [Fact]
        public void Constructor_WithResourceNameAndFilename_SetsMessage()
        {
            LoadingFailedException ex = new LoadingFailedException("Image", "file.png");
            Assert.Equal("Failed to load Image from file file.png", ex.Message);
        }

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

