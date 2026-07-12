// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImFontAtlasFlags" /> enum values.
    /// </summary>
    public class ImFontAtlasFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImFontAtlasFlags flag = ImFontAtlasFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoPowerOfTwoHeight has the expected value of 1.
        /// </summary>
        [Fact]
        public void NoPowerOfTwoHeight_ShouldHaveCorrectValue()
        {
            ImFontAtlasFlags flag = ImFontAtlasFlags.NoPowerOfTwoHeight;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoMouseCursors has the expected value of 2.
        /// </summary>
        [Fact]
        public void NoMouseCursors_ShouldHaveCorrectValue()
        {
            ImFontAtlasFlags flag = ImFontAtlasFlags.NoMouseCursors;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoBakedLines has the expected value of 4.
        /// </summary>
        [Fact]
        public void NoBakedLines_ShouldHaveCorrectValue()
        {
            ImFontAtlasFlags flag = ImFontAtlasFlags.NoBakedLines;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImFontAtlasFlags combined = ImFontAtlasFlags.NoPowerOfTwoHeight | ImFontAtlasFlags.NoMouseCursors;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
