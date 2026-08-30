// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UserEventCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The user event coverage tests class
    /// </summary>
    public class UserEventCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization has zeroed fields and null pointers
        /// </summary>
        [Fact]
        public void UserEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            UserEvent userEvent = default(UserEvent);

            Assert.Equal(0u, userEvent.type);
            Assert.Equal(0u, userEvent.timestamp);
            Assert.Equal(0u, userEvent.windowID);
            Assert.Equal(0, userEvent.code);
            Assert.Equal(IntPtr.Zero, userEvent.Data1);
            Assert.Equal(IntPtr.Zero, userEvent.Data2);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void UserEvent_SetProperties_StoresValuesCorrectly()
        {
            UserEvent userEvent = new UserEvent
            {
                Data1 = new IntPtr(1),
                Data2 = new IntPtr(2)
            };

            Assert.Equal(new IntPtr(1), userEvent.Data1);
            Assert.Equal(new IntPtr(2), userEvent.Data2);
        }

        /// <summary>
        ///     Tests that fields can be mutated directly
        /// </summary>
        [Fact]
        public void UserEvent_MutateFields_ValuesAreUpdated()
        {
            UserEvent userEvent = new UserEvent();

            userEvent.type = 1u;
            userEvent.timestamp = 2u;
            userEvent.windowID = 3u;
            userEvent.code = 4;

            Assert.Equal(1u, userEvent.type);
            Assert.Equal(2u, userEvent.timestamp);
            Assert.Equal(3u, userEvent.windowID);
            Assert.Equal(4, userEvent.code);
        }
    }
}