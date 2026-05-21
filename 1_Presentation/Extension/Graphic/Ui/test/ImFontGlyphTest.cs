

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font glyph test class
    /// </summary>
    public class ImFontGlyphTest
    {
        /// <summary>
        ///     Tests that colored should set and get correctly
        /// </summary>
        [Fact]
        public void Colored_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.Colored = 1;
            Assert.Equal(1u, fontGlyph.Colored);
        }

        /// <summary>
        ///     Tests that visible should set and get correctly
        /// </summary>
        [Fact]
        public void Visible_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.Visible = 1;
            Assert.Equal(1u, fontGlyph.Visible);
        }

        /// <summary>
        ///     Tests that codepoint should set and get correctly
        /// </summary>
        [Fact]
        public void Codepoint_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.Codepoint = 65;
            Assert.Equal(65u, fontGlyph.Codepoint);
        }

        /// <summary>
        ///     Tests that advance x should set and get correctly
        /// </summary>
        [Fact]
        public void AdvanceX_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.AdvanceX = 10.5f;
            Assert.Equal(10.5f, fontGlyph.AdvanceX);
        }

        /// <summary>
        ///     Tests that x 0 should set and get correctly
        /// </summary>
        [Fact]
        public void X0_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.X0 = 1.0f;
            Assert.Equal(1.0f, fontGlyph.X0);
        }

        /// <summary>
        ///     Tests that y 0 should set and get correctly
        /// </summary>
        [Fact]
        public void Y0_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.Y0 = 2.0f;
            Assert.Equal(2.0f, fontGlyph.Y0);
        }

        /// <summary>
        ///     Tests that x 1 should set and get correctly
        /// </summary>
        [Fact]
        public void X1_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.X1 = 3.0f;
            Assert.Equal(3.0f, fontGlyph.X1);
        }

        /// <summary>
        ///     Tests that y 1 should set and get correctly
        /// </summary>
        [Fact]
        public void Y1_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.Y1 = 4.0f;
            Assert.Equal(4.0f, fontGlyph.Y1);
        }

        /// <summary>
        ///     Tests that u 0 should set and get correctly
        /// </summary>
        [Fact]
        public void U0_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.U0 = 0.1f;
            Assert.Equal(0.1f, fontGlyph.U0);
        }

        /// <summary>
        ///     Tests that v 0 should set and get correctly
        /// </summary>
        [Fact]
        public void V0_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.V0 = 0.2f;
            Assert.Equal(0.2f, fontGlyph.V0);
        }

        /// <summary>
        ///     Tests that u 1 should set and get correctly
        /// </summary>
        [Fact]
        public void U1_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.U1 = 0.3f;
            Assert.Equal(0.3f, fontGlyph.U1);
        }

        /// <summary>
        ///     Tests that v 1 should set and get correctly
        /// </summary>
        [Fact]
        public void V1_Should_SetAndGetCorrectly()
        {
            ImFontGlyph fontGlyph = new ImFontGlyph();
            fontGlyph.V1 = 0.4f;
            Assert.Equal(0.4f, fontGlyph.V1);
        }
    }
}