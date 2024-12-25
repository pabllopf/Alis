// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTests.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The text input event tests class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class TextInputEventTests 
    {
        /// <summary>
        ///     Tests that text input event initializes properties correctly
        /// </summary>
        [Fact]
        public void TextInputEvent_InitializesPropertiesCorrectly()
        {
            EventType expectedType = EventType.TextInput;
            uint expectedTimestamp = 123456789;
            uint expectedWindowID = 987654321;
            byte[] expectedText = new byte[32] {72, 101, 108, 108, 111, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            TextInputEvent textInputEvent = new TextInputEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp,
                windowID = expectedWindowID,
                byte0 = expectedText[0],
                byte1 = expectedText[1],
                byte2 = expectedText[2],
                byte3 = expectedText[3],
                byte4 = expectedText[4],
                byte5 = expectedText[5],
                byte6 = 0,
                byte7 = 0,
                byte8 = 0,
                byte9 = 0,
                byte10 = 0,
                byte11 = 0,
                byte12 = 0,
                byte13 = 0,
                byte14 = 0,
                byte15 = 0,
                byte16 = 0,
                byte17 = 0,
                byte18 = 0,
                byte19 = 0,
                byte20 = 0,
                byte21 = 0,
                byte22 = 0,
                byte23 = 0,
                byte24 = 0,
                byte25 = 0,
                byte26 = 0,
                byte27 = 0,
                byte28 = 0,
                byte29 = 0,
                byte30 = 0,
                byte31 = 0
            };

            Assert.Equal(expectedType, textInputEvent.type);
            Assert.Equal(expectedTimestamp, textInputEvent.timestamp);
            Assert.Equal(expectedWindowID, textInputEvent.windowID);
            Assert.Equal(expectedText, textInputEvent.Text);
        }
    }
}