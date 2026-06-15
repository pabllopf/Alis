// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeySymTest.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The key sym test class
    /// </summary>
    public class KeySymTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            KeySym sym = new KeySym();
            Assert.Equal(0u, sym.unicode);
        }

        /// <summary>
        /// Tests that should assign and retrieve fields
        /// </summary>
        [Fact]
        public void ShouldAssignAndRetrieveFields()
        {
            KeySym sym = new KeySym
            {
                scancode = SdlScancode.SdlScancodeA,
                sym = KeyCodes.Return,
                unicode = 65u
            };
            Assert.Equal(SdlScancode.SdlScancodeA, sym.scancode);
            Assert.Equal(KeyCodes.Return, sym.sym);
            Assert.Equal(65u, sym.unicode);
        }
    }
}
