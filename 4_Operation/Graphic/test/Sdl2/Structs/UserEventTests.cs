// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UserEventTests.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The user event tests class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class UserEventTests 
    {
        /// <summary>
        ///     Tests that user event initializes properties correctly
        /// </summary>
        [Fact]
        public void UserEvent_InitializesPropertiesCorrectly()
        {
            uint expectedType = 1;
            uint expectedTimestamp = 123456789;
            uint expectedWindowID = 2;
            int expectedCode = 3;
            IntPtr expectedData1 = new IntPtr(4);
            IntPtr expectedData2 = new IntPtr(5);

            UserEvent userEvent = new UserEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp,
                windowID = expectedWindowID,
                code = expectedCode,
                Data1 = expectedData1,
                Data2 = expectedData2
            };

            Assert.Equal(expectedType, userEvent.type);
            Assert.Equal(expectedTimestamp, userEvent.timestamp);
            Assert.Equal(expectedWindowID, userEvent.windowID);
            Assert.Equal(expectedCode, userEvent.code);
            Assert.Equal(expectedData1, userEvent.Data1);
            Assert.Equal(expectedData2, userEvent.Data2);
        }
    }
}