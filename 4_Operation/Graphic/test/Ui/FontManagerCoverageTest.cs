using System;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    public class FontManagerCoverageTest
    {
        [Fact]
        public void DefaultFont_IsNotNull()
        {
            Font font = FontManager.DefaultFont;
            Assert.NotNull(font);
        }

        [Fact]
        public void DefaultFont_HasExpectedNameFile()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal("mono.bmp", font.NameFile);
        }

        [Fact]
        public void DefaultFont_HasDepthOne()
        {
            Font font = FontManager.DefaultFont;
            Assert.Equal(1, font.Depth);
        }

        [Fact]
        public void RenderText_WithColors_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.Throws<InvalidOperationException>(
                () => FontManager.RenderText("hello", 0, 0, Color.White, Color.Black));
        }

        [Fact]
        public void RenderText_WithCoordinates_ThrowsWhenOpenGLNotInitialized()
        {
            Assert.Throws<InvalidOperationException>(
                () => FontManager.RenderText("hello", 0, 0));
        }

        [Fact]
        public void DefaultFont_PropertyExists_AndIsReadOnly()
        {
            var prop = typeof(FontManager).GetProperty("DefaultFont");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }
    }
}
