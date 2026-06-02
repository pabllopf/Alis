// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UserEventTest.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the UserEvent struct.
    /// </summary>
    public class UserEventTest
    {
        [Fact]
        public void ShouldAssignAndRetrieveAllFields()
        {
            // Arrange
            var evt = new UserEvent
            {
                type = 1u,
                timestamp = 123u,
                windowID = 22u,
                code = -10,
                Data1 = new IntPtr(0x1234),
                Data2 = new IntPtr(0xABCD)
            };
            // Assert
            Assert.Equal(1u, evt.type);
            Assert.Equal(123u, evt.timestamp);
            Assert.Equal(22u, evt.windowID);
            Assert.Equal(-10, evt.code);
            Assert.Equal(new IntPtr(0x1234), evt.Data1);
            Assert.Equal(new IntPtr(0xABCD), evt.Data2);
        }
    }
}
