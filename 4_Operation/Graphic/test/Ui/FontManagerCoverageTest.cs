using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// The font manager coverage test class
    /// </summary>
    public class FontManagerCoverageTest
    {
        /// <summary>
        /// Tests that default font is not null
        /// </summary>
        [Fact]
        public void DefaultFont_IsNotNull()
        {
            Font font = FontManager.DefaultFont;
            Assert.NotNull(font);
        }

        /// <summary>
        /// Tests that default font has expected name file
        /// </summary>
        [Fact]
        public void DefaultFont_HasExpectedNameFile()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal("mono.bmp", font.NameFile);
        }

        /// <summary>
        /// Tests that default font has depth one
        /// </summary>
        [Fact]
        public void DefaultFont_HasDepthOne()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal(1, font.Depth);
        }

        /// <summary>
        /// Tests that render text with colors throws when open gl not initialized
        /// </summary>
        [Fact]
        public void RenderText_WithColors_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.ThrowsAny<Exception>(
                () => FontManager.RenderText("hello", 0, 0, Color.White, Color.Black));
        }

        /// <summary>
        /// Tests that render text with coordinates throws when open gl not initialized
        /// </summary>
        [Fact]
        public void RenderText_WithCoordinates_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.ThrowsAny<Exception>(
                () => FontManager.RenderText("hello", 0, 0));
        }

        /// <summary>
        /// Tests that default font property exists and is read only
        /// </summary>
        [Fact]
        public void DefaultFont_PropertyExists_AndIsReadOnly()
        {
            PropertyInfo prop = typeof(FontManager).GetProperty("DefaultFont");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }
    }
}
