// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphTest.cs
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

namespace Alis.Extension.Graphic.ImGui.Test
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