// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2MappingRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sdl2.Mapping;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test.Mapping
{
    /// <summary>
    ///     The sdl 2 mapping remaining coverage tests class
    /// </summary>
    public class Sdl2MappingRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that key codes enum has expected values
        /// </summary>
        [RequireSdl2ImageFact]
        public void KeyCodes_Enum_HasExpectedValues()
        {
            Assert.Equal(0, (int) KeyCodes.Unknown);
            Assert.Equal(13, (int) KeyCodes.Return);
            Assert.Equal(27, (int) KeyCodes.Escape);
            Assert.Equal(8, (int) KeyCodes.Backspace);
            Assert.Equal(9, (int) KeyCodes.Tab);
            Assert.Equal(32, (int) KeyCodes.Space);
            Assert.Equal(33, (int) KeyCodes.Exclaim);
            Assert.Equal(34, (int) KeyCodes.Quotedbl);
            Assert.Equal(35, (int) KeyCodes.Hash);
            Assert.Equal(37, (int) KeyCodes.Percent);
            Assert.Equal(36, (int) KeyCodes.Dollar);
        }

        /// <summary>
        ///     Tests that key codes enum keys have expected values
        /// </summary>
        [RequireSdl2ImageFact]
        public void KeyCodes_Enum_KeysHaveExpectedValues()
        {
            Assert.True((int) KeyCodes.A >= 97);
            Assert.True((int) KeyCodes.Z >= 122);
            Assert.True((int) KeyCodes.F1 > 0x40000000);
        }

        /// <summary>
        ///     Tests that input const has expected values
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlInputConst_HasExpectedValues()
        {
            Assert.Equal(1 << 30, SdlInputConst.KScancodeMask);
            Assert.Equal(1u, SdlInputConst.ButtonLeft);
            Assert.Equal(2u, SdlInputConst.ButtonMiddle);
            Assert.Equal(3u, SdlInputConst.ButtonRight);
            Assert.Equal(uint.MaxValue, SdlInputConst.TouchMouseId);
            Assert.Equal(0x00, SdlInputConst.HatCentered);
        }

        /// <summary>
        ///     Tests that input const hat combinations have expected values
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlInputConst_HatCombinations_HaveExpectedValues()
        {
            Assert.Equal(0x02 | 0x01, SdlInputConst.HatRightUp);
            Assert.Equal(0x02 | 0x04, SdlInputConst.HatRightDown);
            Assert.Equal(0x08 | 0x01, SdlInputConst.HatLeftUp);
            Assert.Equal(0x08 | 0x04, SdlInputConst.HatLeftDown);
        }
    }
}
