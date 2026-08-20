// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRemainingCoverageTests.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font glyph remaining coverage tests class
    /// </summary>
    public class ImFontGlyphRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImFontGlyph glyph = default;
            Assert.Equal(0u, glyph.Colored);
            Assert.Equal(0u, glyph.Visible);
            Assert.Equal(0u, glyph.Codepoint);
            Assert.Equal(0f, glyph.AdvanceX, 5);
            Assert.Equal(0f, glyph.X0, 5);
            Assert.Equal(0f, glyph.Y0, 5);
            Assert.Equal(0f, glyph.X1, 5);
            Assert.Equal(0f, glyph.Y1, 5);
            Assert.Equal(0f, glyph.U0, 5);
            Assert.Equal(0f, glyph.V0, 5);
            Assert.Equal(0f, glyph.U1, 5);
            Assert.Equal(0f, glyph.V1, 5);
        }

        /// <summary>
        ///     Tests that colored visible codepoint round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void ColoredVisibleCodepoint_RoundTrip()
        {
            ImFontGlyph glyph = default;
            glyph.Colored = 1u;
            glyph.Visible = 2u;
            glyph.Codepoint = 3u;
            Assert.Equal(1u, glyph.Colored);
            Assert.Equal(2u, glyph.Visible);
            Assert.Equal(3u, glyph.Codepoint);
        }

        /// <summary>
        ///     Tests that advance x round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void AdvanceX_RoundTrip()
        {
            ImFontGlyph glyph = default;
            glyph.AdvanceX = 0.75f;
            Assert.Equal(0.75f, glyph.AdvanceX, 5);
        }

        /// <summary>
        ///     Tests that x0 y0 x1 y1 round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void X0Y0X1Y1_RoundTrip()
        {
            ImFontGlyph glyph = default;
            glyph.X0 = 1f;
            glyph.Y0 = 2f;
            glyph.X1 = 3f;
            glyph.Y1 = 4f;
            Assert.Equal(1f, glyph.X0, 5);
            Assert.Equal(2f, glyph.Y0, 5);
            Assert.Equal(3f, glyph.X1, 5);
            Assert.Equal(4f, glyph.Y1, 5);
        }

        /// <summary>
        ///     Tests that u0 v0 u1 v1 round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void U0V0U1V1_RoundTrip()
        {
            ImFontGlyph glyph = default;
            glyph.U0 = 5f;
            glyph.V0 = 6f;
            glyph.U1 = 7f;
            glyph.V1 = 8f;
            Assert.Equal(5f, glyph.U0, 5);
            Assert.Equal(6f, glyph.V0, 5);
            Assert.Equal(7f, glyph.U1, 5);
            Assert.Equal(8f, glyph.V1, 5);
        }
    }
}
