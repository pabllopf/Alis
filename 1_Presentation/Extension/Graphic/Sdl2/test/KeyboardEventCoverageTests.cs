// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardEventCoverageTests.cs
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

using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The keyboard event coverage tests class
    /// </summary>
    public class KeyboardEventCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void KeyboardEvent_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            KeyboardEvent evt = default(KeyboardEvent);

            Assert.Equal(default(EventType), evt.type);
            Assert.Equal(0U, evt.timestamp);
            Assert.Equal(0U, evt.windowID);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.repeat);
            Assert.Equal(default(KeySym), evt.KeySym);
        }

        /// <summary>
        ///     Tests that set property stores values correctly
        /// </summary>
        [Fact]
        public void KeyboardEvent_SetProperty_StoresValuesCorrectly()
        {
            KeySym keySym = new KeySym { scancode = SdlScancode.SdlScancodeA, sym = KeyCodes.A, mod = KeyMods.None };
            KeyboardEvent evt = new KeyboardEvent { KeySym = keySym };

            Assert.Equal(keySym, evt.KeySym);
        }
    }
}