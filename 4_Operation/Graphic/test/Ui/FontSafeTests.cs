using System;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// The font safe tests class
    /// </summary>
    public class FontSafeTests
    {
        /// <summary>
        /// Tests that constructor sets name file
        /// </summary>
        [Fact]
        public void Constructor_SetsNameFile()
        {
            Font font = new Font("test.bmp", 2, 16);
            Assert.Equal("test.bmp", font.NameFile);
        }

        /// <summary>
        /// Tests that depth get set works
        /// </summary>
        [Fact]
        public void Depth_GetSet_Works()
        {
            Font font = new Font("f", 2, 16);
            Assert.Equal(2, font.Depth);
            font.Depth = 5;
            Assert.Equal(5, font.Depth);
        }

        /// <summary>
        /// Tests that name file get set works
        /// </summary>
        [Fact]
        public void NameFile_GetSet_Works()
        {
            Font font = new Font("test.bmp", 1, 1);
            font.NameFile = "new.bmp";
            Assert.Equal("new.bmp", font.NameFile);
        }

        /// <summary>
        /// Tests that font is public
        /// </summary>
        [Fact]
        public void Font_IsPublic()
        {
            Assert.True(typeof(Font).IsPublic);
        }

        /// <summary>
        /// Tests that render text throws when open gl not available
        /// </summary>
        [Fact]
        public void RenderText_ThrowsWhenOpenGLNotAvailable()
        {
            Font font = new Font("test.bmp", 1, 1);
            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("hello", 0, 0, Alis.Core.Aspect.Math.Definition.Color.White, Alis.Core.Aspect.Math.Definition.Color.Transparent));
        }

        /// <summary>
        /// Tests that render text null text throws
        /// </summary>
        [Fact]
        public void RenderText_NullText_Throws()
        {
            Font font = new Font("test.bmp", 1, 1);
            Assert.ThrowsAny<Exception>(() =>
                font.RenderText(null, 0, 0, Alis.Core.Aspect.Math.Definition.Color.White, Alis.Core.Aspect.Math.Definition.Color.Transparent));
        }
    }
}
