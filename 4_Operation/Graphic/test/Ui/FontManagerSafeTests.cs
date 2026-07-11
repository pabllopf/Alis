using System;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// The font manager safe tests class
    /// </summary>
    public class FontManagerSafeTests
    {
        /// <summary>
        /// Tests that default font is not null
        /// </summary>
        [Fact]
        public void DefaultFont_IsNotNull()
        {
            Assert.NotNull(FontManager.DefaultFont);
        }

        /// <summary>
        /// Tests that default font is font type
        /// </summary>
        [Fact]
        public void DefaultFont_IsFontType()
        {
            Assert.IsType<Font>(FontManager.DefaultFont);
        }

        /// <summary>
        /// Tests that render text with coordinates throws when open gl not available
        /// </summary>
        [Fact]
        public void RenderText_WithCoordinates_ThrowsWhenOpenGLNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => FontManager.RenderText("hello", 0, 0));
        }

        /// <summary>
        /// Tests that render text with colors throws when open gl not available
        /// </summary>
        [Fact]
        public void RenderText_WithColors_ThrowsWhenOpenGLNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() =>
                FontManager.RenderText("hello", 0, 0, Alis.Core.Aspect.Math.Definition.Color.White, Alis.Core.Aspect.Math.Definition.Color.Transparent));
        }
    }
}
