// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImDrawListFlags" /> enum values.
    /// </summary>
    public class ImDrawListFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImDrawListFlags flag = ImDrawListFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that AntiAliasedLines has the expected value of 1.
        /// </summary>
        [Fact]
        public void AntiAliasedLines_ShouldHaveCorrectValue()
        {
            ImDrawListFlags flag = ImDrawListFlags.AntiAliasedLines;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that AntiAliasedLinesUseTex has the expected value of 2.
        /// </summary>
        [Fact]
        public void AntiAliasedLinesUseTex_ShouldHaveCorrectValue()
        {
            ImDrawListFlags flag = ImDrawListFlags.AntiAliasedLinesUseTex;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that AntiAliasedFill has the expected value of 4.
        /// </summary>
        [Fact]
        public void AntiAliasedFill_ShouldHaveCorrectValue()
        {
            ImDrawListFlags flag = ImDrawListFlags.AntiAliasedFill;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that AllowVtxOffset has the expected value of 8.
        /// </summary>
        [Fact]
        public void AllowVtxOffset_ShouldHaveCorrectValue()
        {
            ImDrawListFlags flag = ImDrawListFlags.AllowVtxOffset;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImDrawListFlags combined = ImDrawListFlags.AntiAliasedLines | ImDrawListFlags.AntiAliasedFill;
            int expected = 1 | 4;
            Assert.Equal(expected, (int)combined);
        }
    }
}
