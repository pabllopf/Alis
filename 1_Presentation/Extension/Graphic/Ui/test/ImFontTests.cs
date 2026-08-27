// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontTests.cs
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
    ///     Provides unit coverage for the <see cref="ImFont" /> struct.
    /// </summary>
    public class ImFontTests
    {
        /// <summary>
        ///     Verifies that the default struct has zero-initialized scalar values.
        /// </summary>
        [Fact]
        public void Default_ScalarProperties_AreZero()
        {
            ImFont font = default;
            Assert.Equal(0f, font.FallbackAdvanceX, 5);
            Assert.Equal(0f, font.FontSize, 5);
            Assert.Equal(0f, font.Scale, 5);
            Assert.Equal(0f, font.Ascent, 5);
            Assert.Equal(0f, font.Descent, 5);
            Assert.Equal(0, font.ConfigDataCount);
            Assert.Equal(0, font.FallbackChar);
            Assert.Equal(0, font.EllipsisChar);
            Assert.Equal(0, font.DotChar);
            Assert.Equal(0, font.DirtyLookupTables);
            Assert.Equal(0, font.MetricsTotalSurface);
        }

        /// <summary>
        ///     Verifies that the default struct has zero-initialized pointer properties.
        /// </summary>
        [Fact]
        public void Default_PointerProperties_AreZero()
        {
            ImFont font = default;
            Assert.Equal(IntPtr.Zero, font.FallbackGlyph);
            Assert.Equal(IntPtr.Zero, font.ContainerAtlas);
            Assert.Equal(IntPtr.Zero, font.ConfigData);
        }

        /// <summary>
        ///     Verifies that the default struct has a null pages map field.
        /// </summary>
        [Fact]
        public void Default_Used4KPagesMap_IsNull()
        {
            ImFont font = default;
            Assert.Null(font.Used4KPagesMap);
        }

        /// <summary>
        ///     Verifies that float properties round-trip through their setters.
        /// </summary>
        [Fact]
        public void FloatProperties_RoundTrip()
        {
            ImFont font = default;
            font.FallbackAdvanceX = 1.25f;
            font.FontSize = 16.0f;
            font.Scale = 1.5f;
            font.Ascent = 0.9f;
            font.Descent = 0.3f;
            Assert.Equal(1.25f, font.FallbackAdvanceX, 5);
            Assert.Equal(16.0f, font.FontSize, 5);
            Assert.Equal(1.5f, font.Scale, 5);
            Assert.Equal(0.9f, font.Ascent, 5);
            Assert.Equal(0.3f, font.Descent, 5);
        }

        /// <summary>
        ///     Verifies that integer properties round-trip through their setters.
        /// </summary>
        [Fact]
        public void IntegerProperties_RoundTrip()
        {
            ImFont font = default;
            font.ConfigDataCount = -7;
            font.MetricsTotalSurface = 12345;
            Assert.Equal(-7, font.ConfigDataCount);
            Assert.Equal(12345, font.MetricsTotalSurface);
        }

        /// <summary>
        ///     Verifies that unsigned character properties round-trip through their setters.
        /// </summary>
        [Fact]
        public void UnsignedCharacterProperties_RoundTrip()
        {
            ImFont font = default;
            font.FallbackChar = 65;
            font.EllipsisChar = 46;
            font.DotChar = 42;
            Assert.Equal(65, font.FallbackChar);
            Assert.Equal(46, font.EllipsisChar);
            Assert.Equal(42, font.DotChar);
        }

        /// <summary>
        ///     Verifies that the dirty lookup tables byte property round-trips.
        /// </summary>
        [Fact]
        public void DirtyLookupTables_RoundTrip()
        {
            ImFont font = default;
            font.DirtyLookupTables = 255;
            Assert.Equal(255, font.DirtyLookupTables);
        }

        /// <summary>
        ///     Verifies that pointer properties round-trip through their setters.
        /// </summary>
        [Fact]
        public void PointerProperties_RoundTrip()
        {
            ImFont font = default;
            font.FallbackGlyph = new IntPtr(100);
            font.ContainerAtlas = new IntPtr(200);
            font.ConfigData = new IntPtr(300);
            Assert.Equal(new IntPtr(100), font.FallbackGlyph);
            Assert.Equal(new IntPtr(200), font.ContainerAtlas);
            Assert.Equal(new IntPtr(300), font.ConfigData);
        }

        /// <summary>
        ///     Verifies that ImVector properties round-trip by reference.
        /// </summary>
        [Fact]
        public void ImVectorProperties_RoundTrip()
        {
            ImFont font = default;
            ImVector vector = new ImVector(3, 6, new IntPtr(10));
            font.IndexAdvanceX = vector;
            font.IndexLookup = vector;
            font.Glyphs = vector;
            Assert.Equal(vector, font.IndexAdvanceX);
            Assert.Equal(vector, font.IndexLookup);
            Assert.Equal(vector, font.Glyphs);
        }

        /// <summary>
        ///     Verifies that the pages map field round-trips by reference.
        /// </summary>
        [Fact]
        public void Used4KPagesMap_RoundTrip()
        {
            ImFont font = new ImFont();
            byte[] map = new byte[] { 1, 2, 3 };
            font.Used4KPagesMap = map;
            Assert.Same(map, font.Used4KPagesMap);
        }
    }
}
