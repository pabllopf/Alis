// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilderRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font glyph ranges builder remaining coverage tests class
    /// </summary>
    public class ImFontGlyphRangesBuilderRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that AddChar can be called without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddChar_ShouldNotThrow()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            builder.AddChar(65);
        }

        /// <summary>
        ///     Verifies that Clear can be called without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ShouldNotThrow()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            builder.Clear();
        }

        /// <summary>
        ///     Verifies that GetBit returns false for an unset bit.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetBit_UnsetBit_ReturnsFalse()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            bool result = builder.GetBit(0);
            Assert.False(result);
        }

        /// <summary>
        ///     Verifies that SetBit does not throw.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetBit_ShouldNotThrow()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            builder.SetBit(0);
        }

        /// <summary>
        ///     Verifies that after SetBit, GetBit returns true for the same bit.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetBit_And_GetBit_SameBit_ReturnsTrue()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            builder.SetBit(42);
            Assert.True(builder.GetBit(42));
        }

        /// <summary>
        ///     Verifies that after AddChar, GetBit returns true for that character code.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddChar_And_GetBit_ForThatChar_ReturnsTrue()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            builder.AddChar(65);
            Assert.True(builder.GetBit(65));
        }

        /// <summary>
        ///     Verifies that Clear resets the builder state.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_AfterAddChar_GetBitReturnsFalse()
        {
            ImFontGlyphRangesBuilder builder = new ImFontGlyphRangesBuilder();
            builder.AddChar(65);
            builder.Clear();
            bool result = builder.GetBit(65);
            Assert.False(result);
        }
    }
}
