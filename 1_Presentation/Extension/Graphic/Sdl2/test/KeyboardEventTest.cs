// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardEventTest.cs
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
    /// The keyboard event test class
    /// </summary>
    public class KeyboardEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            KeyboardEvent evt = new KeyboardEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.repeat);
        }

        /// <summary>
        /// Tests that should assign keysym
        /// </summary>
        [Fact]
        public void ShouldAssignKeysym()
        {
            KeyboardEvent evt = new KeyboardEvent();
            evt.KeySym = new KeySym { unicode = 65u, scancode = SdlScancode.SdlScancodeA, sym = KeyCodes.A };
            Assert.Equal(65u, evt.KeySym.unicode);
            Assert.Equal(SdlScancode.SdlScancodeA, evt.KeySym.scancode);
            Assert.Equal(KeyCodes.A, evt.KeySym.sym);
        }
    }
}
