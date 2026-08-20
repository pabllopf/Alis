// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasCustomRectRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font atlas custom rect remaining coverage tests class
    /// </summary>
    public class ImFontAtlasCustomRectRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImFontAtlasCustomRect rect = default;
            Assert.Equal((ushort)0, rect.Width);
            Assert.Equal((ushort)0, rect.Height);
            Assert.Equal((ushort)0, rect.X);
            Assert.Equal((ushort)0, rect.Y);
            Assert.Equal(0u, rect.GlyphId);
            Assert.Equal(0f, rect.GlyphAdvanceX, 5);
            Assert.Equal(0f, rect.GlyphOffset.X, 5);
            Assert.Equal(0f, rect.GlyphOffset.Y, 5);
            Assert.Equal(IntPtr.Zero, rect.Font);
        }

        /// <summary>
        ///     Tests that width height x y round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void WidthHeightXY_RoundTrip()
        {
            ImFontAtlasCustomRect rect = default;
            rect.Width = 100;
            rect.Height = 200;
            rect.X = 10;
            rect.Y = 20;
            Assert.Equal((ushort)100, rect.Width);
            Assert.Equal((ushort)200, rect.Height);
            Assert.Equal((ushort)10, rect.X);
            Assert.Equal((ushort)20, rect.Y);
        }

        /// <summary>
        ///     Tests that glyph id round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void GlyphId_RoundTrip()
        {
            ImFontAtlasCustomRect rect = default;
            rect.GlyphId = 42u;
            Assert.Equal(42u, rect.GlyphId);
        }

        /// <summary>
        ///     Tests that glyph advance x and glyph offset round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void GlyphAdvanceXAndGlyphOffset_RoundTrip()
        {
            ImFontAtlasCustomRect rect = default;
            rect.GlyphAdvanceX = 1.5f;
            rect.GlyphOffset = new Vector2F(2.5f, 3.5f);
            Assert.Equal(1.5f, rect.GlyphAdvanceX, 5);
            Assert.Equal(2.5f, rect.GlyphOffset.X, 5);
            Assert.Equal(3.5f, rect.GlyphOffset.Y, 5);
        }

        /// <summary>
        ///     Tests that font round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Font_RoundTrip()
        {
            ImFontAtlasCustomRect rect = default;
            rect.Font = new IntPtr(777);
            Assert.Equal(new IntPtr(777), rect.Font);
        }
    }
}
