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

using Xunit;
using System;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;


namespace Alis.Core.Graphic.Test.Sdl2.Structs
{

    /// <summary>
    /// The keyboard event tests class
    /// </summary>
    public class KeyboardEventTests
    {
        /// <summary>
        /// Tests that keyboard event initializes properties correctly
        /// </summary>
        [Fact]
        public void KeyboardEvent_InitializesPropertiesCorrectly()
        {
            EventType expectedType = EventType.FirstEvent;
            byte expectedState = 0;
            byte expectedRepeat = 0;
            
            KeySym expectedKeySym = new KeySym
            {
                scancode = SdlScancode.SdlScancodeA,
                sym = KeyCodes.A,
                mod =  KeyMods.KModShift,
                unicode = 'a'
            };

            KeyboardEvent keyboardEvent = new KeyboardEvent
            {
                KeySym = expectedKeySym
            };

            Assert.Equal(expectedType, keyboardEvent.type);
            Assert.Equal(expectedState, keyboardEvent.state);
            Assert.Equal(expectedRepeat, keyboardEvent.repeat);
        }
    }
}