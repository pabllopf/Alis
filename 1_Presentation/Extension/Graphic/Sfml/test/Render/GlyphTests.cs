using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The glyph tests class
    /// </summary>
    public class GlyphTests
    {
        /// <summary>
        /// Tests that can set and get fields
        /// </summary>
        [Fact]
        public void CanSetAndGetFields()
        {
            var rect = new FloatRect(1, 2, 3, 4);
            var intRect = new IntRect(5, 6, 7, 8);
            var glyph = new Glyph
            {
                Advance = 9.5f,
                Bounds = rect,
                TextureRect = intRect
            };
            Assert.Equal(9.5f, glyph.Advance);
            Assert.Equal(rect, glyph.Bounds);
            Assert.Equal(intRect, glyph.TextureRect);
        }
    }
}

