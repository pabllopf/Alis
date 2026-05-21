

using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font atlas custom rect test class
    /// </summary>
    public class ImFontAtlasCustomRectTest
    {
        /// <summary>
        ///     Tests that width should be initialized
        /// </summary>
        [Fact]
        public void Width_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(ushort), rect.Width);
        }

        /// <summary>
        ///     Tests that height should be initialized
        /// </summary>
        [Fact]
        public void Height_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(ushort), rect.Height);
        }

        /// <summary>
        ///     Tests that x should be initialized
        /// </summary>
        [Fact]
        public void X_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(ushort), rect.X);
        }

        /// <summary>
        ///     Tests that y should be initialized
        /// </summary>
        [Fact]
        public void Y_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(ushort), rect.Y);
        }

        /// <summary>
        ///     Tests that glyph id should be initialized
        /// </summary>
        [Fact]
        public void GlyphId_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(uint), rect.GlyphId);
        }

        /// <summary>
        ///     Tests that glyph advance x should be initialized
        /// </summary>
        [Fact]
        public void GlyphAdvanceX_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(float), rect.GlyphAdvanceX);
        }

        /// <summary>
        ///     Tests that glyph offset should be initialized
        /// </summary>
        [Fact]
        public void GlyphOffset_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(default(Vector2F), rect.GlyphOffset);
        }

        /// <summary>
        ///     Tests that font should be initialized
        /// </summary>
        [Fact]
        public void Font_ShouldBeInitialized()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Equal(IntPtr.Zero, rect.Font);
        }

        /// <summary>
        ///     Tests that width should set and get correctly
        /// </summary>
        [Fact]
        public void Width_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            rect.Width = 100;
            Assert.Equal(100, rect.Width);
        }

        /// <summary>
        ///     Tests that height should set and get correctly
        /// </summary>
        [Fact]
        public void Height_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            rect.Height = 200;
            Assert.Equal(200, rect.Height);
        }

        /// <summary>
        ///     Tests that x should set and get correctly
        /// </summary>
        [Fact]
        public void X_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            rect.X = 10;
            Assert.Equal(10, rect.X);
        }

        /// <summary>
        ///     Tests that y should set and get correctly
        /// </summary>
        [Fact]
        public void Y_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            rect.Y = 20;
            Assert.Equal(20, rect.Y);
        }

        /// <summary>
        ///     Tests that glyph id should set and get correctly
        /// </summary>
        [Fact]
        public void GlyphId_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            rect.GlyphId = 12345;
            Assert.Equal((uint) 12345, rect.GlyphId);
        }

        /// <summary>
        ///     Tests that glyph advance x should set and get correctly
        /// </summary>
        [Fact]
        public void GlyphAdvanceX_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            rect.GlyphAdvanceX = 1.5f;
            Assert.Equal(1.5f, rect.GlyphAdvanceX);
        }

        /// <summary>
        ///     Tests that glyph offset should set and get correctly
        /// </summary>
        [Fact]
        public void GlyphOffset_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Vector2F offset = new Vector2F(1.0f, 2.0f);
            rect.GlyphOffset = offset;
            Assert.Equal(offset, rect.GlyphOffset);
        }

        /// <summary>
        ///     Tests that font should set and get correctly
        /// </summary>
        [Fact]
        public void Font_Should_SetAndGetCorrectly()
        {
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            IntPtr fontPtr = new IntPtr(123);
            rect.Font = fontPtr;
            Assert.Equal(fontPtr, rect.Font);
        }
    }
}