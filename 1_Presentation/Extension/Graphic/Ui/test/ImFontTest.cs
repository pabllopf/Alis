

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font test class
    /// </summary>
    public class ImFontTest
    {
        /// <summary>
        ///     Tests that index advance x should be initialized correctly
        /// </summary>
        [Fact]
        public void IndexAdvanceX_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {IndexAdvanceX = new ImVector()};

            ImVector result = font.IndexAdvanceX;

            Assert.Equal(new ImVector(), result);
        }

        /// <summary>
        ///     Tests that fallback advance x should be initialized correctly
        /// </summary>
        [Fact]
        public void FallbackAdvanceX_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {FallbackAdvanceX = 1.0f};

            float result = font.FallbackAdvanceX;

            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that font size should be initialized correctly
        /// </summary>
        [Fact]
        public void FontSize_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {FontSize = 12.0f};

            float result = font.FontSize;

            Assert.Equal(12.0f, result);
        }

        /// <summary>
        ///     Tests that index lookup should be initialized correctly
        /// </summary>
        [Fact]
        public void IndexLookup_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {IndexLookup = new ImVector()};

            ImVector result = font.IndexLookup;

            Assert.Equal(new ImVector(), result);
        }

        /// <summary>
        ///     Tests that glyphs should be initialized correctly
        /// </summary>
        [Fact]
        public void Glyphs_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {Glyphs = new ImVector()};

            ImVector result = font.Glyphs;

            Assert.Equal(new ImVector(), result);
        }

        /// <summary>
        ///     Tests that fallback glyph should be initialized correctly
        /// </summary>
        [Fact]
        public void FallbackGlyph_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {FallbackGlyph = IntPtr.Zero};

            IntPtr result = font.FallbackGlyph;

            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that container atlas should be initialized correctly
        /// </summary>
        [Fact]
        public void ContainerAtlas_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {ContainerAtlas = IntPtr.Zero};

            IntPtr result = font.ContainerAtlas;

            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that config data should be initialized correctly
        /// </summary>
        [Fact]
        public void ConfigData_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {ConfigData = IntPtr.Zero};

            IntPtr result = font.ConfigData;

            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that config data count should be initialized correctly
        /// </summary>
        [Fact]
        public void ConfigDataCount_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {ConfigDataCount = 10};

            short result = font.ConfigDataCount;

            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that fallback char should be initialized correctly
        /// </summary>
        [Fact]
        public void FallbackChar_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {FallbackChar = 65};

            ushort result = font.FallbackChar;

            Assert.Equal(65, result);
        }

        /// <summary>
        ///     Tests that ellipsis char should be initialized correctly
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {EllipsisChar = 46};

            ushort result = font.EllipsisChar;

            Assert.Equal(46, result);
        }

        /// <summary>
        ///     Tests that dot char should be initialized correctly
        /// </summary>
        [Fact]
        public void DotChar_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {DotChar = 46};

            ushort result = font.DotChar;

            Assert.Equal(46, result);
        }

        /// <summary>
        ///     Tests that dirty lookup tables should be initialized correctly
        /// </summary>
        [Fact]
        public void DirtyLookupTables_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {DirtyLookupTables = 1};

            byte result = font.DirtyLookupTables;

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that scale should be initialized correctly
        /// </summary>
        [Fact]
        public void Scale_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {Scale = 1.0f};

            float result = font.Scale;

            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that ascent should be initialized correctly
        /// </summary>
        [Fact]
        public void Ascent_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {Ascent = 1.0f};

            float result = font.Ascent;

            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that descent should be initialized correctly
        /// </summary>
        [Fact]
        public void Descent_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {Descent = 1.0f};

            float result = font.Descent;

            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that metrics total surface should be initialized correctly
        /// </summary>
        [Fact]
        public void MetricsTotalSurface_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {MetricsTotalSurface = 100};

            int result = font.MetricsTotalSurface;

            Assert.Equal(100, result);
        }

        /// <summary>
        ///     Tests that used 4 k pages map should be initialized correctly
        /// </summary>
        [Fact]
        public void Used4KPagesMap_ShouldBeInitializedCorrectly()
        {
            ImFont font = new ImFont {Used4KPagesMap = new byte[] {1, 2}};

            byte[] result = font.Used4KPagesMap;

            Assert.Equal(new byte[] {1, 2}, result);
        }
    }
}