using System;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    public class FontManagerSafeTests
    {
        [Fact]
        public void DefaultFont_IsNotNull()
        {
            Assert.NotNull(FontManager.DefaultFont);
        }

        [Fact]
        public void DefaultFont_IsFontType()
        {
            Assert.IsType<Font>(FontManager.DefaultFont);
        }

        [Fact]
        public void RenderText_WithCoordinates_ThrowsWhenOpenGLNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 0, 0));
        }

        [Fact]
        public void RenderText_WithColors_ThrowsWhenOpenGLNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() =>
                FontManager.RenderText("hello", 0, 0, Alis.Core.Aspect.Math.Definition.Color.White, Alis.Core.Aspect.Math.Definition.Color.Transparent));
        }
    }
}
