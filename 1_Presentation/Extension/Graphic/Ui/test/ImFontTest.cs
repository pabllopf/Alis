// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
            // Arrange
            ImFont font = new ImFont {IndexAdvanceX = new ImVector()};

            // Act
            ImVector result = font.IndexAdvanceX;

            // Assert
            Assert.Equal(new ImVector(), result);
        }

        /// <summary>
        ///     Tests that fallback advance x should be initialized correctly
        /// </summary>
        [Fact]
        public void FallbackAdvanceX_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {FallbackAdvanceX = 1.0f};

            // Act
            float result = font.FallbackAdvanceX;

            // Assert
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that font size should be initialized correctly
        /// </summary>
        [Fact]
        public void FontSize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {FontSize = 12.0f};

            // Act
            float result = font.FontSize;

            // Assert
            Assert.Equal(12.0f, result);
        }

        /// <summary>
        ///     Tests that index lookup should be initialized correctly
        /// </summary>
        [Fact]
        public void IndexLookup_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {IndexLookup = new ImVector()};

            // Act
            ImVector result = font.IndexLookup;

            // Assert
            Assert.Equal(new ImVector(), result);
        }

        /// <summary>
        ///     Tests that glyphs should be initialized correctly
        /// </summary>
        [Fact]
        public void Glyphs_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {Glyphs = new ImVector()};

            // Act
            ImVector result = font.Glyphs;

            // Assert
            Assert.Equal(new ImVector(), result);
        }

        /// <summary>
        ///     Tests that fallback glyph should be initialized correctly
        /// </summary>
        [Fact]
        public void FallbackGlyph_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {FallbackGlyph = IntPtr.Zero};

            // Act
            IntPtr result = font.FallbackGlyph;

            // Assert
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that container atlas should be initialized correctly
        /// </summary>
        [Fact]
        public void ContainerAtlas_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {ContainerAtlas = IntPtr.Zero};

            // Act
            IntPtr result = font.ContainerAtlas;

            // Assert
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that config data should be initialized correctly
        /// </summary>
        [Fact]
        public void ConfigData_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {ConfigData = IntPtr.Zero};

            // Act
            IntPtr result = font.ConfigData;

            // Assert
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that config data count should be initialized correctly
        /// </summary>
        [Fact]
        public void ConfigDataCount_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {ConfigDataCount = 10};

            // Act
            short result = font.ConfigDataCount;

            // Assert
            Assert.Equal(10, result);
        }

        /// <summary>
        ///     Tests that fallback char should be initialized correctly
        /// </summary>
        [Fact]
        public void FallbackChar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {FallbackChar = 65};

            // Act
            ushort result = font.FallbackChar;

            // Assert
            Assert.Equal(65, result);
        }

        /// <summary>
        ///     Tests that ellipsis char should be initialized correctly
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {EllipsisChar = 46};

            // Act
            ushort result = font.EllipsisChar;

            // Assert
            Assert.Equal(46, result);
        }

        /// <summary>
        ///     Tests that dot char should be initialized correctly
        /// </summary>
        [Fact]
        public void DotChar_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {DotChar = 46};

            // Act
            ushort result = font.DotChar;

            // Assert
            Assert.Equal(46, result);
        }

        /// <summary>
        ///     Tests that dirty lookup tables should be initialized correctly
        /// </summary>
        [Fact]
        public void DirtyLookupTables_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {DirtyLookupTables = 1};

            // Act
            byte result = font.DirtyLookupTables;

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that scale should be initialized correctly
        /// </summary>
        [Fact]
        public void Scale_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {Scale = 1.0f};

            // Act
            float result = font.Scale;

            // Assert
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that ascent should be initialized correctly
        /// </summary>
        [Fact]
        public void Ascent_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {Ascent = 1.0f};

            // Act
            float result = font.Ascent;

            // Assert
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that descent should be initialized correctly
        /// </summary>
        [Fact]
        public void Descent_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {Descent = 1.0f};

            // Act
            float result = font.Descent;

            // Assert
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that metrics total surface should be initialized correctly
        /// </summary>
        [Fact]
        public void MetricsTotalSurface_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {MetricsTotalSurface = 100};

            // Act
            int result = font.MetricsTotalSurface;

            // Assert
            Assert.Equal(100, result);
        }

        /// <summary>
        ///     Tests that used 4 k pages map should be initialized correctly
        /// </summary>
        [Fact]
        public void Used4KPagesMap_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImFont font = new ImFont {Used4KPagesMap = new byte[] {1, 2}};

            // Act
            byte[] result = font.Used4KPagesMap;

            // Assert
            Assert.Equal(new byte[] {1, 2}, result);
        }
    }
}