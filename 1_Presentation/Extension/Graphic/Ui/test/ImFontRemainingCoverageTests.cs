// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="ImFont" /> struct.
    /// </summary>
    public class ImFontRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
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
            Assert.Equal(IntPtr.Zero, font.FallbackGlyph);
            Assert.Equal(IntPtr.Zero, font.ContainerAtlas);
            Assert.Equal(IntPtr.Zero, font.ConfigData);
            Assert.Null(font.Used4KPagesMap);
        }

        /// <summary>
        ///     Verifies that ImVector properties round-trip via default.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImVectorProperties_RoundTrip()
        {
            ImFont font = default;
            ImVector v = default;
            font.IndexAdvanceX = v;
            font.IndexLookup = v;
            font.Glyphs = v;
            Assert.Equal(v, font.IndexAdvanceX);
            Assert.Equal(v, font.IndexLookup);
            Assert.Equal(v, font.Glyphs);
        }

        /// <summary>
        ///     Verifies that numeric properties round-trip.
        /// </summary>
         [RequireCImguiSystemFact]
        public void NumericProperties_RoundTrip()
        {
            ImFont font = default;
            font.FallbackAdvanceX = 1.0f;
            font.FontSize = 12.0f;
            font.Scale = 2.0f;
            font.Ascent = 0.8f;
            font.Descent = 0.2f;
            font.ConfigDataCount = 5;
            font.FallbackChar = 65;
            font.EllipsisChar = 46;
            font.DotChar = 42;
            font.DirtyLookupTables = 1;
            font.MetricsTotalSurface = 999;
            Assert.Equal(1.0f, font.FallbackAdvanceX, 5);
            Assert.Equal(12.0f, font.FontSize, 5);
            Assert.Equal(2.0f, font.Scale, 5);
            Assert.Equal(0.8f, font.Ascent, 5);
            Assert.Equal(0.2f, font.Descent, 5);
            Assert.Equal(5, font.ConfigDataCount);
            Assert.Equal(65, font.FallbackChar);
            Assert.Equal(46, font.EllipsisChar);
            Assert.Equal(42, font.DotChar);
            Assert.Equal(1, font.DirtyLookupTables);
            Assert.Equal(999, font.MetricsTotalSurface);
        }

        /// <summary>
        ///     Verifies that pointer properties round-trip.
        /// </summary>
         [RequireCImguiSystemFact]
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
        ///     Verifies that Used4KPagesMap field round-trips.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Used4KPagesMap_RoundTrip()
        {
            ImFont font = new ImFont();
            byte[] arr = new byte[] { 1, 2 };
            font.Used4KPagesMap = arr;
            Assert.Same(arr, font.Used4KPagesMap);
        }
    }
}
