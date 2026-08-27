// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphCoverageTests.cs
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

using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests for the <see cref="ImFontGlyph" /> struct.
    /// </summary>
    public class ImFontGlyphCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
        [Fact]
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
        ///     Verifies that all properties round-trip.
        /// </summary>
        [Fact]
        public void AllProperties_RoundTrip()
        {
            ImFontGlyph glyph = new ImFontGlyph();

            glyph.Colored = 1u;
            glyph.Visible = 1u;
            glyph.Codepoint = 65u;
            glyph.AdvanceX = 1.5f;
            glyph.X0 = 1.0f;
            glyph.Y0 = 2.0f;
            glyph.X1 = 3.0f;
            glyph.Y1 = 4.0f;
            glyph.U0 = 5.0f;
            glyph.V0 = 6.0f;
            glyph.U1 = 7.0f;
            glyph.V1 = 8.0f;

            Assert.Equal(1u, glyph.Colored);
            Assert.Equal(1u, glyph.Visible);
            Assert.Equal(65u, glyph.Codepoint);
            Assert.Equal(1.5f, glyph.AdvanceX, 5);
            Assert.Equal(1.0f, glyph.X0, 5);
            Assert.Equal(2.0f, glyph.Y0, 5);
            Assert.Equal(3.0f, glyph.X1, 5);
            Assert.Equal(4.0f, glyph.Y1, 5);
            Assert.Equal(5.0f, glyph.U0, 5);
            Assert.Equal(6.0f, glyph.V0, 5);
            Assert.Equal(7.0f, glyph.U1, 5);
            Assert.Equal(8.0f, glyph.V1, 5);
        }
    }
}
