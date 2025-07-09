// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilderTest.cs
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
    ///     The im font glyph ranges builder test class
    /// </summary>
    public class ImFontGlyphRangesBuilderTest
    {
        /// <summary>
        ///     Tests that used chars should be initialized
        /// </summary>
        [Fact]
        public void UsedChars_ShouldBeInitialized()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            Assert.Equal(default(ImVector), builder.UsedChars);
        }

        /// <summary>
        ///     Tests that add char should not throw
        /// </summary>
        [Fact]
        public void AddChar_ShouldNotThrow()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            Assert.Throws<DllNotFoundException>(() => builder.AddChar(65));
        }

        /// <summary>
        ///     Tests that clear should not throw
        /// </summary>
        [Fact]
        public void Clear_ShouldNotThrow()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            Assert.Throws<DllNotFoundException>(() => builder.Clear());
        }

        /// <summary>
        ///     Tests that get bit should return bool
        /// </summary>
        [Fact]
        public void GetBit_ShouldReturnBool()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            Assert.Throws<DllNotFoundException>(() => builder.GetBit(1));
        }

        /// <summary>
        ///     Tests that set bit should not throw
        /// </summary>
        [Fact]
        public void SetBit_ShouldNotThrow()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            Assert.Throws<DllNotFoundException>(() => builder.SetBit(1));
        }
    }
}