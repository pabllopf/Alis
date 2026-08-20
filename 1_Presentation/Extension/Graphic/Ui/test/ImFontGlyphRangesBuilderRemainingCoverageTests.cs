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

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font glyph ranges builder remaining coverage tests class
    /// </summary>
    public class ImFontGlyphRangesBuilderRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default instance used chars should be default vector
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultInstance_UsedChars_ShouldBeDefaultVector()
        {
            ImFontGlyphRangesBuilder builder = default;

            Assert.Equal(0, builder.UsedChars.Size);
            Assert.Equal(0, builder.UsedChars.Capacity);
            Assert.Equal(IntPtr.Zero, builder.UsedChars.Data);
        }

        /// <summary>
        ///     Tests that used chars should round trip assigned vector
        /// </summary>
         [RequireCImguiSystemFact]
        public void UsedChars_ShouldRoundTripAssignedVector()
        {
            ImFontGlyphRangesBuilder builder = default;
            ImVector vector = new ImVector
            {
                Size = 7,
                Capacity = 16,
                Data = new IntPtr(42)
            };

            builder.UsedChars = vector;

            Assert.Equal(7, builder.UsedChars.Size);
            Assert.Equal(16, builder.UsedChars.Capacity);
            Assert.Equal(new IntPtr(42), builder.UsedChars.Data);
        }

        /// <summary>
        ///     Tests that used chars should remain zero after clear of untouched builder
        /// </summary>
         [RequireCImguiSystemFact]
        public void UsedChars_ShouldRemainZeroOnUntouchedBuilder()
        {
            ImFontGlyphRangesBuilder builder = default;
            ImVector first = builder.UsedChars;
            ImVector second = builder.UsedChars;

            Assert.Equal(first.Size, second.Size);
            Assert.Equal(first.Capacity, second.Capacity);
            Assert.Equal(first.Data, second.Data);
        }
    }
}
